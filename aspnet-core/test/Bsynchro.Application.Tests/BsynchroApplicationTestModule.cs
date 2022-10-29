using Volo.Abp.Modularity;

namespace Bsynchro;

[DependsOn(
    typeof(BsynchroApplicationModule),
    typeof(BsynchroDomainTestModule)
    )]
public class BsynchroApplicationTestModule : AbpModule
{

}
