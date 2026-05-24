using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace MiniECommerce.Categories;

public class CategoryDto : AuditedEntityDto<Guid>
{
    public string Name { get; set; }
    public Guid? ParentId { get; set; }
}

