using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnluCo.Bank.BusinessLayer.Extension
{
    public static class İsAccountVip
    {
        public static bool isAccVip(this int amount)
        {
            if (amount >= 2000)
            {
                return true;
            }
            return false;
        }
    }
}
