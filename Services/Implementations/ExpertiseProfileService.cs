using BusinessObjects;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implementations
{
    public class ExpertiseProfileService : IExpertiseProfileService
    {
        private readonly IExpertiseProfileRepository _repo;

        public ExpertiseProfileService(IExpertiseProfileRepository repo)
        {
            _repo = repo;
        }

        public Task<List<ExpertiseProfile>> GetAllAsync() => _repo.GetAllAsync();
        public Task<ExpertiseProfile?> GetByIdAsync(string id) => _repo.GetByIdAsync(id);
        public Task CreateAsync(ExpertiseProfile profile) => _repo.InsertAsync(profile);
        public Task UpdateAsync(ExpertiseProfile profile) => _repo.UpdateAsync(profile);
        public Task DeleteAsync(string id) => _repo.DeleteAsync(id);
    }
}
