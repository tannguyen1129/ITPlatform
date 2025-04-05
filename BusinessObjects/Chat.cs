using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace BusinessObjects
{
    public class Chat
    {
        [Key]
        public Guid ChatID { get; set; } = Guid.NewGuid();

        [Required]
        public Guid ClientID { get; set; }

        [Required]
        public Guid FreelancerID { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime LastMessageAt { get; set; } = DateTime.UtcNow;

        // Khởi tạo để tránh lỗi nullable
        public ICollection<Message> Messages { get; set; } = new List<Message>();
    }

    public class Message
    {
        [Key]
        public Guid MessageID { get; set; } = Guid.NewGuid();

        [Required]
        public Guid ChatID { get; set; }

        [Required]
        public Guid SenderID { get; set; }

        [Required, MaxLength(20)]
        public string SenderRole { get; set; } = string.Empty;  // Gán mặc định

        [Required]
        public string Content { get; set; } = string.Empty;     // Gán mặc định

        public DateTime SentAt { get; set; } = DateTime.UtcNow;
        public bool IsRead { get; set; } = false;

        // Navigation property
        [ForeignKey("ChatID")]
        public Chat Chat { get; set; } = null!;  // Đảm bảo EF khởi tạo
    }
}
