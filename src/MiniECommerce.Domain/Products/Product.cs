using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace MiniECommerce.Products;
    public class Product : FullAuditedAggregateRoot<Guid>
    {
        public string NameAr { get; private set; }
        public string NameEn { get; private set; }
        public string DescriptionAr { get; private set; }
        public string DescriptionEn { get; private set; }
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }
        public Guid CategoryId { get; private set; }
        
    private Product() { }
    public Product(Guid id,Guid categoryId,string nameAr, string nameEn, string descriptionAr, string descriptionEn, decimal price, int stockQuantity)
    : base(id)
    {
        NameAr = Check.NotNullOrEmpty(nameAr,nameof(nameAr));
        NameEn = Check.NotNullOrEmpty(nameEn, nameof(nameEn));
        DescriptionAr = descriptionAr;
        DescriptionEn = descriptionEn;
        CategoryId = categoryId;

        SetPrice(price);
        SetStockQuantity(stockQuantity);
    }

    public void SetStockQuantity(int stockQuantity)
    {
        if (stockQuantity < 0)
        {
            throw new BusinessException("StockQuantity cannot be negative.")
                .WithData("ProvidedStockQuantity", stockQuantity);
        }
        StockQuantity = stockQuantity;
    }

    public void SetPrice(decimal price)
    {
        if(price <= 0)
        {
            throw new BusinessException("Price should be greater than 0.")
                .WithData("ProvidedPrice",price);
        }
        Price = price;
    }
}

