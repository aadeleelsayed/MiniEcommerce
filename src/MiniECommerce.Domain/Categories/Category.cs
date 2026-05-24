using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace MiniECommerce.Categories;

public class Category : FullAuditedAggregateRoot<Guid>
{
    public string Name { get; set; }
    public Guid? ParentId { get; set; }
    private Category() { }

    public Category(Guid id, string name, Guid? parentId = null)
        : base(id)
    {
        Name = name;
        ParentId = parentId;
    }
    public void setName(string name)
    {
        Name = Check.NotNullOrEmpty(name, nameof(name));
    }
}

