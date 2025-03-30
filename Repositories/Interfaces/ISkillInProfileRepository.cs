// ISkillInProfileRepository.cs
using BusinessObjects;

namespace Repositories.Interfaces
{
    public interface ISkillInProfileRepository
    {
        Task<List<SkillInProfile>> GetAllAsync();
        Task<SkillInProfile?> GetByIdAsync(string id);
        Task InsertAsync(SkillInProfile entity);
        Task UpdateAsync(SkillInProfile entity);
        Task DeleteAsync(string id);
    }
}
