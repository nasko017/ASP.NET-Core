﻿
using System.ComponentModel.DataAnnotations;

namespace PhoneFlip.Data.Models;

public class TradeRequest
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public Guid RequestingUserId { get; set; }
    public virtual ApplicationUser RequestingUser { get; set; } = null!;

    [Required]
    public Guid TargetAdId { get; set; }
    public virtual Ad TargetAd { get; set; } = null!;

    [Required]
    [MaxLength(20)]
    public string Status { get; set; } = null!;

    [Required]
    public bool IsDeleted { get; set; } = false;
}
