using BusinessObjects;
using Repositories.Interfaces;
using Services.Interfaces; 
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<List<Client>> GetAllClientsAsync() =>
            await _clientRepository.GetAllAsync();

        public async Task<Client?> GetClientByIdAsync(string clientId) =>
            await _clientRepository.GetByIdAsync(clientId);

        public async Task CreateClientAsync(Client client) =>
            await _clientRepository.InsertAsync(client);

        public async Task UpdateClientAsync(Client client) =>
            await _clientRepository.UpdateAsync(client);

        public async Task DeleteClientAsync(string clientId) =>
            await _clientRepository.DeleteAsync(clientId);

        public async Task<Client?> GetClientByAccountIdAsync(string accountId) =>
            await _clientRepository.GetByAccountIdAsync(accountId);

        public async Task<List<Client>> GetClientsByFieldAsync(string field) =>
            await _clientRepository.GetByFieldAsync(field);
    }
}
