using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zanella.ORM.Domain.Funcionalidades.Funcionarios;

namespace Zanella.ORM.Infra.Data.Funcionalidades.Funcionarios
{
    public class FuncionarioConfiguracao : EntityTypeConfiguration<Funcionario>
    {
        public FuncionarioConfiguracao()
        {
            ToTable("TBFuncionario");

            Property(p => p.NomeFuncionario).IsRequired();

            Property(p => p.Endereco.Logradouro).IsRequired();
            Property(p => p.Endereco.Municipio).IsRequired();
            Property(p => p.Endereco.Bairro).IsRequired();

            Property(p => p.Cpf).IsOptional();

            HasKey(a => a.Id);
        }
    }
}
