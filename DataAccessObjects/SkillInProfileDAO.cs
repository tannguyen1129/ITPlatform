using BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObjects
{
    public class SkillInProfileDAO
    {
        private readonly DbContext _context;

        public SkillInProfileDAO(DbContext context)
        {
            _context = context;
        }

        public SkillInProfile GetSkillInProfileById(string skillInProfileId)
        {
            return _context.Set<SkillInProfile>()
                .Include(sip => sip.Skill)
                .Include(sip => sip.ExpertiseProfile)
                .FirstOrDefault(sip => sip.SkillInProfileID == skillInProfileId);
        }

        public List<SkillInProfile> GetSkillsInProfileByProfileId(string profileId)
        {
            return _context.Set<SkillInProfile>()
                .Where(sip => sip.ProfileID == profileId)
                .Include(sip => sip.Skill)
                .ToList();
        }

        public void AddSkillInProfile(SkillInProfile skillInProfile)
        {
            _context.Set<SkillInProfile>().Add(skillInProfile);
            _context.SaveChanges();
        }

        public void UpdateSkillInProfile(SkillInProfile skillInProfile)
        {
            _context.Set<SkillInProfile>().Update(skillInProfile);
            _context.SaveChanges();
        }

        public void DeleteSkillInProfile(string skillInProfileId)
        {
            var skillInProfile = _context.Set<SkillInProfile>().Find(skillInProfileId);
            if (skillInProfile != null)
            {
                _context.Set<SkillInProfile>().Remove(skillInProfile);
                _context.SaveChanges();
            }
        }

        public List<SkillInProfile> GetSkillsInProfileByProficiencyLevel(string proficiencyLevel)
        {
            return _context.Set<SkillInProfile>()
                .Where(sip => sip.ProficiencyLevel == proficiencyLevel)
                .Include(sip => sip.Skill)
                .Include(sip => sip.ExpertiseProfile)
                .ToList();
        }
    }
}