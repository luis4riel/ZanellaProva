using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zanella.ORM.Domain.Funcionalidades.Projetos;

namespace Zanella.ORM.Infra.Data.Funcionalidades.Projetos
{
    public class ProjetoConfiguracao : EntityTypeConfiguration<Projeto>
    {
        public ProjetoConfiguracao()
        {
            ToTable("TBProjeto");

            Property(p => p.NomeProjeto).IsRequired();
            Property(p => p.DataDeInicio).IsRequired();

            HasKey(a => a.Id);
        }
    }
}
