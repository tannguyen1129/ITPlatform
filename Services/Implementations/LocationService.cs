using BusinessObjects;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implementations
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _repository;

        public LocationService(ILocationRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Location>> GetAllAsync() => _repository.GetAllAsync();
        public Task<Location?> GetByIdAsync(string id) => _repository.GetByIdAsync(id);
        public Task CreateAsync(Location location) => _repository.InsertAsync(location);
        public Task UpdateAsync(Location location) => _repository.UpdateAsync(location);
        public Task DeleteAsync(string id) => _repository.DeleteAsync(id);
    }
}
