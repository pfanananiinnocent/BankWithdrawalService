using BankWithdrawalService.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BankWithdrawalService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountController : ControllerBase
    {
        private readonly BankAccountService _service;

        public BankAccountController(BankAccountService service)
        {
            _service = service;
        }

        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw(long accountId, decimal amount)
        {
            var result = await _service.WithdrawAsync(accountId, amount);
            return Ok(result);
        }
    }
}
