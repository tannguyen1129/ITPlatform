using BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObjects
{
    public class ProjectDAO
    {
        private readonly MyDbContext _context;

        public ProjectDAO(MyDbContext context)
        {
            _context = context;
        }

        public List<Project> GetAll()
        {
            return _context.Projects
                .Include(p => p.Client)
                .Include(p => p.MilestoneList)
                .Include(p => p.ApplicationList)
                .Include(p => p.SkillRequirementList)
                .ToList();
        }

        public Project GetById(string projectId)
        {
            return _context.Projects
                .Include(p => p.Client)
                .Include(p => p.MilestoneList)
                .Include(p => p.ApplicationList)
                .Include(p => p.SkillRequirementList)
                .FirstOrDefault(p => p.ProjectID == projectId);
        }

        public void Insert(Project project)
        {
            _context.Projects.Add(project);
            _context.SaveChanges();
        }

        public void Update(Project project)
        {
            _context.Entry(project).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(string projectId)
        {
            var project = _context.Projects.Find(projectId);
            if (project != null)
            {
                _context.Projects.Remove(project);
                _context.SaveChanges();
            }
        }

        public List<Project> GetByClientId(string clientId)
        {
            return _context.Projects
                .Where(p => p.ClientID == clientId)
                .Include(p => p.MilestoneList)
                .Include(p => p.ApplicationList)
                .ToList();
        }

        public List<Project> GetByStatus(string status)
        {
            return _context.Projects
                .Where(p => p.Status == status)
                .ToList();
        }
    }
}
