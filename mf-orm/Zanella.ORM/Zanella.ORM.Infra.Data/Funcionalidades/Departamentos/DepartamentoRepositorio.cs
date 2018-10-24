using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Zanella.ORM.Domain.Funcionalidades.Departamentos;
using Zanella.ORM.Infra.Data.Contexto;

namespace Zanella.ORM.Infra.Data.Funcionalidades.Departamentos
{
    public class DepartamentoRepositorio : IDepartamentoRepositorio
    {
        private ORMContexto _contexto;

        public DepartamentoRepositorio(ORMContexto contexto)
        {
            _contexto = contexto;
        }

        public Departamento Atualizar(Departamento entidade)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                _contexto.Departamentos.Attach(entidade);
            }
            _contexto.SaveChanges();

            return entidade;
        }

        public void Deletar(Departamento entidade)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

            if (dbEntityEntry.State == EntityState.Detached)
                _contexto.Departamentos.Attach(entidade);

            _contexto.Departamentos.Remove(entidade);

            _contexto.SaveChanges();
        }

        public Departamento PegarPorId(long id)
        {
            return _contexto.Departamentos.Find(id);
        }

        public IEnumerable<Departamento> PegarTodos()
        {
            return _contexto.Departamentos.OrderBy(c => c.Descricao).ToList();
        }

        public IEnumerable<Departamento> PegarPorDescricao(string desc)
        {
            return _contexto.Departamentos.Where(c => c.Descricao.Contains(desc)).ToList();
        }

        public Departamento Salvar(Departamento entidade)
        {
            _contexto.Departamentos.Add(entidade);
            _contexto.SaveChanges();

            return entidade;
        }
    }
}
