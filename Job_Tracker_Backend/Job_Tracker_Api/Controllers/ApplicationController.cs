using Microsoft.AspNetCore.Mvc;
using Job_Tracker_Api.Controllers.Services;

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
    }
}