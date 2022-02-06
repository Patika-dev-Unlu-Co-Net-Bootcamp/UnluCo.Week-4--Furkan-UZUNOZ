using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluCo.Bank.BusinessLayer.Interface;
using UnluCo.Bank.DataLayer;
using static UnluCo.Bank.BusinessLayer.Concrete.UserService;

namespace UnluCo.Bank.BusinessLayer.Concrete
{
    public class TaskOperations : ITaskOperations
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserService _userService;

        public TaskOperations(UserManager<AppUser> UserManager, RoleManager<IdentityRole> RoleManager,
            IUserService userService)
        {
            _userManager = UserManager;
            _roleManager = RoleManager;
            _userService = userService;
        }
        public async Task<Token> Login(ForLogin model)
        {
            Token token = new Token();
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Pass))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var ResultToken = _userService.Login(model.Username, userRoles);

                return ResultToken;
            }
            return token;
        }

        public async Task<ReturnInfo> Register(ForRegister model)
        {
            var userExists = await _userManager.FindByNameAsync(model.UserName);
            if (userExists != null)
                return new ReturnInfo { message = "User already exists", status = false }  ;
            AppUser user = new AppUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName,
                MotherOldLastname = model.MotherOldLastname 
            };
            var result = await _userManager.CreateAsync(user, model.Pass);
            if (!result.Succeeded)
                return new ReturnInfo { message= "Unexpected fail",status=false };
            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));
            if (!await _roleManager.RoleExistsAsync(UserRoles.Manager))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Manager));

            if (await _roleManager.RoleExistsAsync(UserRoles.User))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.User);
            }

            return new ReturnInfo { message = "User created Succesfuly", status = true };

            
        }

        public async Task<ReturnInfo> RegisterForAdmin(ForRegister model)
        {
            var userExists = await _userManager.FindByNameAsync(model.UserName);
            if (userExists != null)
                return new ReturnInfo { message = "User already exists", status = false };
            AppUser user = new AppUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName,
                MotherOldLastname = model.MotherOldLastname
            };
            var result = await _userManager.CreateAsync(user, model.Pass);
            if (!result.Succeeded)
                return new ReturnInfo { message = "Unexpected fail", status = false };
            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));
            if (!await _roleManager.RoleExistsAsync(UserRoles.Manager))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Manager));

            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Admin);
            }

            return new ReturnInfo { message = "User created Succesfuly", status = true };

        }

        public async Task<ReturnInfo> RegisterForManager(ForRegister model)
        {
            var userExists = await _userManager.FindByNameAsync(model.UserName);
            if (userExists != null)
                return new ReturnInfo { message = "User already exists", status = false };
            AppUser user = new AppUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName,
                MotherOldLastname = model.MotherOldLastname
            };
            var result = await _userManager.CreateAsync(user, model.Pass);
            if (!result.Succeeded)
                return new ReturnInfo { message = "Unexpected fail", status = false };
            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));
            if (!await _roleManager.RoleExistsAsync(UserRoles.Manager))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Manager));

            if (await _roleManager.RoleExistsAsync(UserRoles.Manager))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Manager);
            }

            return new ReturnInfo { message = "User created Succesfuly", status = true };
        }
    }
}
