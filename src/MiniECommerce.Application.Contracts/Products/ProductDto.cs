using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace MiniECommerce.Products;

public class ProductDto : AuditedEntityDto<Guid>
{
    public string NameAr { get;  set; }
    public string NameEn { get;  set; }
    public string DescriptionAr { get;  set; }
    public string DescriptionEn { get;  set; }
    public decimal Price { get;  set; }
    public int StockQuantity { get;  set; }
    public Guid CategoryId { get;  set; }
}

