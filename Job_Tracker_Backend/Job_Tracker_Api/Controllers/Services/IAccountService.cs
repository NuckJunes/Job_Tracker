using Job_Tracker_Api.Model.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Job_Tracker_Api.Controllers.Services
{
    public interface IAccountService
    {
        Task<IdentityResult> CreateAccount(AccountDTO accountDTO);
        Task<ActionResult<List<ApplicationReturnDTO>>> Login(AccountDTO accountDTO);
    }
}