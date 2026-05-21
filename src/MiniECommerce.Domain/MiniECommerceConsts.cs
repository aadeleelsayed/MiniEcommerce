using Volo.Abp.Identity;

namespace MiniECommerce;

public static class MiniECommerceConsts
{
    public const string DbTablePrefix = "App";
    public const string? DbSchema = null;
    public const string AdminEmailDefaultValue = IdentityDataSeedContributor.AdminEmailDefaultValue;
    public const string AdminPasswordDefaultValue = "1q2w3E*";

    public const string RoleAdmin = "Admin";
    public const string RoleCustomer = "Customer";
    public const string AdminUserName = "userAdmin";

}
