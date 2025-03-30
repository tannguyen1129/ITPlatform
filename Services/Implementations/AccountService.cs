using BusinessObjects;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;

        public AccountService(IAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Account>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Account?> GetByIdAsync(string id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Account?> GetByEmailAsync(string email)
        {
            return await _repository.GetByEmailAsync(email);
        }

        public async Task CreateAsync(Account account)
        {
            await _repository.InsertAsync(account);
        }

        public async Task UpdateAsync(Account account)
        {
            await _repository.UpdateAsync(account);
        }

        public async Task DeleteAsync(string id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
