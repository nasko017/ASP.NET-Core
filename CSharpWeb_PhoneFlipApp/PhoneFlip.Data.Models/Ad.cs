using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneFlip.Data.Models;

public class Ad
{

    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = null!;

    [Required]
    [MaxLength(1000)]
    public string Description { get; set; } = null!;

    [Required]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    [Required]
    public Guid SmartphoneId { get; set; }
    public virtual Smartphone Smartphone { get; set; } = null!;

    [Required]
    public string UserId { get; set; } = null!;
    public virtual ApplicationUser ApplicationUser { get; set; } = null!;

    [Required]
    public bool IsDeleted { get; set; } = false;


}
