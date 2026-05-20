using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;
using MiniECommerce.Books;

namespace MiniECommerce;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class MiniECommerceBookToBookDtoMapper : MapperBase<Book, BookDto>
{
    public override partial BookDto Map(Book source);

    public override partial void Map(Book source, BookDto destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class MiniECommerceCreateUpdateBookDtoToBookMapper : MapperBase<CreateUpdateBookDto, Book>
{
    public override partial Book Map(CreateUpdateBookDto source);

    public override partial void Map(CreateUpdateBookDto source, Book destination);
}
