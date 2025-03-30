using BusinessObjects;

namespace Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Task<List<Account>> GetAllAsync();
        Task<Account?> GetByIdAsync(string id);
        Task<Account?> GetByEmailAsync(string email);
        Task InsertAsync(Account account);
        Task UpdateAsync(Account account);
        Task DeleteAsync(string id);
    }
}
