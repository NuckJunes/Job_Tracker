using Job_Tracker_Api.Data;
using Job_Tracker_Api.Model.DTOs;
using Job_Tracker_Api.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Job_Tracker_Api.Controllers.Repositories.RepositoriesImpl
{
    public class AccountRepositoryImpl : IAccountRepository
    {
        public ApplicationDbContext appDbContext;

        public AccountRepositoryImpl(ApplicationDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<ActionResult<string>> createAccount(User newUser)
        {
            User found = await appDbContext.Users.FirstOrDefaultAsync(u => (u.UserName == newUser.UserName || u.Email == newUser.Email));
            if(found == null)
            {
                appDbContext.Users.Add(newUser);
                await appDbContext.SaveChangesAsync();
                return new ActionResult<string>("Success!");
            } else
            {
                if (found.Email == newUser.Email)
                {
                    return new ActionResult<string>("Email");
                } else
                {
                    return new ActionResult<string>("Username");
                }
            }
        }

        public async Task<ActionResult<User>> getUser(AccountDTO accountDTO)
        {
            return await appDbContext.Users.FirstOrDefaultAsync(u => (u.UserName == accountDTO.Username && u.Email == accountDTO.Email));
        }

        public async Task<ActionResult<User>> getUserById(string id)
        {
            return await appDbContext.Users.FirstOrDefaultAsync(u => u.Id.Equals(id));
        }
    }
}