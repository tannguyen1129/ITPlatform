using BusinessObjects;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implementations
{
    public class MilestoneService : IMilestoneService
    {
        private readonly IMilestoneRepository _repo;

        public MilestoneService(IMilestoneRepository repo)
        {
            _repo = repo;
        }

        public Task<List<Milestone>> GetAllAsync() => _repo.GetAllAsync();

        public Task<Milestone?> GetByIdAsync(string id) => _repo.GetByIdAsync(id);

        public Task CreateAsync(Milestone milestone) => _repo.InsertAsync(milestone);

        public Task UpdateAsync(Milestone milestone) => _repo.UpdateAsync(milestone);

        public Task DeleteAsync(string id) => _repo.DeleteAsync(id);
    }
}