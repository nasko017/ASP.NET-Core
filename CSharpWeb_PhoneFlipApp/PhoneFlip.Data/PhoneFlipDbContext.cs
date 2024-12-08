using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PhoneFlip.Data.Models;
using System.Reflection.Emit;

namespace PhoneFlip.Data;

public class PhoneFlipDbContext : IdentityDbContext<IdentityUser>
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

           modelBuilder.Entity<Message>()
                       .HasOne(m => m.Sender)
                       .WithMany() // Assuming ApplicationUser does not have a navigation property for Messages
                       .HasForeignKey(m => m.SenderId)
                       .OnDelete(DeleteBehavior.NoAction); // Prevent cascading delete
           
           // Configure Message -> ApplicationUser (Receiver) if applicable
           modelBuilder.Entity<Message>()
                       .HasOne(m => m.Receiver)
                       .WithMany()
                       .HasForeignKey(m => m.ReceiverId)
                       .OnDelete(DeleteBehavior.NoAction); // Preve
           
           modelBuilder.Entity<TradeRequest>()
                       .HasOne(tr => tr.RequestingUser)
                       .WithMany() // Assuming no navigation property in ApplicationUser
                       .HasForeignKey(tr => tr.RequestingUserId)
                       .OnDelete(DeleteBehavior.NoAction); // Prevent cascading delete
           
           // Configure TradeRequest -> Ad (TargetAdId)
           modelBuilder.Entity<TradeRequest>()
                       .HasOne(tr => tr.TargetAd)
                       .WithMany() // Assuming no navigation property in Ad
                       .HasForeignKey(tr => tr.TargetAdId)
                       .OnDelete(DeleteBehavior.NoAction); // Prevent cas
           
           modelBuilder.Entity<Transaction>()
                       .HasOne(t => t.Buyer)
                       .WithMany() // Assuming no navigation property in ApplicationUser
                       .HasForeignKey(t => t.BuyerId)
                       .OnDelete(DeleteBehavior.NoAction); // Prevent cascading delete
           
           // Configure Transaction -> Ad (AdId)
           modelBuilder.Entity<Transaction>()
                       .HasOne(t => t.Ad)
                       .WithMany() // Assuming no navigation property in Ad
                       .HasForeignKey(t => t.AdId)
                       .OnDelete(DeleteBehavior.NoAction); // Prevent c
    }

    
}
