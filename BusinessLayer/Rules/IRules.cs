using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnluCo.Bank.BusinessLayer.Rules
{
    public interface IRules
    {
      
        bool isValid(BankAccountDetails Account);
    }
}
