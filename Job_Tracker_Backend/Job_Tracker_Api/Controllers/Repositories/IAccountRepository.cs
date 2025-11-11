using Job_Tracker_Api.Model.DTOs;
using Job_Tracker_Api.Model.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Job_Tracker_Api.Controllers.Repositories
{
    public interface IAccountRepository
    {
        Task<IdentityResult> createAccount(User newUser, string password);
        Task<ActionResult<User>> getUser(AccountDTO accountDTO);
        Task<ActionResult<User>> getUserById(string id);
    }
}