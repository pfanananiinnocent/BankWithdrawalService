using BankWithdrawalService.Repositories;
using System.Text.Json;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;

namespace BankWithdrawalService.Services
{
    public class BankAccountService
    {
        private readonly BankAccountRepository _repository;
        private readonly IAmazonSimpleNotificationService _snsClient;
        private const string SnsTopicArn = "arn:aws:sns:YOUR_REGION:YOUR_ACCOUNT_ID:YOUR_TOPIC_NAME";

        public BankAccountService(BankAccountRepository repository, IAmazonSimpleNotificationService snsClient)
        {
            _repository = repository;
            _snsClient = snsClient;
        }

        public async Task<string> WithdrawAsync(long accountId, decimal amount)
        {
            var success = await _repository.UpdateBalanceAsync(accountId, amount);
            if (!success)
                return "Insufficient funds or account not found.";

            await PublishWithdrawalEventAsync(accountId, amount);
            return "Withdrawal successful";
        }

        private async Task PublishWithdrawalEventAsync(long accountId, decimal amount)
        {
            var message = JsonSerializer.Serialize(new { accountId, amount, status = "SUCCESSFUL" });
            await _snsClient.PublishAsync(new PublishRequest
            {
                TopicArn = SnsTopicArn,
                Message = message
            });
        }
    }
}
