using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zanella.ORM.Domain.Funcionalidades.Cargos;

namespace Zanella.ORM.Infra.Data.Funcionalidades.Cargos
{
    public class CargoConfiguracao : EntityTypeConfiguration<Cargo>
    {
        public CargoConfiguracao()
        {
            ToTable("TBCargo");


            //Property(p => p.Descricao).IsRequired();
            Property(p => p.Descricao).IsOptional();

            HasKey(a => a.Id);
        }
    }
}
