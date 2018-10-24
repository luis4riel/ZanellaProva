using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zanella.ORM.Domain.Base
{
    public interface IRepositorio<T> where T : Entidade
    {
        T Salvar(T entidade);
        T Atualizar(T entidade);
        void Deletar(T entidade);
        IEnumerable<T> PegarTodos();
        T PegarPorId(long id);
    }
}
