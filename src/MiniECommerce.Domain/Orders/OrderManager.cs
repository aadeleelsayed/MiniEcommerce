using MiniECommerce.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace MiniECommerce.Orders;

public class OrderManager : DomainService
{
    private readonly IRepository<Product, Guid> _productRepository;
    public OrderManager(IRepository<Product, Guid> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task AddItemToOrderAsync (Order order, Guid productId, int quantity)
    {
        var product = await _productRepository.GetAsync(productId);
        
        if(product == null)
        {
            throw new BusinessException("Product is not exist!")
                .WithData("ProvidedProductId", productId);
        }

        if (product.StockQuantity < quantity)
        {
            throw new BusinessException("There is no enough stock!")
                .WithData("CurrentStock",product.StockQuantity);

        }
        product.SetStockQuantity(product.StockQuantity - quantity);
        order.AddItem(GuidGenerator.Create(), productId, product.Price, quantity);
    }

    
}

