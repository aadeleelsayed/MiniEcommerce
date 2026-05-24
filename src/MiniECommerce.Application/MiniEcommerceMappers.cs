using MiniECommerce.Categories;
using MiniECommerce.Orders;
using MiniECommerce.Products;
using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;

namespace MiniEcommerce;

[Mapper]
public partial class CategoryToDtoMapper : MapperBase<Category, CategoryDto>
{
    public override partial CategoryDto Map(Category source);
    public override partial void Map(Category source, CategoryDto destination);
}

[Mapper]
public partial class ProductToDtoMapper : MapperBase<Product, ProductDto>
{
    public override partial ProductDto Map(Product source);
    public override partial void Map(Product source, ProductDto destination);
}

[Mapper]
public partial class OrderToDtoMapper : MapperBase<Order, OrderDto>
{
    public override partial OrderDto Map(Order source);
    public override partial void Map(Order source, OrderDto destination);
}

[Mapper]
public partial class OrderItemToDtoMapper : MapperBase<OrderItem, OrderItemDto>
{
    public override partial OrderItemDto Map(OrderItem source);
    public override partial void Map(OrderItem source, OrderItemDto destination);
}