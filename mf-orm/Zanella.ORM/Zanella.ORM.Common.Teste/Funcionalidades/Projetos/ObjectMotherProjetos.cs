using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zanella.ORM.Domain.Funcionalidades.Funcionarios;
using Zanella.ORM.Domain.Funcionalidades.Projetos;

namespace Zanella.ORM.Common.Teste.Funcionalidades
{
    public static partial class ObjectMother
    {
        public static Projeto ProjetoValido()
        {
            return new Projeto()
            {
                Id = 1,
                NomeProjeto = "Prova ORM",
                DataDeInicio = DateTime.Now,
                Equipe = new List<Funcionario> { FuncionarioValido() }
            };
        }
    }
}