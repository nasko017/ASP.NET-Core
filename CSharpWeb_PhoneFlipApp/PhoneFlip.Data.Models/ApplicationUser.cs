
using Microsoft.AspNetCore.Identity;

namespace PhoneFlip.Data.Models;

public class ApplicationUser : IdentityUser<Guid>
{
    public ApplicationUser()
    {
        // ReSharper disable once VirtualMemberCallInConstructor
        this.Id = Guid.NewGuid();
    }

    public virtual ICollection<TradeRequest> ApplicationUserRequests { get; set; }
           = new HashSet<TradeRequest>();

    public virtual ICollection<Ad> Ads { get; set; }
        = new HashSet<Ad>();
}
