using BusinessObjects;

namespace Repositories.Interfaces
{
    public interface ISubscriptionRepository
    {
        Task<List<Subscription>> GetAllAsync();
        Task<Subscription?> GetByIdAsync(string id);
        Task InsertAsync(Subscription subscription);
        Task UpdateAsync(Subscription subscription);
        Task DeleteAsync(string id);
    }
}
