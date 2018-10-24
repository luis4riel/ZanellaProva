using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zanella.ORM.Domain.Funcionalidades.Dependentes;
using Zanella.ORM.Infra.Data.Contexto;

namespace Zanella.ORM.Infra.Data.Funcionalidades.Dependentes
{
    public class DependenteRepositorio : IDependenteRepositorio
    {
        private ORMContexto _contexto;

        public DependenteRepositorio(ORMContexto contexto)
        {
            _contexto = contexto;
        }

        public Dependente Atualizar(Dependente entidade)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                _contexto.Dependentes.Attach(entidade);
            }
            _contexto.SaveChanges();

            return entidade;
        }

        public void Deletar(Dependente entidade)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

            if (dbEntityEntry.State == EntityState.Detached)
                _contexto.Dependentes.Attach(entidade);

            _contexto.Dependentes.Remove(entidade);

            _contexto.SaveChanges();
        }

        public Dependente PegarPorId(long id)
        {
            return _contexto.Dependentes.Find(id);
        }

        public IEnumerable<Dependente> PegarTodos()
        {
            return _contexto.Dependentes.OrderBy(c => c.NomeDependente).ToList();
        }

        public Dependente Salvar(Dependente entidade)
        {
            _contexto.Dependentes.Add(entidade);
            _contexto.SaveChanges();

            return entidade;
        }
    }
}
