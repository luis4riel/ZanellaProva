using System.Data.Entity.ModelConfiguration;
using System.Diagnostics.CodeAnalysis;
using Zanella.MF7.Dominio.Features.Users;

namespace Zanella.MF7.Infra.ORM.Features.Users
{
    [ExcludeFromCodeCoverage]
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            this.ToTable("TBUsuario");
            this.Property(o => o.Name).IsRequired();
            this.Property(o => o.Password).IsRequired();

            this.HasKey(o => o.Id);
        }
    }
}
