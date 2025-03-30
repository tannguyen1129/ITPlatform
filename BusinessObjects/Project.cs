using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects
{
    public class Project
    {
        [Key]
        public string ProjectID { get; set; } = default!;

        public string? Title { get; set; }
        public string? Description { get; set; }

        public double BudgetMin { get; set; }
        public double BudgetMax { get; set; }

        public string? Status { get; set; } // Open, InProgress, Done

        // ✅ Không cần [ForeignKey] ở đây
        [Required]
        public string ClientID { get; set; } = default!;

        // ✅ Navigation property
        public virtual Client Client { get; set; } = default!;

        // Navigation collections
        public virtual List<Milestone> MilestoneList { get; set; } = new();
        public virtual List<Application> ApplicationList { get; set; } = new();
        public virtual List<SkillRequirement> SkillRequirementList { get; set; } = new();
    }
}
