using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace MiniECommerce.Categories;

public class CategoryManager : DomainService
{
    private readonly IRepository<Category> _categoryRepository;
    public CategoryManager(IRepository<Category> categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Category> CreateAsync(string name, Guid? parentId)
    {
        if (await _categoryRepository.AnyAsync(c => c.Name == name))
            throw new BusinessException("The category name is already existed!")
                .WithData("ProvidedCategoryName", name);
        if (parentId.HasValue && !await _categoryRepository.AnyAsync(c => c.Id == parentId.Value))
            throw new BusinessException("The parent category is not exist!")
                .WithData("ProvidedParentId", parentId);

        return new Category(GuidGenerator.Create(), name, parentId);

    }
}

