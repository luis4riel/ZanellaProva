using System.Collections.Generic;
using Zanella.ORM.Domain.Base;
using Zanella.ORM.Domain.Excessoes;
using Zanella.ORM.Domain.Funcionalidades.Cargos;
using Zanella.ORM.Domain.Funcionalidades.Departamentos;
using Zanella.ORM.Domain.Funcionalidades.Dependentes;
using Zanella.ORM.Domain.Funcionalidades.Enderecos;
using Zanella.ORM.Domain.Funcionalidades.Projetos;

namespace Zanella.ORM.Domain.Funcionalidades.Funcionarios
{
    public class Funcionario : Entidade
    {
        public Funcionario()
        {
            Cargo = new Cargo(); ;
            Departamento = new Departamento();
            Endereco = new Endereco();
            Projetos = new List<Projeto>();
        }

        public string Cpf { get; set; }
        public string NomeFuncionario { get; set; }
        public virtual Cargo Cargo { get; set; }
        public virtual Departamento Departamento { get; set; }
        public virtual Endereco Endereco { get; set; }
        public List<Projeto> Projetos { get; set; }

        public override void Validar()
        {
            if (string.IsNullOrEmpty(NomeFuncionario))
                throw new NomeVazioException();
        }
    }
}
