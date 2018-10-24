using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Zanella.ORM.Domain.Funcionalidades.Projetos;
using Zanella.ORM.Infra.Data.Contexto;

namespace Zanella.ORM.Infra.Data.Funcionalidades.Projetos
{
    public class ProjetoRepositorio : IProjetoRepositorio
    {
        private ORMContexto _contexto;

        public ProjetoRepositorio(ORMContexto contexto)
        {
            _contexto = contexto;
        }

        public Projeto Atualizar(Projeto entidade)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                _contexto.Projetos.Attach(entidade);
            }
            _contexto.SaveChanges();

            return entidade;
        }

        public void Deletar(Projeto entidade)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

            if (dbEntityEntry.State == EntityState.Detached)
                _contexto.Projetos.Attach(entidade);

            _contexto.Projetos.Remove(entidade);

            _contexto.SaveChanges();
        }

        public Projeto PegarPorId(long id)
        {
            return _contexto.Projetos.Find(id);
        }

        public IEnumerable<Projeto> PegarTodos()
        {
            return _contexto.Projetos.OrderBy(c => c.NomeProjeto).ToList();
        }

        public Projeto Salvar(Projeto entidade)
        {
            _contexto.Projetos.Add(entidade);
            _contexto.SaveChanges();

            return entidade;
        }
    }
}
