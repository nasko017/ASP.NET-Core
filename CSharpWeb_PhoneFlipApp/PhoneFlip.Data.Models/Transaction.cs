using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneFlip.Data.Models;

public class Transaction
{
    public Guid Id { get; set; }
    public Guid AdId { get; set; }
    public Ad Ad { get; set; } = null!; // Ad that was purchased

    public Guid BuyerId { get; set; }
    public virtual ApplicationUser ApplicationUser { get; set; } = null!; // User who bought the ad

    public decimal Amount { get; set; } // Purchase amount
    public DateTime TransactionDate { get; set; }
}
