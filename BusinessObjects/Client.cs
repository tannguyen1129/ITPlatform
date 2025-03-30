using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BusinessObjects
{
    public class Client
    {
        [Key]
        public string? ClientID { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Field { get; set; }

        public string? PhoneNumber { get; set; }

        public string? WebsiteURL { get; set; }

        public string? TaxID { get; set; }

        [Required]
        public string? AccountID { get; set; }

        [ForeignKey("AccountID")]
        [JsonIgnore]
        public Account? Account { get; set; }

        public List<Location> LocationList { get; set; } = new();
        public List<Subscription> SubscriptionList { get; set; } = new();
        public List<Project> ProjectList { get; set; } = new();
    }
}
