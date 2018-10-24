using System.Data.Entity;
using Zanella.MF7.Infra.ORM.Contexto;
using Zanella.MF7.Infra.ORM.Migrations;

namespace Zanella.MF7.Infra.ORM.Initializer
{
    public class DbInitializer : MigrateDatabaseToLatestVersion<ZanellaDbContext, MigrationConfiguration>
    {
    }
}
