using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluCo.Bank.DataAccessLayer;
using UnluCo.Bank.DataLayer;
using Microsoft.IdentityModel.Tokens;
using static UnluCo.Bank.BusinessLayer.Concrete.UserService;

namespace UnluCo.Bank.BusinessLayer.Interface
{
    public interface IUserService 
    {
       public  Token Login(string UserName,IList<string> Roles);

    }
}
