using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Bsynchro.Data;

/* This is used if database provider does't define
 * IBsynchroDbSchemaMigrator implementation.
 */
public class NullBsynchroDbSchemaMigrator : IBsynchroDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
