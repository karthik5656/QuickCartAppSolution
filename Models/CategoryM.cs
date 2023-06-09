using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Syren.QuickCartDAL.Models;

public partial class CategoryM
{
    [Required]
    public byte CategoryId { get; set; }

    [Required]
    [MinLength(1), MaxLength(10)]
    public string CategoryName { get; set; } = null!;
    

}
