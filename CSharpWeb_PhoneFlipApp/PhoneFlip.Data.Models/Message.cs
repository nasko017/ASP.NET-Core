
using System.ComponentModel.DataAnnotations;

namespace PhoneFlip.Data.Models;

public class Message
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public Guid SenderId { get; set; }
    public virtual ApplicationUser Sender { get; set; } = null!;

    [Required]
    public Guid ReceiverId { get; set; }
    public virtual ApplicationUser Receiver { get; set; } = null!;

    [Required]
    [MaxLength(1000)]
    public string Content { get; set; } = null!;

    public DateTime SentAt { get; set; } = DateTime.UtcNow;

    public bool IsRead { get; set; } = false;
}
