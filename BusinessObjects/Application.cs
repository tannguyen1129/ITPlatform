using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects
{
    public class Application
    {
        [Key]
        public string ApplicationID { get; set; } = default!; // Primary Key

        public string? CV { get; set; }
        public string? CoverLetter { get; set; }

        [Required]
        public string Status { get; set; } = default!; // Pending, Reviewed, Accepted, Rejected

        // Foreign Key: Freelancer
        [Required]
        [ForeignKey(nameof(Freelancer))]
        public string FreelancerID { get; set; } = default!;
        public virtual Freelancer Freelancer { get; set; } = default!;

        // Foreign Key: Project
        [Required]
        [ForeignKey(nameof(Project))]
        public string ProjectID { get; set; } = default!;
        public virtual Project Project { get; set; } = default!;
    }
}
