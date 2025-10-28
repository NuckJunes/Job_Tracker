using Job_Tracker_Api.Model.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Job_Tracker_Api.Controllers.Services
{
    public interface IAccountService
    {
        Task<ActionResult<List<ApplicationReturnDTO>>> Login(LoginDTO loginDTO);
    }
}