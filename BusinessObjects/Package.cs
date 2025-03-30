using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects
{
    public class Package
    {
        [Key]
        public string PackageID { get; set; } //pack_id
        public string Type { get; set; } //Client / Freelancer
        public string Name { get; set; }
        public double Price { get; set; }
        public int Period { get; set; } //Number of months

        // Subscription
        public virtual List<Subscription> SubscriptionList { get; set; }
    }
}
