using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects
{
    public class Milestone
    {
        [Key]
        public string MilestoneID { get; set; } //mile_id
        public double Budget { get; set; } //Max paid for Freelancer
        public string Status { get; set; } //InProgress, Completed, Paid

        // Project
        [Required]
        public string ProjectID { get; set; }
        [ForeignKey("ProjectID")]
        public virtual Project Project { get; set; }

        // Submittion
        public virtual List<Submittion> SubmittionList { get; set; }
    }
}
