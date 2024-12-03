using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PhoneFlip.Data.Models;

public class ApplicationUser : IdentityUser<Guid>
{
    public ApplicationUser()
    {
        // ReSharper disable once VirtualMemberCallInConstructor
        this.Id = Guid.NewGuid();
    }

    public virtual ICollection<TradeRequest> ApplicationUserMovies { get; set; }
           = new HashSet<TradeRequest>();

    public virtual ICollection<Ad> Tickets { get; set; }
        = new HashSet<Ad>();
}
