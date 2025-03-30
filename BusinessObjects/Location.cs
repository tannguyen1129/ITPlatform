using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects
{
    public class Location
    {
        [Key]
        public string LocationID { get; set; } //loc_id
        public string Address { get; set; }
        
        // Client
        [Required]
        public string ClientID { get; set; }
        [ForeignKey("ClientID")]
        public virtual Client Client { get; set; }
    }
}
