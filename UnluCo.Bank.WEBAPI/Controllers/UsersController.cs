using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.Bank.BusinessLayer.Interface;
using UnluCo.Bank.DataLayer;


namespace UnluCo.Bank.WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ITaskOperations _taskOperations;
        public UsersController(ITaskOperations TaskOperations)
        {
            _taskOperations = TaskOperations ;
        }

        [HttpPost("login")]
        public IActionResult Login([FromForm] ForLogin Model)
        {
            
            var result = _taskOperations.Login(Model).Result;
                if (result.ForControl)
                {
                    return Ok(result);
                }
            return Unauthorized("Kullanıcı adı veya Şifre hatalı");
        }
        [HttpPost("Register")]
        public IActionResult Register([FromForm] ForRegister Model)
        {
            var result = _taskOperations.Register(Model).Result ;
            if (result.status)
                return Ok(result) ;
            
            return StatusCode(500, result) ;
        }
        [HttpPost("Register-Admin")]
        public IActionResult RegisterForAdmin([FromForm] ForRegister Model)
        {
            var result = _taskOperations.RegisterForAdmin(Model).Result;
            if (result.status)
                return Ok(result);

            return StatusCode(500,result);
        }
        [HttpPost("Register-Manager")]
        public IActionResult RegisterForManager([FromForm] ForRegister Model)
        {
            var result = _taskOperations.RegisterForManager(Model).Result;
            if (result.status)
                return Ok(result);

            return StatusCode(500,result);
        }



    }
}
