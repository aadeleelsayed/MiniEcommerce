using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MiniECommerce.Products;

public class CreateUpdateProductDto
{
    [Required]
    [StringLength(128)]
    public string NameAr { get; set; }
    [Required]
    [StringLength(128)]
    public string NameEn { get; set; }
    public string DescriptionAr { get; set; }
    public string DescriptionEn { get; set; }
    [Range(0.0, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
    public decimal Price { get; set; }
    [Range(0, int.MaxValue, ErrorMessage = "Stock cannot be negative")]
    public int StockQuantity { get; set; }
    public Guid CategoryId { get; set; }
}

