
namespace PhoneFlip.Data.Models;

public class ApplicationUserPhone
{
    public Guid ApplicationUserId { get; set; }

    public virtual ApplicationUser ApplicationUser { get; set; } = null!;

    public Guid MovieId { get; set; }

    public virtual Smartphone Phone { get; set; } = null!;
}
