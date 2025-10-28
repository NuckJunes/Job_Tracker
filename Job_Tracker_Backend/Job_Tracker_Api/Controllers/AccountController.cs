using Job_Tracker_Api.Model.DTOs;
using Microsoft.AspNetCore.Mvc;
using Job_Tracker_Api.Controllers.Services;

namespace Job_Tracker_Api.Controllers
{
    public class AccountController : ControllerBase
    {
        public IAccountService accountService { get; set; }
        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost("/login")]
        public async Task<ActionResult<List<ApplicationReturnDTO>>> Login(LoginDTO loginDTO)
        {
            return await this.accountService.Login(loginDTO);
        }

        [HttpPost("/CreateAccount")]
        public async Task<string> CreateAccount(AccountDTO accountDTO)
        {
            return await this.accountService.CreateAccount(accountDTO);
        }
    }
}