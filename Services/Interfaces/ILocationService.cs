using BusinessObjects;

namespace Services.Interfaces
{
    public interface ILocationService
    {
        Task<List<Location>> GetAllAsync();
        Task<Location?> GetByIdAsync(string id);
        Task CreateAsync(Location location);
        Task UpdateAsync(Location location);
        Task DeleteAsync(string id);
    }
}
