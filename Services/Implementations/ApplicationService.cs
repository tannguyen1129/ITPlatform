using BusinessObjects;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implementations
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _repository;

        public ApplicationService(IApplicationRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Application>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<Application?> GetByIdAsync(string id) => await _repository.GetByIdAsync(id);
        public async Task CreateAsync(Application application) => await _repository.InsertAsync(application);
        public async Task UpdateAsync(Application application) => await _repository.UpdateAsync(application);
        public async Task DeleteAsync(string id) => await _repository.DeleteAsync(id);
    }
}
