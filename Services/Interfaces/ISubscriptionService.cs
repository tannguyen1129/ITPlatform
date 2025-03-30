using BusinessObjects;

namespace Services.Interfaces
{
    public interface ISubscriptionService
    {
        Task<List<Subscription>> GetAllAsync();
        Task<Subscription?> GetByIdAsync(string id);
        Task CreateAsync(Subscription subscription);
        Task UpdateAsync(Subscription subscription);
        Task DeleteAsync(string id);
    }
}
