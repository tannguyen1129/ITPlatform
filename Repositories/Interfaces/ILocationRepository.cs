using BusinessObjects;

namespace Repositories.Interfaces
{
    public interface ILocationRepository
    {
        Task<List<Location>> GetAllAsync();
        Task<Location?> GetByIdAsync(string id);
        Task InsertAsync(Location location);
        Task UpdateAsync(Location location);
        Task DeleteAsync(string id);
    }
}
