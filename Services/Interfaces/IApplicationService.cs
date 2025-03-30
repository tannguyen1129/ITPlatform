using BusinessObjects;

namespace Services.Interfaces
{
    public interface IApplicationService
    {
        Task<List<Application>> GetAllAsync();
        Task<Application?> GetByIdAsync(string id);
        Task CreateAsync(Application application);
        Task UpdateAsync(Application application);
        Task DeleteAsync(string id);
    }
}
