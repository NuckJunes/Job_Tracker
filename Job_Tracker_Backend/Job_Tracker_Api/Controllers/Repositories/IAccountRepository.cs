using Job_Tracker_Api.Model.DTOs;
using Job_Tracker_Api.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Job_Tracker_Api.Controllers.Repositories
{
    public interface IAccountRepository
    {
        Task<ActionResult<string>> createAccount(User newUser);
        Task<ActionResult<User>> getUser(AccountDTO accountDTO);
        Task<ActionResult<User>> getUserById(string id);
    }
}