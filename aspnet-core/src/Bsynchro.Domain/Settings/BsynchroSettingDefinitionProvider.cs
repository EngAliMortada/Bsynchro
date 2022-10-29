using Volo.Abp.Settings;

namespace Bsynchro.Settings;

public class BsynchroSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(BsynchroSettings.MySetting1));
    }
}
