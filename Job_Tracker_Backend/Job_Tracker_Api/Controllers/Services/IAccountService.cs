using Job_Tracker_Api.Model.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Job_Tracker_Api.Controllers.Services
{
    public interface IAccountService
    {
        Task<string> CreateAccount(AccountDTO accountDTO);
        Task<ActionResult<List<ApplicationReturnDTO>>> Login(LoginDTO loginDTO);
    }
}