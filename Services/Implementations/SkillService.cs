using BusinessObjects;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implementations
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _repo;

        public SkillService(ISkillRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Skill>> GetAllAsync() => await _repo.GetAllAsync();

        public async Task<Skill?> GetByIdAsync(string id) => await _repo.GetByIdAsync(id);

        public async Task CreateAsync(Skill skill) => await _repo.InsertAsync(skill);

        public async Task UpdateAsync(Skill skill) => await _repo.UpdateAsync(skill);

        public async Task DeleteAsync(string id) => await _repo.DeleteAsync(id);
    }
}