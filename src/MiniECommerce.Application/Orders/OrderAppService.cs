using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace MiniECommerce.Orders;

[Authorize(Roles = MiniECommerceConsts.RoleCustomer)]
public class OrderAppService : ApplicationService,IOrderAppService
{
    private readonly OrderManager _orderManager;
    private readonly IRepository<Order, Guid> _repository;
    public OrderAppService(
        OrderManager orderManager,
        IRepository<Order,Guid> repository)
    {
        _orderManager = orderManager;
        _repository = repository;
    }
    public async Task<OrderDto> CreateAsync(CreateOrderDto createOrderDto)
    {
        var order = new Order(GuidGenerator.Create());
        foreach(var item in createOrderDto.Items)
        {
            await _orderManager.AddItemToOrderAsync(order, item.ProductId, item.Quantity);
        }
        await _repository.InsertAsync(order);
        return ObjectMapper.Map<Order, OrderDto>(order);
    }
}

