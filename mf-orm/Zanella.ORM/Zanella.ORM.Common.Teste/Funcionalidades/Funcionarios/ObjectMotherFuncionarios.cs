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
        public static Funcionario FuncionarioValido()
        {
            return new Funcionario()
            {
                Id = 1,
                NomeFuncionario = "Luis",
                Departamento = DepartamentoValido(),
                Cargo = CargoValido(),
                Endereco = EnderecoValido(),
            };
        }
    }
}