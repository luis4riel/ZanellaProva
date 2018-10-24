using System.Collections.Generic;
using Zanella.ORM.Domain.Base;

namespace Zanella.ORM.Domain.Funcionalidades.Departamentos
{
    public interface IDepartamentoRepositorio : IRepositorio<Departamento>
    {
        IEnumerable<Departamento> PegarPorDescricao(string desc);
    }
}
