using Bsynchro.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Bsynchro.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(BsynchroEntityFrameworkCoreModule),
    typeof(BsynchroApplicationContractsModule)
    )]
public class BsynchroDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
