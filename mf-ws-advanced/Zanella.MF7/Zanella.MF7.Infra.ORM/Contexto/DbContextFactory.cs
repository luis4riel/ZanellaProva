using System.Data.Entity.Infrastructure;
using System.Diagnostics.CodeAnalysis;

namespace Zanella.MF7.Infra.ORM.Contexto
{

    [ExcludeFromCodeCoverage]
    class DbContextFactory : IDbContextFactory<ZanellaDbContext>
    {
        public ZanellaDbContext Create()
        {
            return new ZanellaDbContext();
        }
    }
}
