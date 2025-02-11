using System.ComponentModel.DataAnnotations;

namespace BankWithdrawalService.Models
{
    public class BankAccount
    {
        [Key]
        public long AccountId { get; set; }

        public decimal Balance { get; set; }
    }
}
