using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Syren.QuickCartDAL.Models;

public partial class ProductM
{
    [Required]
    [RegularExpression("^P.*")]
    [StringLength(4)]
    public string ProductId { get; set; } = null!;

    [Required]
    [MaxLength(20), MinLength(5)]
    public string ProductName { get; set; } = null!;

    [Required]
    public byte? CategoryId { get; set; }

    [Required]
    [Range(1, Double.MaxValue)]
    public decimal Price { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int QuantityAvailable { get; set; }

    public virtual Category? Category { get; set; }

    
}
