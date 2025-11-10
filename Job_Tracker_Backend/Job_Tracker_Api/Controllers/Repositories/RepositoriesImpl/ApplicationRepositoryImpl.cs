using Job_Tracker_Api.Controllers.Services.ServicesImpl;
using Job_Tracker_Api.Data;
using Job_Tracker_Api.Model.DTOs;
using Job_Tracker_Api.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Job_Tracker_Api.Controllers.Repositories.RepositoriesImpl
{
    public class ApplicationRepositoryImpl : IApplicationRepository
    {
        public ApplicationDbContext appDbContext;
        public ApplicationRepositoryImpl(ApplicationDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<ActionResult<Application>> addApplication(Application newApp)
        {
            appDbContext.Applications.Add(newApp);
            await appDbContext.SaveChangesAsync();
            return newApp;
        }

        public async Task<ActionResult<Application>> deleteApplication(string id)
        {
            Application appToDelete = appDbContext.Applications.FirstOrDefault(a => a.Id.Equals(id));
            appDbContext.Applications.Remove(appToDelete);
            await appDbContext.SaveChangesAsync();
            return new ActionResult<Application>(appToDelete);
        }

        public async Task<ActionResult<Application>> getAppById(string id)
        {
            return await this.appDbContext.Applications.FirstOrDefaultAsync(a => a.Id.Equals(id));
        }

        public async Task<ActionResult<Application>> updateApplication(Application value)
        {
            appDbContext.Applications.Attach(value);
            appDbContext.Entry(value).State = EntityState.Modified;
            return new ActionResult<Application>(value);
        }
    }
}