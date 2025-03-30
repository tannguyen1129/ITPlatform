using BusinessObjects;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implementations
{
    public class SubmittionService : ISubmittionService
    {
        private readonly ISubmittionRepository _repo;

        public SubmittionService(ISubmittionRepository repo)
        {
            _repo = repo;
        }

        public Task<List<Submittion>> GetAllAsync() => _repo.GetAllAsync();

        public Task<Submittion?> GetByIdAsync(string id) => _repo.GetByIdAsync(id);

        public Task CreateAsync(Submittion submittion) => _repo.InsertAsync(submittion);

        public Task UpdateAsync(Submittion submittion) => _repo.UpdateAsync(submittion);

        public Task DeleteAsync(string id) => _repo.DeleteAsync(id);
    }
}