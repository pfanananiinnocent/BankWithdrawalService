using BankWithdrawalService.Data;
using BankWithdrawalService.Models;
using Microsoft.EntityFrameworkCore;

namespace BankWithdrawalService.Repositories
{
    public class BankAccountRepository
    {
        private readonly BankDbContext _context;

        public BankAccountRepository(BankDbContext context)
        {
            _context = context;
        }

        public async Task<BankAccount?> GetAccountAsync(long accountId)
        {
            return await _context.Accounts.FirstOrDefaultAsync(a => a.AccountId == accountId);
        }

        public async Task<bool> UpdateBalanceAsync(long accountId, decimal amount)
        {
            var account = await GetAccountAsync(accountId);
            if (account == null || account.Balance < amount)
                return false;

            account.Balance -= amount;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
