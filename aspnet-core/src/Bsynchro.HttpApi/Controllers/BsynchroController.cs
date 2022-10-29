using Bsynchro.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Bsynchro.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class BsynchroController : AbpControllerBase
{
    protected BsynchroController()
    {
        LocalizationResource = typeof(BsynchroResource);
    }
}
