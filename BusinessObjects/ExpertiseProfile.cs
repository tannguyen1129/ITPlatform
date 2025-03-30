using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects
{
    public class ExpertiseProfile
    {
        [Key]
        public string ProfileID { get; set; } //prof_id
        public string Field { get; set; }
        public string Title { get; set; } //MS,ME,PhD,...
        public string Description { get; set; }
        public string PortfolioURL { get; set; }

        // Certification
        public virtual List<Certification> CertificationList { get; set; }
        
        // SkillInProfile
        public virtual List<SkillInProfile> SkillInProfileList { get; set; }

        // Freelancer
        [Required]
        public string FreelancerID { get; set; }
        [ForeignKey("FreelancerID")]
        public virtual Freelancer Freelancer { get; set; }
    }
}
