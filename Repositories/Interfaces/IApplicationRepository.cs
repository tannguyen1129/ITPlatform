using BusinessObjects;

namespace Repositories.Interfaces
{
    public interface IApplicationRepository
    {
        Task<List<Application>> GetAllAsync();
        Task<Application?> GetByIdAsync(string id);
        Task InsertAsync(Application application);
        Task UpdateAsync(Application application);
        Task DeleteAsync(string id);
    }
}
