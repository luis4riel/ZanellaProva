using System.Data.Common;
using Zanella.MF7.Infra.ORM.Contexto;

namespace Zanella.MF7.ORM.Teste.Contexto
{
    public class FakeDbContext : ZanellaDbContext
    {
        public FakeDbContext(DbConnection connection) : base(connection)
        {
        }
    }
}
