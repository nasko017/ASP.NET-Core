using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PhoneFlip.Data.Models;

namespace PhoneFlip.Data;

public class PhoneFlipDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public PhoneFlipDbContext(DbContextOptions<PhoneFlipDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ad> Ads { get; set; }
    public virtual DbSet<Smartphone> Smartphones { get; set; }
    public virtual DbSet<Transaction> Transactions { get; set; }
    public virtual DbSet<TradeRequest> TradeRequests { get; set; }
    public virtual DbSet<Message> Messages { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
