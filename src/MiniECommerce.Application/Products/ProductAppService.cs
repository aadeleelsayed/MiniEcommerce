using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace MiniECommerce.Products;

[Authorize]
public class ProductAppService :
CrudAppService<Product, ProductDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateProductDto>
, IProductAppService
{
    private readonly ProductManager _productManager;

    public ProductAppService(
        IRepository<Product, Guid> repository,
        ProductManager productManager
        ) : base(repository)
    {
        _productManager = productManager;
    }
    [Authorize(Roles = MiniECommerceConsts.RoleAdmin)]
    public override async Task<ProductDto> CreateAsync(CreateUpdateProductDto createUpdateProductDto)
    {
        var product = await _productManager.CreateAsync(
            createUpdateProductDto.CategoryId,
            createUpdateProductDto.NameAr,
            createUpdateProductDto.NameEn,
            createUpdateProductDto.DescriptionAr,
            createUpdateProductDto.DescriptionEn,
            createUpdateProductDto.Price,
            createUpdateProductDto.StockQuantity);

        await Repository.InsertAsync(product);
        return ObjectMapper.Map<Product, ProductDto>(product);
    }

    [Authorize(Roles = MiniECommerceConsts.RoleAdmin)]
    public override async Task<ProductDto> UpdateAsync(Guid id, CreateUpdateProductDto dto)
    {
        var product = await Repository.GetAsync(id);
        product.SetPrice(dto.Price);
        product.SetStockQuantity(dto.StockQuantity);
        await Repository.UpdateAsync(product);
        return ObjectMapper.Map<Product, ProductDto>(product);
    }

    [Authorize(Roles = MiniECommerceConsts.RoleAdmin)]
    public override async Task DeleteAsync(Guid id)
    {
        CheckProductExistence(id);
        await Repository.DeleteAsync(id);
    }
    private async Task CheckProductExistence(Guid id)
    {
        if (!await Repository.AnyAsync(p => p.Id == id))
        {
            throw new BusinessException("The product is not exist")
                .WithData("ProvidedProductId", id);
        }
    }
}
