using UnluCo.Bank.DataAccessLayer.inteface;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluCo.Bank.DataAccessLayer;
using DataAccessLayer;

namespace UnluCo.Bank.DataAccessLayer.Concrete
{
    public class BankRepository : IBankRepository
    {
        public BankAccountDetails CreatedNewAccount(BankAccountDetails Account)
        {
            using (var BankContext= new BankContextDB())
            {
                BankContext.BankAccountsDetails.Add(Account);
                BankContext.SaveChanges();
                return Account;
            }
        }


        public string DeleteAccount(int id)
        {
            using (var Bankcontext= new BankContextDB())
            {
                Bankcontext.BankAccountsDetails.Remove(Bankcontext.BankAccountsDetails.Find(id));
                Bankcontext.SaveChanges();
                return "DELETED";
                
            }
        }

        public List<BankAccountDetails> filtrele(string str)
        {
            using (var Bankcontext = new BankContextDB())
            {
                return Bankcontext.BankAccountsDetails.ToList();
                 
            }
        }

        public BankAccountDetails GetAccountByİd(int id)
        {
            using (var Bankcontext = new BankContextDB())
            {
                return Bankcontext.BankAccountsDetails.Where(x => x.Id == id).SingleOrDefault();
            }
        }

        public List<BankAccountDetails> GetAllAccount()
        {
            using (var Bankcontext = new BankContextDB())
            {
                return Bankcontext.BankAccountsDetails.ToList();
            }
        }

        public List<BankAccountDetails> GetVip()
        {
            using (var Bankcontext = new BankContextDB())
            {
                return Bankcontext.BankAccountsDetails.ToList();
            }
        }

        public string patch(int id, int amount)
        {
            using (var Bankcontext = new BankContextDB())
            {
                var result =Bankcontext.BankAccountsDetails.Find(id);
                result.amount = amount != default ? amount : result.amount;
                Bankcontext.BankAccountsDetails.Update(result);
                Bankcontext.SaveChanges();
                return "patched";
            }
        }

        public List<BankAccountDetails> sirala()
        {
            using (var Bankcontext = new BankContextDB())
            {
                return Bankcontext.BankAccountsDetails.ToList();
            }
        }

        public string UpdateAccount(int id, BankAccountDetails NewAccount)
        {
            using (var Bankcontext = new BankContextDB())
            {
                Bankcontext.BankAccountsDetails.Update(NewAccount);
                return "updated";
            }
        }
    }
}
