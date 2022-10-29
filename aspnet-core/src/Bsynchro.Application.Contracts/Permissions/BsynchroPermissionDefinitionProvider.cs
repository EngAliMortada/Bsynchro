using Bsynchro.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Bsynchro.Permissions;

public class BsynchroPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(BsynchroPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(BsynchroPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BsynchroResource>(name);
    }
}
