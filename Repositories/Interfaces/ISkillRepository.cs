using BusinessObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface ISkillRepository
    {
        Task<List<Skill>> GetAllAsync();
        Task<Skill?> GetByIdAsync(string id);
        Task InsertAsync(Skill skill);
        Task UpdateAsync(Skill skill);
        Task DeleteAsync(string id);
    }
}
