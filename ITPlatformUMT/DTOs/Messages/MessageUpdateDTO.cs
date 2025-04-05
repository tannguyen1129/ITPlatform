using System;

namespace ITPlatformUMT.DTOs.Messages
{
    public class MessageUpdateDTO
    {
        public string Content { get; set; } = string.Empty;
        public bool IsRead { get; set; }
    }
}
