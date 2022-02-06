using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluCo.Bank.DataAccessLayer.inteface
{
    public interface IBankRepository
    {
        List<BankAccountDetails> GetVip();

        List<BankAccountDetails> GetAllAccount();

        BankAccountDetails GetAccountByİd(int id);

        BankAccountDetails CreatedNewAccount(BankAccountDetails Account);

        string UpdateAccount(int id, BankAccountDetails NewAccount);

        string DeleteAccount(int id);

        List<BankAccountDetails> sirala();

        List<BankAccountDetails> filtrele(string str);

        string patch(int id, int amount);
    }
}
