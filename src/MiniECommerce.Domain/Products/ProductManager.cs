using MiniECommerce.Categories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace MiniECommerce.Products;

public class ProductManager : DomainService
{
    private readonly IRepository<Category, Guid> _categoryRepository;
    
    public ProductManager(IRepository<Category, Guid> categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public async Task<Product> CreateAsync(
        Guid categoryId,
        string nameAr,
        string nameEn,
        string descriptionAr,
        string descriptionEn,
        decimal price,
        int stockQuantity)
    {
        if(!await _categoryRepository.AnyAsync(c => c.Id == categoryId))
        {
            throw new BusinessException("The category is not exist").WithData("ProvidedCategoryId", categoryId);
        }
        return new Product(
            GuidGenerator.Create(),
            categoryId,
            nameAr,
            nameEn,
            descriptionAr,
            descriptionEn,
            price,
            stockQuantity);
    }
}

