using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UnluCo.Bank.BusinessLayer.Interface;
using UnluCo.Bank.DataLayer;

namespace UnluCo.Bank.BusinessLayer.Concrete
{
    public class UserService : IUserService
    {
        public Token token { get; set; }
        
        private readonly IConfiguration _configuration;
        public UserService(IConfiguration configuration)

        {
            _configuration = configuration;
        }
        public class Token
        {
            public string AccessToken { get; set; }
            public string RefreshToken { get; set; }

            public bool ForControl { get; set; } = false;
        }
        public Token Login(string UserName,IList<string> Roles)
        {
                Token AccesToken = new Token();
                var authClaims = new List<Claim> {
                        new Claim(ClaimTypes.Name , UserName),
                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                    };
                foreach (var Role in Roles)
                {
                      authClaims.Add(new Claim(ClaimTypes.Role, Role));
                }
                

                var authSignKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(2),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSignKey, SecurityAlgorithms.HmacSha256)
                    );
            
            AccesToken.AccessToken = new JwtSecurityTokenHandler().WriteToken(token) ;
            AccesToken.ForControl = true;
            return AccesToken;
        }
           
    }
}

        

