using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Zanella.ORM.Domain.Funcionalidades.Cargos;
using Zanella.ORM.Infra.Data.Contexto;

namespace Zanella.ORM.Infra.Data.Funcionalidades.Cargos
{
    public class CargoRepositorio : ICargoRepositorio
    {
        private ORMContexto _contexto;

        public CargoRepositorio(ORMContexto contexto)
        {
            _contexto = contexto;
        }

        public Cargo Atualizar(Cargo entidade)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                _contexto.Cargos.Attach(entidade);
            }
            _contexto.SaveChanges();

            return entidade;
        }

        public void Deletar(Cargo entidade)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

            if (dbEntityEntry.State == EntityState.Detached)
                _contexto.Cargos.Attach(entidade);

            _contexto.Cargos.Remove(entidade);

            _contexto.SaveChanges();
        }

        public Cargo PegarPorId(long id)
        {
            return _contexto.Cargos.Find(id);
        }

        public IEnumerable<Cargo> PegarTodos()
        {
            return _contexto.Cargos.OrderBy(c => c.Descricao).ToList();
        }

        public Cargo Salvar(Cargo entidade)
        {
            _contexto.Cargos.Add(entidade);
            _contexto.SaveChanges();

            return entidade;
        }
    }
}
