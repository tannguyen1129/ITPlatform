// ISkillInProfileService.cs
using BusinessObjects;

namespace Services.Interfaces
{
    public interface ISkillInProfileService
    {
        Task<List<SkillInProfile>> GetAllAsync();
        Task<SkillInProfile?> GetByIdAsync(string id);
        Task CreateAsync(SkillInProfile entity);
        Task UpdateAsync(SkillInProfile entity);
        Task DeleteAsync(string id);
    }
}
