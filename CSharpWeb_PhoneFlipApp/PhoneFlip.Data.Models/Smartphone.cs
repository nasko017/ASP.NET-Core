﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneFlip.Data.Models;

public class Smartphone
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [MaxLength(100)]
    public string Brand { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    public string Model { get; set; } = null!;

    [Required]
    public bool IsDeleted { get; set; } = false;
}
