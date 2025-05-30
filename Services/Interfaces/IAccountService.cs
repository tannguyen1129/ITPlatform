using BusinessObjects;

namespace Services.Interfaces
{
    public interface IAccountService
    {
        Task<List<Account>> GetAllAsync();
        Task<Account?> GetByIdAsync(string id);
        Task<Account?> GetByEmailAsync(string email);
        Task CreateAsync(Account account);
        Task UpdateAsync(Account account);
        Task DeleteAsync(string id);
    }
}
