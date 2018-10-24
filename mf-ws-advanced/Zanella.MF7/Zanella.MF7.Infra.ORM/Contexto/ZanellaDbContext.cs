using System.Data.Common;
using System.Data.Entity;
using Zanella.MF7.Dominio.Features.Users;

namespace Zanella.MF7.Infra.ORM.Contexto
{
    public class ZanellaDbContext : DbContext
    {
        public ZanellaDbContext(string connection = "Name=MF_WSA_Zanella") : base(connection)
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        protected ZanellaDbContext(DbConnection connection) : base(connection, true) { }

        // Stores por entidade do contexto
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
