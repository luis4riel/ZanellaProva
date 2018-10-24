using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zanella.ORM.Domain.Funcionalidades.Departamentos;

namespace Zanella.ORM.Infra.Data.Funcionalidades.Departamentos
{
    class DepartamentoConfiguracao : EntityTypeConfiguration<Departamento>
    {
        public DepartamentoConfiguracao()
        {
            ToTable("TBDepartamento");

            //Property(p => p.Descricao).IsRequired();
            Property(p => p.Descricao).IsOptional();

            HasKey(a => a.Id);
        }
    }
}
