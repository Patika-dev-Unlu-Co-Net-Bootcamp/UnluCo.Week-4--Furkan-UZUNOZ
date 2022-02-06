using DataLayer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluCo.Bank.DataLayer;

namespace DataAccessLayer
{
    public class BankContextDB : IdentityDbContext<AppUser>
    {
        public BankContextDB()
        {
        }

        public BankContextDB(DbContextOptions<BankContextDB> opt) : base(opt)
        {
        }

        public DbSet<BankAccountDetails> BankAccountsDetails { get; set; }
        public DbSet<BankAccount> bankAccounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BankAccountDB;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

    }
}
