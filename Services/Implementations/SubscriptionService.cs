using BusinessObjects;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implementations
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _repository;

        public SubscriptionService(ISubscriptionRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Subscription>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<Subscription?> GetByIdAsync(string id) => await _repository.GetByIdAsync(id);

        public async Task CreateAsync(Subscription subscription) => await _repository.InsertAsync(subscription);

        public async Task UpdateAsync(Subscription subscription) => await _repository.UpdateAsync(subscription);

        public async Task DeleteAsync(string id) => await _repository.DeleteAsync(id);
    }
}
