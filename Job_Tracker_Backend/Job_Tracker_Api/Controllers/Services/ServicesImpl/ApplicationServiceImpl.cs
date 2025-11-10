using Job_Tracker_Api.Controllers.Repositories;
using Job_Tracker_Api.Model.DTOs;
using Job_Tracker_Api.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Job_Tracker_Api.Controllers.Services.ServicesImpl
{
    public class ApplicationServiceImpl : IApplicationService
    {
        public IApplicationRepository applicationRepository;
        public IAccountRepository accountRepository;
        public ApplicationServiceImpl(IApplicationRepository applicationRepository, IAccountRepository accountRepository)
        {
            this.applicationRepository = applicationRepository;
            this.accountRepository = accountRepository;
        }

        public async Task<ActionResult<ApplicationReturnDTO>> addApplication(ApplicationDTO applicationDTO, string id)
        {
            Application newApp = new Application();
            ActionResult<User> existingUser = await accountRepository.getUserById(id);
            if(existingUser.Value == null)
            {
                //User doesn't exist, THIS SHOULD NEVER HAPPEN!
                return new ActionResult<ApplicationReturnDTO>(new ApplicationReturnDTO());
            }
            newApp.convertApplicationDTOtoApplication(applicationDTO, existingUser.Value);
            ActionResult<Application> appReturned = await applicationRepository.addApplication(newApp);
            ApplicationReturnDTO appToReturn = new ApplicationReturnDTO();
            appToReturn.ApplicationToDTO(appReturned.Value);
            return new ActionResult<ApplicationReturnDTO>(appToReturn);
        }

        public async Task<ActionResult<ApplicationReturnDTO>> deleteApplication(string id)
        {
            ActionResult<Application> deletedApp = await applicationRepository.deleteApplication(id);
            ApplicationReturnDTO a = new ApplicationReturnDTO();
            a.ApplicationToDTO(deletedApp.Value);
            return new ActionResult<ApplicationReturnDTO>(a);
        }

        public async Task<ActionResult<ApplicationReturnDTO>> editApplication(ApplicationDTO applicationDTO, string id)
        {
            ActionResult<Application> existingApp = await applicationRepository.getAppById(id);
            existingApp.Value.updateApplication(applicationDTO);
            ActionResult<Application> updatedApp = await applicationRepository.updateApplication(existingApp.Value);
            ApplicationReturnDTO finalApp = new ApplicationReturnDTO();
            finalApp.ApplicationToDTO(updatedApp.Value);
            return new ActionResult<ApplicationReturnDTO>(finalApp);
        }
    }
}