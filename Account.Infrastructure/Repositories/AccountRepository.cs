using AccountCore.Entities;
using AccountCore.Repositories;

namespace AccountInfrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public Task CreateAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAccount(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Account>> GetAllAccounts()
        {
            throw new NotImplementedException();
        }

        public Task<Account> GetOneAccount(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAccount(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
