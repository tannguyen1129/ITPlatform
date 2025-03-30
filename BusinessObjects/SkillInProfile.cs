using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects
{
    public class SkillInProfile
    {
        [Key]
        public string SkillInProfileID { get; set; } //skill_prof_id
        public string ProficiencyLevel { get; set; }

        // Skill
        [Required]
        public string SkillID { get; set; }
        [ForeignKey("SkillID")]
        public virtual Skill Skill { get; set; }

        // ExpertiseProfile
        [Required]
        public string ProfileID { get; set; }
        [ForeignKey("ProfileID")]
        public virtual ExpertiseProfile ExpertiseProfile { get; set; }
    }
}
