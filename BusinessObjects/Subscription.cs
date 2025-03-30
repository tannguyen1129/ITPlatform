using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects
{
    public class Subscription
    {
        [Key]
        public string SubscriptionID { get; set; } //subscript_id
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // If Freelancer
        public string? FreelancerID { get; set; }
        [ForeignKey("FreelancerID")]
        public virtual Freelancer Freelancer { get; set; }

        // If Client
        public string? ClientID { get; set; }
        [ForeignKey("ClientID")]
        public virtual Client Client { get; set; }
    }
}
