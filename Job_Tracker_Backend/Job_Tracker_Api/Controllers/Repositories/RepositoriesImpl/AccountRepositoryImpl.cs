using Job_Tracker_Api.Data;
using Job_Tracker_Api.Model.DTOs;
using Job_Tracker_Api.Model.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Job_Tracker_Api.Controllers.Repositories.RepositoriesImpl
{
    public class AccountRepositoryImpl : IAccountRepository
    {
        public ApplicationDbContext appDbContext; 
        public readonly UserManager<User> userManager;

        public AccountRepositoryImpl(ApplicationDbContext appDbContext, UserManager<User> userManager)
        {
            this.appDbContext = appDbContext;
            this.userManager = userManager;
        }

        public async Task<IdentityResult> createAccount(User newUser, string password)
        {
            return await userManager.CreateAsync(newUser, password);
        }

        public async Task<ActionResult<User>> getUser(AccountDTO accountDTO)
        {
            return await appDbContext.Users.FirstOrDefaultAsync(u => (u.UserName == accountDTO.UserName && u.Email == accountDTO.Email));
        }

        public async Task<ActionResult<User>> getUserById(string id)
        {
            return await appDbContext.Users.FirstOrDefaultAsync(u => u.Id.Equals(id));
        }
    }
}