using Bsynchro.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Bsynchro;

[DependsOn(
    typeof(BsynchroEntityFrameworkCoreTestModule)
    )]
public class BsynchroDomainTestModule : AbpModule
{

}
