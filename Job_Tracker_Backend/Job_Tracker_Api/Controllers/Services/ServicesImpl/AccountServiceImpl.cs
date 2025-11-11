using Job_Tracker_Api.Model.DTOs;
using Job_Tracker_Api.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Job_Tracker_Api.Controllers.Repositories;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Net;
using Microsoft.AspNetCore.Identity;

namespace Job_Tracker_Api.Controllers.Services.ServicesImpl
{
    public class AccountServiceImpl : IAccountService
    {
        public IAccountRepository accountRepository;
        private readonly IPasswordHasher<User> passwordHasher;

        public AccountServiceImpl(IAccountRepository accountRepository, IPasswordHasher<User> passwordHasher)
        {
            this.accountRepository = accountRepository;
            this.passwordHasher = passwordHasher;
        }

        public async Task<IdentityResult> CreateAccount(AccountDTO accountDTO)
        {
            //Check if the account email/username already exists, if so, return
            User newUser = new User();
            newUser.convertAccountDTOtoUser(accountDTO);
            return await accountRepository.createAccount(newUser, accountDTO.Password);            
        }

        public async Task<ActionResult<List<ApplicationReturnDTO>>> Login(AccountDTO accountDTO)
        {
            if (accountDTO.Email == null) //If I decide to not require email to login
            {
                accountDTO.Email = "";
            }

            if (accountDTO.UserName == null) //If I decide to not require username to login
            {
                accountDTO.UserName = "";
            }
            
            ActionResult<User> result = await accountRepository.getUser(accountDTO);
            ActionResult<List<ApplicationReturnDTO>> result2 = new ActionResult<List<ApplicationReturnDTO>>(new List<ApplicationReturnDTO>());
            if (result.Value != null)
            {
                PasswordVerificationResult passwordResult = passwordHasher.VerifyHashedPassword(result.Value, result.Value.PasswordHash, accountDTO.Password);
                if (passwordResult != PasswordVerificationResult.Success)
                {
                    return null;
                }
                
                //Successful login, convert applications to applicationreturnDtos
                if(result.Value.Applications != null)
                {
                    foreach (var app in result.Value.Applications)
                    {
                        ApplicationReturnDTO newReturn = new ApplicationReturnDTO();
                        newReturn.ApplicationToDTO(app);
                        result2.Value.Add(newReturn);
                    }
                }
                return result2;
            }
            else
            {
                //Unsuccessful login/bad credentials
                return null;
            }
        }
        
        private string SaltAndHash(string password, User user)
        {
            return passwordHasher.HashPassword(user, password);
        }
    }
}