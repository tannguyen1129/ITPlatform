using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects
{
    public class Submittion
    {
        [Key]
        public string SubmittionID { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public required string MilestoneID { get; set; }

        [ForeignKey(nameof(MilestoneID))]
        public Milestone? Milestone { get; set; }

        [Required]
        public required string FreelancerID { get; set; }

        [ForeignKey(nameof(FreelancerID))]
        public Freelancer? Freelancer { get; set; }

        public string? Description { get; set; }

        public string? FilePath { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string Status { get; set; } = "Đã nộp";
    }
}
