using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.Identity;

namespace MiniECommerce.Data;

public class MiniEcommerceDataSeederContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IIdentityRoleRepository _identityRoleRepository;
    private readonly IdentityRoleManager _identityRoleManager;
    private readonly IdentityUserManager _identityUserManager;
    private readonly IGuidGenerator _guidGenerator;
    public MiniEcommerceDataSeederContributor(
        IIdentityRoleRepository identityRoleRepository,
        IdentityRoleManager identityRoleManager,
        IdentityUserManager identityUserManager,
        IGuidGenerator guidGenerator
        )
    {
        _identityRoleRepository = identityRoleRepository;
        _identityRoleManager = identityRoleManager;
        _identityUserManager = identityUserManager;
        _guidGenerator = guidGenerator;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if(await _identityRoleRepository.FindByNormalizedNameAsync("ADMIN") == null)
        {
            await _identityRoleManager.CreateAsync(new IdentityRole(_guidGenerator.Create(), MiniECommerceConsts.RoleAdmin,null));
        }
        if (await _identityRoleRepository.FindByNormalizedNameAsync("CUSTOMER") == null)
        {
            await _identityRoleManager.CreateAsync(new IdentityRole(_guidGenerator.Create(), MiniECommerceConsts.RoleCustomer, null));
        }

        if(await _identityUserManager.FindByNameAsync(MiniECommerceConsts.AdminUserName) == null)
        {
            var adminUser = new IdentityUser(_guidGenerator.Create(), MiniECommerceConsts.AdminUserName, "userAdmin@gmail.com", null);
            await _identityUserManager.CreateAsync(adminUser, MiniECommerceConsts.AdminPasswordDefaultValue);
            await _identityUserManager.AddToRoleAsync(adminUser, MiniECommerceConsts.RoleAdmin);
        }
    }
}
