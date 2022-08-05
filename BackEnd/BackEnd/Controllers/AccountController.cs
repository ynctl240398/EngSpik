using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BackEnd.EngSpik;
using BackEnd.services;
using BackEnd.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly AccountService _service;

        public AccountController(EngSpikDbContext app)
        {
            _service = new AccountService(app);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel<string>>> Login([FromBody] AccountModel.LoginModel login)
        {
            ResponseModel<string> res = await _service.LoginAsync(login);
            return res;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel<Account>>> Register([FromBody] AccountModel.RegisterModel register)
        {
            ResponseModel<Account> res = await _service.RegisterAsync(register);
            return res;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel<string>>> ForgotPassword(AccountModel.ForgotPasswordModel forgot)
        {
            ResponseModel<string> res = await _service.ForgotPasswordAsync(forgot);
            return res;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel<Account>>> ChangePassword(AccountModel.ResetPasswordModel reset)
        {
            ResponseModel<Account> res = await _service.ChangePassword(reset);
            return res;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
