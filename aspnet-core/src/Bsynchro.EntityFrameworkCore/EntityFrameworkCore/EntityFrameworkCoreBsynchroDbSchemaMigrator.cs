using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Bsynchro.Data;
using Volo.Abp.DependencyInjection;

namespace Bsynchro.EntityFrameworkCore;

public class EntityFrameworkCoreBsynchroDbSchemaMigrator
    : IBsynchroDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreBsynchroDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the BsynchroDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<BsynchroDbContext>()
            .Database
            .MigrateAsync();
    }
}
