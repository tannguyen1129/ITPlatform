using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects
{
    public class SkillRequirement
    {
        [Key]
        public string SkillRequirementID { get; set; } //skill_req_id
        public string ProficiencyLevel { get; set; }

        // Skill
        [Required]
        public string SkillID { get; set; }
        [ForeignKey("SkillID")]
        public virtual Skill Skill { get; set; }

        //Project
        [Required]
        public string ProjectID { get; set; }
        [ForeignKey("ProjectID")]
        public virtual Project Project { get; set; }
    }
}