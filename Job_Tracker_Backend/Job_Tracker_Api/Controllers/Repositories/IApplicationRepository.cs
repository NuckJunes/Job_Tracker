using Job_Tracker_Api.Model.DTOs;
using Job_Tracker_Api.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Job_Tracker_Api.Controllers.Repositories
{
    public interface IApplicationRepository
    {
        Task<ActionResult<Application>> addApplication(Application newApp);
        Task<ActionResult<Application>> deleteApplication(string id);
        Task<ActionResult<Application>> getAppById(string id);
        Task<ActionResult<Application>> updateApplication(Application value);
    }
}