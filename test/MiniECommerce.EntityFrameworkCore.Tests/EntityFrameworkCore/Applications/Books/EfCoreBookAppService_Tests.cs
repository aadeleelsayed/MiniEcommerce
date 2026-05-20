using MiniECommerce.Books;
using Xunit;

namespace MiniECommerce.EntityFrameworkCore.Applications.Books;

[Collection(MiniECommerceTestConsts.CollectionDefinitionName)]
public class EfCoreBookAppService_Tests : BookAppService_Tests<MiniECommerceEntityFrameworkCoreTestModule>
{

}