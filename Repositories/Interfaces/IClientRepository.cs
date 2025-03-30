using BusinessObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IClientRepository
    {
        Task<List<Client>> GetAllAsync();
        Task<Client?> GetByIdAsync(string clientId);
        Task InsertAsync(Client client);
        Task UpdateAsync(Client client);
        Task DeleteAsync(string clientId);
        Task<Client?> GetByAccountIdAsync(string accountId);
        Task<List<Client>> GetByFieldAsync(string field);
    }
}
