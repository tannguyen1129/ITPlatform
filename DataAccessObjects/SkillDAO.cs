using BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObjects
{
    public class SkillDAO
    {
        private readonly DbContext _context;

        public SkillDAO(DbContext context)
        {
            _context = context;
        }

        public Skill GetSkillById(string skillId)
        {
            return _context.Set<Skill>()
                .Include(s => s.SkillInProfileList)
                .Include(s => s.SkillRequirementList)
                .FirstOrDefault(s => s.SkillID == skillId);
        }

        public List<Skill> GetAllSkills()
        {
            return _context.Set<Skill>()
                .Include(s => s.SkillInProfileList)
                .Include(s => s.SkillRequirementList)
                .ToList();
        }

        public void AddSkill(Skill skill)
        {
            _context.Set<Skill>().Add(skill);
            _context.SaveChanges();
        }

        public void UpdateSkill(Skill skill)
        {
            _context.Set<Skill>().Update(skill);
            _context.SaveChanges();
        }

        public void DeleteSkill(string skillId)
        {
            var skill = _context.Set<Skill>().Find(skillId);
            if (skill != null)
            {
                _context.Set<Skill>().Remove(skill);
                _context.SaveChanges();
            }
        }

        public List<Skill> SearchSkillsByName(string name)
        {
            return _context.Set<Skill>()
                .Where(s => s.Name.Contains(name))
                .ToList();
        }
    }
}