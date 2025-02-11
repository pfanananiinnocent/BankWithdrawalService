using Microsoft.EntityFrameworkCore;
using BankWithdrawalService.Models;

namespace BankWithdrawalService.Data
{
    public class BankDbContext : DbContext
    {
        public BankDbContext(DbContextOptions<BankDbContext> options) : base(options) { }

        public DbSet<BankAccount> Accounts { get; set; }
    }
}
