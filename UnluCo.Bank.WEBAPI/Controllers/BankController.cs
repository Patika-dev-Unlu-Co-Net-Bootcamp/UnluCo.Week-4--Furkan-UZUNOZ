using DataLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using UnluCo.Bank.BusinessLayer.Interface;
using UnluCo.Bank.DataLayer;

namespace UnluCo.Bank.WEBAPI.Controllers
{
    
    
    [Route("api/bank")]
    [ApiController]
    public class BankController : ControllerBase
    {
        BankAccount bank = new BankAccount();
        private readonly IBankService _bankService;
        
        public BankController(IBankService bankService)
        {
            _bankService = bankService;
            
        }
        
        [HttpGet("GetVip")]
        [Authorize(Roles =UserRoles.Admin)]
        public IActionResult GetVip()
        {
            try { return Ok(_bankService.GetVip()); }
 
            catch (Exception e) { return BadRequest(e.Message); }
            
        }
        [HttpGet]
        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult GetAllAccount()
        {
            try { return Ok(_bankService.GetAllAccount()); }

            catch (Exception e) { return BadRequest(e.Message); }

        }
        [HttpGet("{id}")]
        [Authorize(Roles = UserRoles.Manager)]
        public IActionResult GetAccountByİd(int id)
        {
            try { return Ok(_bankService.GetAccountByİd(id)); }

            catch (Exception e) { return BadRequest(e.Message); }
        }
        
        [HttpPost]
        [Authorize(Roles = UserRoles.User)]
        public IActionResult CreatedNewAccount([FromBody] BankAccountDetails Account)
        {
            try { return Ok(_bankService.CreatedNewAccount(Account)); }

            catch (Exception e) { return BadRequest(e.Message); }


        }
        [HttpPut("{id}")]
        [Authorize(Roles = UserRoles.User)]
        public IActionResult UpdateAccount(int id,[FromBody] BankAccountDetails NewAccount)
        {
            try { return Ok(_bankService.UpdateAccount(id,NewAccount)); }

            catch (Exception e) { return BadRequest(e.Message); }
        }
        [HttpDelete]
        [Authorize(Roles = UserRoles.User)]
        public IActionResult DeleteAccount(int id)
        {
            try { return Ok(_bankService.DeleteAccount(id)); }

            catch (Exception e) { return BadRequest(e.Message); }
        }
        [HttpGet("sirala")]
        [Authorize(Roles = UserRoles.Manager)]
        public IActionResult sirala()
        {
            try { return Ok(_bankService.sirala()); }

            catch (Exception e) { return BadRequest(e.Message); }
        }
        [HttpGet("kelimeye_göre_ad_filtrele")]
        [Authorize(Roles = UserRoles.Manager)]
        public IActionResult filtrele(string kelime)
        {
            try { return Ok(_bankService.filtrele(kelime)); }

            catch (Exception e) { return BadRequest(e.Message); }
        }
        [HttpPatch("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult patch(int id,int amount)
        {
            try { return Ok(_bankService.patch(id,amount)); }

            catch (Exception e) { return BadRequest(e.Message); }
        }
    }
}
