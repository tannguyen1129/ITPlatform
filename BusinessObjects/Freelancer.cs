using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects
{
    public class Freelancer
    {
        [Key]
        public string FreelancerID { get; set; } = string.Empty;

        public string CIN { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public DateTime DOB { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        // Account
        [Required]
        public string AccountID { get; set; } = string.Empty;

        [ForeignKey("AccountID")]
        public virtual Account Account { get; set; } = null!;

        // Subscription
        public virtual List<Subscription> SubscriptionList { get; set; } = new List<Subscription>();

        // Expertise Profile
        public virtual List<ExpertiseProfile> ExpertiseProfileList { get; set; } = new List<ExpertiseProfile>();

        // Application
        public virtual List<Application> ApplicationList { get; set; } = new List<Application>();

        // Submittion
        public virtual List<Submittion> SubmittionList { get; set; } = new List<Submittion>();
    }
}
