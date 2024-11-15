using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneFlip.Data.Models;

public class Ad
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public string ImageUrl { get; set; }

    public string Condition { get; set; } 

    public string UserId { get; set; }

    public virtual ApplicationUser ApplicationUser { get; set; } = null!;

    
}
