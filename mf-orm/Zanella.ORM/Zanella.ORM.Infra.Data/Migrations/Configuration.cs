namespace Zanella.ORM.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Zanella.ORM.Infra.Data.Contexto.ORMContexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Zanella.ORM.Infra.Data.Contexto.ORMContexto context)
        {
            //  This method will be called after migrating to the latest version.x

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
