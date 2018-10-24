using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Zanella.ORM.Domain.Funcionalidades.Funcionarios;
using Zanella.ORM.Infra.Data.Contexto;

namespace Zanella.ORM.Infra.Data.Funcionalidades.Funcionarios
{
    public class FuncionarioRepositorio : IFuncionarioRepositorio
    {
        private ORMContexto _contexto;

        public FuncionarioRepositorio(ORMContexto contexto)
        {
            _contexto = contexto;
        }

        public Funcionario Atualizar(Funcionario entidade)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                _contexto.Funcionarios.Attach(entidade);
            }
            _contexto.SaveChanges();

            return entidade;
        }

        public void Deletar(Funcionario entidade)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

            if (dbEntityEntry.State == EntityState.Detached)
                _contexto.Funcionarios.Attach(entidade);

            _contexto.Funcionarios.Remove(entidade);

            _contexto.SaveChanges();
        }

        public Funcionario PegarPorId(long id)
        {
            return _contexto.Funcionarios.Find(id);
        }

        public IEnumerable<Funcionario> PegarPorNome(string desc)
        {
            return _contexto.Funcionarios.Where(c => c.NomeFuncionario.Contains(desc)).ToList();
        }

        public IEnumerable<Funcionario> PegarTodos()
        {
            return _contexto.Funcionarios.OrderBy(c => c.NomeFuncionario).ToList();
        }

        public Funcionario Salvar(Funcionario entidade)
        {
            _contexto.Funcionarios.Add(entidade);
            _contexto.SaveChanges();

            return entidade;
        }
    }
}
