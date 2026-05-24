using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace MiniECommerce.Categories;

[Authorize(Roles = MiniECommerceConsts.RoleAdmin)]
public class CategoryAppService : CrudAppService<
    Category,
    CategoryDto,
    Guid,
    PagedAndSortedResultRequestDto,
    CreateUpdateCategoryDto>
    , ICategoryAppService
{
    private readonly CategoryManager _categoryManager;
    public CategoryAppService(IRepository<Category, Guid> repository, CategoryManager categoryManager) : base(repository)
    {
        _categoryManager = categoryManager;
    }

    public override async Task<CategoryDto> CreateAsync(CreateUpdateCategoryDto createUpdateCategoryDto)
    {
        var category = await _categoryManager.CreateAsync(createUpdateCategoryDto.Name, createUpdateCategoryDto.ParentId);
        await Repository.InsertAsync(category);
        return ObjectMapper.Map<Category,CategoryDto>(category);
    }
}

