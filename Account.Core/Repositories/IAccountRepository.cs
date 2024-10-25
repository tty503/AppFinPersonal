using AccountCore.Entities;
namespace AccountCore.Repositories
{
        // Not used
    public interface IAccountRepository
    {
        Task<Account> GetOneAccount(Guid id);
        Task<List<Account>> GetAllAccounts();

        Task CreateAccount(Account account);
        Task UpdateAccount(Account account);
        
        Task DeleteAccount(Guid id);
    }
}
