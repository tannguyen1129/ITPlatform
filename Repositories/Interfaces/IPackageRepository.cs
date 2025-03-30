using BusinessObjects;

namespace Repositories.Interfaces
{
    public interface IPackageRepository
    {
        Task<List<Package>> GetAllAsync();
        Task<Package?> GetByIdAsync(string id);
        Task InsertAsync(Package package);
        Task UpdateAsync(Package package);
        Task DeleteAsync(string id);
    }
}
