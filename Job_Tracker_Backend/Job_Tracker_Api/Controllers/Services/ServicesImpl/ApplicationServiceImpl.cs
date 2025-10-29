using Job_Tracker_Api.Controllers.Repositories;
using Job_Tracker_Api.Model.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Job_Tracker_Api.Controllers.Services.ServicesImpl
{
    public class ApplicationServiceImpl : IApplicationService
    {
        public IApplicationRepository applicationRepository;
        public ApplicationServiceImpl(IApplicationRepository applicationRepository)
        {
            this.applicationRepository = applicationRepository;
        }

        public Task<ActionResult<ApplicationReturnDTO>> addApplication(ApplicationDTO applicationDTO, int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<ApplicationReturnDTO>> deleteApplication(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<ApplicationReturnDTO>> editApplication(ApplicationDTO applicationDTO, int id)
        {
            throw new NotImplementedException();
        }
    }
}