using BusinessObjects;

namespace Services.Interfaces
{
    public interface IPackageService
    {
        Task<List<Package>> GetAllAsync();
        Task<Package?> GetByIdAsync(string id);
        Task CreateAsync(Package package);
        Task UpdateAsync(Package package);
        Task DeleteAsync(string id);
    }
}
