using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects
{
    public class Skill
    {
        [Key]
        public string SkillID { get; set; } //skill_id
        public string Name { get; set; }
        
        // SkillInProfile
        public virtual List<SkillInProfile> SkillInProfileList { get; set; }

        // SkillRequirement
        public virtual List<SkillRequirement> SkillRequirementList { get; set; }
    }
}
