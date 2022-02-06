using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnluCo.Bank.BusinessLayer.Rules
{
    public class İsUsefullForName : IRules
    {
       
        bool IRules.isValid(BankAccountDetails Account)
        {
            
            var isUpper = Account.name.Any(e => Char.IsUpper(e));
            var isLower = Account.name.Any(Char.IsLower);
            var isDigit = Account.name.Length;
            var isbiggerthentwenty = true ;
            if (isDigit>20)
            {
                isbiggerthentwenty = false;
            }
            else { isbiggerthentwenty = true; }
            if(isUpper==false || isLower ==false || isbiggerthentwenty == false)
            {
                return false;
            }
            return true;
        }
        
    }
}
