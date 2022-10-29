using System;
using System.Collections.Generic;
using System.Text;
using Bsynchro.Localization;
using Volo.Abp.Application.Services;

namespace Bsynchro;

/* Inherit your application services from this class.
 */
public abstract class BsynchroAppService : ApplicationService
{
    protected BsynchroAppService()
    {
        LocalizationResource = typeof(BsynchroResource);
    }
}
