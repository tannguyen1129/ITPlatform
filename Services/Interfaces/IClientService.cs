using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessObjects;
using Repositories.Interfaces;
using Services.Interfaces;


namespace Services.Interfaces
{
    public interface IClientService
    {
        Task<List<Client>> GetAllClientsAsync();
        Task<Client?> GetClientByIdAsync(string clientId);
        Task CreateClientAsync(Client client);
        Task UpdateClientAsync(Client client);
        Task DeleteClientAsync(string clientId);
        Task<Client?> GetClientByAccountIdAsync(string accountId);
        Task<List<Client>> GetClientsByFieldAsync(string field);
    }
}
