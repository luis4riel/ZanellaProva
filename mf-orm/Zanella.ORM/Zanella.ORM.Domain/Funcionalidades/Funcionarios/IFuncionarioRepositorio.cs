using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zanella.ORM.Domain.Base;

namespace Zanella.ORM.Domain.Funcionalidades.Funcionarios
{
    public interface IFuncionarioRepositorio : IRepositorio<Funcionario>
    {

        IEnumerable<Funcionario> PegarPorNome(string desc);
    }
}
