using BusinessObjects;

namespace Services.Interfaces
{
    public interface ISkillService
    {
        Task<List<Skill>> GetAllAsync();
        Task<Skill?> GetByIdAsync(string id);
        Task CreateAsync(Skill skill);
        Task UpdateAsync(Skill skill);
        Task DeleteAsync(string id);
    }
}