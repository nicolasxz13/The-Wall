using System.ComponentModel.DataAnnotations;

namespace The_Wall.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        [Display(Name = "Post a Message")]
        [Required(ErrorMessage = "Message is required")]
        public string? MessageText { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public User? UserMessage { get; set; }
        public List<Comment>? Comments{get;set;}
    }
}
