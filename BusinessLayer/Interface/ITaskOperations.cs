using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluCo.Bank.DataLayer;
using static UnluCo.Bank.BusinessLayer.Concrete.UserService;

namespace UnluCo.Bank.BusinessLayer.Interface
{
    public interface ITaskOperations
    {
        public Task<Token> Login(ForLogin model);

        public Task<ReturnInfo> Register(ForRegister model);

        public Task<ReturnInfo> RegisterForAdmin(ForRegister model);

        public Task<ReturnInfo> RegisterForManager(ForRegister model);
    }
}
