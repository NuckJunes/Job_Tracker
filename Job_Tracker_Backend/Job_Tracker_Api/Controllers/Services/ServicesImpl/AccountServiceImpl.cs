using Job_Tracker_Api.Model.DTOs;
using Job_Tracker_Api.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Job_Tracker_Api.Controllers.Repositories;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Job_Tracker_Api.Controllers.Services.ServicesImpl
{
    public class AccountServiceImpl : IAccountService
    {
        public IAccountRepository accountRepository;

        public AccountServiceImpl(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public async Task<string> CreateAccount(AccountDTO accountDTO)
        {
            //Check if the account email/username already exists, if so, return
            ActionResult<User> existingUserResult = await accountRepository.getUser(accountDTO);
            if(existingUserResult.Value == null)
            { //No existing user, create a new account
                User newUser = new User();
                newUser.convertAccountDTOtoUser(accountDTO, SaltAndHash(accountDTO.Password));
                ActionResult<string> createResult = await accountRepository.createAccount(newUser);
                return "Success!";
            } else
            {//A user already exists with that username or email
                if(existingUserResult.Value.Email == accountDTO.Email)
                {
                    return "Email already in use!";
                } else if(existingUserResult.Value.Username == accountDTO.Username)
                {
                    return "Username already in use!";
                } else
                {
                    return "Unknown Error!";
                }
            }
            
        }

        public async Task<ActionResult<List<ApplicationReturnDTO>>> Login(LoginDTO loginDTO)
        {
            ActionResult<User> result = await accountRepository.getUser(loginDTO);
            ActionResult<List<ApplicationReturnDTO>> result2 = new ActionResult<List<ApplicationReturnDTO>>(new List<ApplicationReturnDTO>());
            if (result.Value != null)
            {
                //Successful login, convert applications to applicationreturnDtos
                foreach (var app in result.Value.Applications)
                {
                    ApplicationReturnDTO newReturn = new ApplicationReturnDTO();
                    newReturn.ApplicationToDTO(app);
                    result2.Value.Add(newReturn);
                }
                return result2;
            }
            else
            {
                //Unsuccessful login/bad credentials
                return result2;
            }
        }
        
        private string SaltAndHash(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            return hashed;
        }
    }
}