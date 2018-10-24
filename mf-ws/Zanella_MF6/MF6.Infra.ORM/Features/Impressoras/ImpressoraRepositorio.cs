using MF6.Domain.Exceptions;
using MF6.Domain.Features.Impressoras;
using MF6.Infra.ORM.Contexts;
using System.Data.Entity;
using System.Linq;

namespace MF6.Infra.ORM.Features.Impressoras
{
    public class ImpressoraRepositorio : IImpressoraRepositorio
    {
        private MF6Context _contexto;

        public ImpressoraRepositorio(MF6Context contexto)
        {
            _contexto = contexto;
        }

        public bool Atualizar(Impressora impressora)
        {
            _contexto.Entry(impressora).State = EntityState.Modified;
            return _contexto.SaveChanges() > 0;
        }

        public bool Deletar(int ImpressoraId)
        {
            var impressora = _contexto.Impressoras.Where(o => o.Id == ImpressoraId).FirstOrDefault();

            if (impressora == null)
                throw new NaoEncontradoException();

            _contexto.Entry(impressora).State = EntityState.Deleted;
            return _contexto.SaveChanges() > 0;
        }

        public Impressora Inserir(Impressora impressora)
        {
            _contexto.Impressoras.Attach(impressora);
            var novaImpressora = _contexto.Impressoras.Add(impressora);
            _contexto.SaveChanges();
            return novaImpressora;
        }

        public Impressora PegarPorId(int impressoraId)
        {
            return _contexto.Impressoras.Find(impressoraId);
        }

        public IQueryable<Impressora> PegarTodos()
        {
            return _contexto.Impressoras.OrderBy(c => c.Id);
        }
    }
}
