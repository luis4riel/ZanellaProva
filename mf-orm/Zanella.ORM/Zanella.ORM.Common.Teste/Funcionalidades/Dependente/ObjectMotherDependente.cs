using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zanella.ORM.Domain.Funcionalidades.Dependentes;
using Zanella.ORM.Domain.Funcionalidades.Funcionarios;

namespace Zanella.ORM.Common.Teste.Funcionalidades
{
    public static partial class ObjectMother
    {
        public static Dependente DependenteValido()
        {
            return new Dependente()
            {
                Id = 1,
                NomeDependente = "Carol",
                Idade = 20,
                FuncionarioVinculado = new List<Funcionario> { FuncionarioValido() }
            };
        }
    }
}
