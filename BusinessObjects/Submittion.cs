using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects
{
    public class Submittion
    {
        [Key]
        public string SubmittionID { get; set; } //submit_id
        public string Content { get; set; }
        public string Status { get; set; } //Pending, Accepted, Rejected

        // Freelancer
        [Required]
        public string FreelancerID { get; set; }
        [ForeignKey("FreelancerID")]
        public virtual Freelancer Freelancer { get; set; }

        // Milestone
        [Required]
        public string MilestoneID { get; set; }
        [ForeignKey("MilestoneID")]
        public virtual Milestone Milestone { get; set; }

    }
}
