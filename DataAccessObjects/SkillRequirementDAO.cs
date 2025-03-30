using BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObjects
{
    public class SkillRequirementDAO
    {
        private readonly DbContext _context;

        public SkillRequirementDAO(DbContext context)
        {
            _context = context;
        }

        public SkillRequirement GetSkillRequirementById(string skillRequirementId)
        {
            return _context.Set<SkillRequirement>()
                .Include(sr => sr.Skill)
                .Include(sr => sr.Project)
                .FirstOrDefault(sr => sr.SkillRequirementID == skillRequirementId);
        }

        public List<SkillRequirement> GetSkillRequirementsByProjectId(string projectId)
        {
            return _context.Set<SkillRequirement>()
                .Where(sr => sr.ProjectID == projectId)
                .Include(sr => sr.Skill)
                .ToList();
        }

        public void AddSkillRequirement(SkillRequirement skillRequirement)
        {
            _context.Set<SkillRequirement>().Add(skillRequirement);
            _context.SaveChanges();
        }

        public void UpdateSkillRequirement(SkillRequirement skillRequirement)
        {
            _context.Set<SkillRequirement>().Update(skillRequirement);
            _context.SaveChanges();
        }

        public void DeleteSkillRequirement(string skillRequirementId)
        {
            var skillRequirement = _context.Set<SkillRequirement>().Find(skillRequirementId);
            if (skillRequirement != null)
            {
                _context.Set<SkillRequirement>().Remove(skillRequirement);
                _context.SaveChanges();
            }
        }

        public List<SkillRequirement> GetSkillRequirementsByProficiencyLevel(string proficiencyLevel)
        {
            return _context.Set<SkillRequirement>()
                .Where(sr => sr.ProficiencyLevel == proficiencyLevel)
                .Include(sr => sr.Skill)
                .Include(sr => sr.Project)
                .ToList();
        }
    }
}