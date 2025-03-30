using BusinessObjects;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implementations
{
    public class PackageService : IPackageService
    {
        private readonly IPackageRepository _repo;

        public PackageService(IPackageRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Package>> GetAllAsync() => await _repo.GetAllAsync();

        public async Task<Package?> GetByIdAsync(string id) => await _repo.GetByIdAsync(id);

        public async Task CreateAsync(Package package) => await _repo.InsertAsync(package);

        public async Task UpdateAsync(Package package) => await _repo.UpdateAsync(package);

        public async Task DeleteAsync(string id) => await _repo.DeleteAsync(id);
    }
}
