using Job_Tracker_Api.Data;

namespace Job_Tracker_Api.Controllers.Repositories.RepositoriesImpl
{
    public class AccountRepositoryImpl : IAccountRepository
    {
        public ApplicationDbContext appDbContext;

        public AccountRepositoryImpl(ApplicationDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
    }
}