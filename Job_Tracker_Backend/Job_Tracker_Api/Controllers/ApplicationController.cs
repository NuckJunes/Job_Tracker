using Microsoft.AspNetCore.Mvc;
using Job_Tracker_Api.Controllers.Services;
using Job_Tracker_Api.Model.DTOs;

namespace Job_Tracker_Api.Controllers
{
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        public IApplicationService applicationService;
        public ApplicationController(IApplicationService applicationService)
        {
            this.applicationService = applicationService;
        }

        [HttpPost("/Application/{id}")]
        public async Task<ActionResult<ApplicationReturnDTO>> addApplication(ApplicationDTO applicationDTO, string id)
        {
            return await applicationService.addApplication(applicationDTO, id);
        }

        [HttpPatch("/Application/{id}")]
        public async Task<ActionResult<ApplicationReturnDTO>> editApplication(ApplicationDTO applicationDTO, string id)
        {
            return await applicationService.editApplication(applicationDTO, id);
        }

        [HttpDelete("/Application/{id}")]
        public async Task<ActionResult<ApplicationReturnDTO>> deleteApplication(string id)
        {
            return await applicationService.deleteApplication(id);
        }
    }
}