using System.Threading.Tasks;

namespace Bsynchro.Data;

public interface IBsynchroDbSchemaMigrator
{
    Task MigrateAsync();
}
