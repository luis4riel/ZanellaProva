using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zanella.ORM.Domain.Funcionalidades.Dependentes;

namespace Zanella.ORM.Infra.Data.Funcionalidades.Dependentes
{
    public class DependenteConfiguracao : EntityTypeConfiguration<Dependente>
    {
        public DependenteConfiguracao()
        {
            ToTable("TBDependente");

            Property(p => p.NomeDependente).IsRequired();
            Property(p => p.Idade).IsRequired();

            HasKey(a => a.Id);
        }
    
    }
}
