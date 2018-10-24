using System.Data.Entity.Migrations;
using System.Linq;
using Zanella.MF7.Dominio.Features.Users;
using Zanella.MF7.Infra.ORM.Contexto;

namespace Zanella.MF7.Infra.ORM.Migrations
{
    public class MigrationConfiguration : DbMigrationsConfiguration<ZanellaDbContext>
    {
        public MigrationConfiguration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ZanellaDbContext context)
        {
            var _user = new User()
            {
                Id = 1,
                Name = "teste",
                Email = "teste@teste.com",
                Password = "123",
            };

            var foundUser = context.Users.Where(u => u.Email == _user.Email).FirstOrDefault();
            if (foundUser == null)
                context.Users.Add(_user);
            else
                context.Entry(foundUser).CurrentValues.SetValues(_user);
            context.SaveChanges();
        }
    }
}
