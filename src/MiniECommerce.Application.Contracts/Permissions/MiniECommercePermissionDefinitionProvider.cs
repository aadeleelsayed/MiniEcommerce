using MiniECommerce.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace MiniECommerce.Permissions;

public class MiniECommercePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(MiniECommercePermissions.GroupName);

        var booksPermission = myGroup.AddPermission(MiniECommercePermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(MiniECommercePermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(MiniECommercePermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(MiniECommercePermissions.Books.Delete, L("Permission:Books.Delete"));
        //Define your own permissions here. Example:
        //myGroup.AddPermission(MiniECommercePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<MiniECommerceResource>(name);
    }
}
