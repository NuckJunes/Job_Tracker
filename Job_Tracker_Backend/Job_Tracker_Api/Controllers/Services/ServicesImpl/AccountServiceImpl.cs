using Job_Tracker_Api.Model.DTOs;
using Job_Tracker_Api.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Job_Tracker_Api.Controllers.Repositories;

namespace Job_Tracker_Api.Controllers.Services.ServicesImpl
{
    public class AccountServiceImpl : IAccountService
    {
        public IAccountRepository accountRepository;

        public AccountServiceImpl(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public async Task<ActionResult<AccountDTO>> CreateAccount(AccountDTO accountDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<List<ApplicationReturnDTO>>> Login(LoginDTO loginDTO)
        {
            ActionResult<User> result = await accountRepository.Login(loginDTO);
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
        
        public async string SaltAndHash(string password)
        {
            
        }
    }
}