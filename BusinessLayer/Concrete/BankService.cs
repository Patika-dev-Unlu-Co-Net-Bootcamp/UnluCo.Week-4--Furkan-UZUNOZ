using UnluCo.Bank.BusinessLayer.Interface;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnluCo.Bank.DataAccessLayer.inteface;
using UnluCo.Bank.BusinessLayer.Extension;
using UnluCo.Bank.BusinessLayer.Rules;

namespace UnluCo.Bank.BusinessLayer.Concrete
{
    public class BankService : IBankService
    {
        private readonly IBankRepository _BankRepository;
        private readonly IRules _rules;
        public BankService (IBankRepository bankRepository,IRules rules)
        {
            _rules = rules;
            _BankRepository = bankRepository;
        }
        public BankAccountDetails CreatedNewAccount(BankAccountDetails Account)
        {
            if (_rules.isValid(Account))
            {
                return _BankRepository.CreatedNewAccount(Account);
            }
            return new BankAccountDetails() ;
        }

        public string DeleteAccount(int id)
        {
            return _BankRepository.DeleteAccount(id);
        }

        public List<BankAccountDetails> filtrele(string str)
        {
            List<BankAccountDetails> MaybeEmpty = new List<BankAccountDetails>();
            var result =_BankRepository.filtrele(str).Where(e=>e.name.Contains(str)).ToList() ;
            if (result is null)
            {
                return MaybeEmpty;
            }
            return result ;
        }

        public BankAccountDetails GetAccountByİd(int id)
        {
            BankAccountDetails MaybeEmpty = new BankAccountDetails() ;
            
            var result = _BankRepository.GetAccountByİd(id);
            if (result is null)
            {
                return MaybeEmpty;
            }
            return result;
            
        }

        public List<BankAccountDetails> GetAllAccount()
        {
            return _BankRepository.GetAllAccount();
        }

        public List<BankAccountDetails> GetVip()
        {
            return _BankRepository.GetVip().Where(e => e.amount.isAccVip()).ToList();
        }

        public string patch(int id, int amount)
        {
            try
            {
                return _BankRepository.patch(id, amount); 
            }
            catch (Exception e)
            {
                return "error " + e.Message;
            } 
        }

        public List<BankAccountDetails> sirala()
        {
            return _BankRepository.sirala().OrderBy(e=>e.Id).ToList();
        }

        public string UpdateAccount(int id, BankAccountDetails NewAccount)
        {
            try
            {
                return _BankRepository.UpdateAccount(id, NewAccount);
            }
            catch (Exception e)
            {
                return "error " + e.Message;
                
            }
        }
    }
}
