using Job_Tracker_Api.Model.DTOs;
using Microsoft.AspNetCore.Mvc;
using Job_Tracker_Api.Controllers.Services;
using Microsoft.AspNetCore.Identity;

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
        public async Task<IdentityResult> CreateAccount(AccountDTO accountDTO)
        {
            return await this.accountService.CreateAccount(accountDTO);
        }
    }
}