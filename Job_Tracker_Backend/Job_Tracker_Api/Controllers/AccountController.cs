using Job_Tracker_Api.Model.DTOs;
using Microsoft.AspNetCore.Mvc;
using Job_Tracker_Api.Controllers.Services;

namespace Job_Tracker_Api.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        public IAccountService accountService { get; set; }
        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost("/login")]
        public async Task<ActionResult<List<ApplicationReturnDTO>>> Login(AccountDTO accountDTO)
        {
            ActionResult<List<ApplicationReturnDTO>> result = await this.accountService.Login(accountDTO);
            if(result == null)
            {
                return Unauthorized();
            } else
            {
                return result;
            }
        }

        [HttpPost("/CreateAccount")]
        public async Task<string> CreateAccount(AccountDTO accountDTO)
        {
            return await this.accountService.CreateAccount(accountDTO);
        }
    }
}