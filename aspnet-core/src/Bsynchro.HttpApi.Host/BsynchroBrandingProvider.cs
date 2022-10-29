using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Bsynchro;

[Dependency(ReplaceServices = true)]
public class BsynchroBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Bsynchro";
}
