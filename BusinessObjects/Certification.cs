using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects
{
    public class Certification
    {
        [Key]
        public string CertID { get; set; } //cert_id
        public string Name { get; set; }
        public string Issuer { get; set; }
        public DateTime IssueDate { get; set; }
        public string CertURL { get; set; }
        
        // Profile
        public string ProfileID { get; set; }
        [ForeignKey("ProfileID")]
        public virtual ExpertiseProfile ExpertiseProfile { get; set; }
    }
}
