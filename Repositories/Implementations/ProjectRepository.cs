using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories.Implementations
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly MyDbContext _context;

        public ProjectRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<Project>> GetAllAsync()
        {
            return await _context.Projects
                .Include(p => p.Client)
                .Include(p => p.MilestoneList)
                .Include(p => p.ApplicationList)
                .Include(p => p.SkillRequirementList)
                .ToListAsync();
        }

        public async Task<Project?> GetByIdAsync(string id)
        {
            return await _context.Projects
                .Include(p => p.Client)
                .Include(p => p.MilestoneList)
                .Include(p => p.ApplicationList)
                .Include(p => p.SkillRequirementList)
                .FirstOrDefaultAsync(p => p.ProjectID == id);
        }

        public async Task InsertAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Project project)
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var project = await GetByIdAsync(id);
            if (project != null)
            {
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
            }
        }
    }
}
