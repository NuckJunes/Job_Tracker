using Job_Tracker_Api.Model.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Job_Tracker_Api.Controllers.Services
{
    public interface IApplicationService
    {
        Task<ActionResult<ApplicationReturnDTO>> addApplication(ApplicationDTO applicationDTO, string id);
        Task<ActionResult<ApplicationReturnDTO>> deleteApplication(string id);
        Task<ActionResult<ApplicationReturnDTO>> editApplication(ApplicationDTO applicationDTO, string id);
    }
}