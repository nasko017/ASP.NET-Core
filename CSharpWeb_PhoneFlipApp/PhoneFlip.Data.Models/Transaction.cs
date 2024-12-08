
using System.ComponentModel.DataAnnotations;

namespace PhoneFlip.Data.Models;

public class Transaction
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public Guid BuyerId { get; set; }
    public virtual ApplicationUser Buyer { get; set; } = null!;

    [Required]
    public Guid AdId { get; set; }
    public virtual Ad Ad { get; set; } = null!;
}
