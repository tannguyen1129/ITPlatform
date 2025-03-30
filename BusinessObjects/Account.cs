using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects
{
    public class Account
    {
        [Key]
        public string AccountID { get; set; } //acc_role_id

        [Required]
        public string Role { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(6)]
        public string Password { get; set; }
    }
}
