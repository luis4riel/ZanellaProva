using MF6.Domain.Exceptions;
using MF6.Domain.Features.Impressoras;
using System.Linq;

namespace MF6.Application.Features.Impressoras
{
    public class ImpressoraServico : IImpressoraServico
    {
        private readonly IImpressoraRepositorio _repositorio;

        public ImpressoraServico(IImpressoraRepositorio repositorioImpressora)
        {
            _repositorio = repositorioImpressora;
        }

        public int Inserir(Impressora impressora)
        {
            impressora.Validar();

            var novaImpressora = _repositorio.Inserir(impressora);

            return novaImpressora.Id;
        }

        public IQueryable<Impressora> PegarTodos()
        {
            return _repositorio.PegarTodos();
        }

        public Impressora PegarPorId(int id)
        {
            if (id < 1)
                throw new NaoEncontradoException();

            try
            {
                return _repositorio.PegarPorId(id);
            }
            catch (System.Exception)
            {

                throw new NaoEncontradoException();
            }
             
        }

        public bool Deletar(Impressora impressora)
        {
            if (impressora == null || impressora.Id < 1)
                throw new NaoEncontradoException();

            return _repositorio.Deletar(impressora.Id);
        }

        public bool Atualizar(Impressora Impressora)
        {
            var impressoraDb = _repositorio.PegarPorId(Impressora.Id) ?? throw new NaoEncontradoException();

            impressoraDb.Marca = Impressora.Marca;
            impressoraDb.Ip = Impressora.Ip;
            impressoraDb.EmUso = Impressora.EmUso;
            impressoraDb.NivelTonerColorido = Impressora.NivelTonerColorido;
            impressoraDb.NivelTonerPreto = Impressora.NivelTonerPreto;
            impressoraDb.Validar();

            return _repositorio.Atualizar(impressoraDb);
        }

        public bool AtualizarTonerPreto(int id, int nivel)
        {
            if (id < 1)
                throw new NaoEncontradoException();

            Impressora impressora = _repositorio.PegarPorId(id) ?? throw new NaoEncontradoException();

            impressora.NivelTonerPreto = nivel;
            return _repositorio.Atualizar(impressora);
        }

        public bool AtualizarTonerColorido(int id, int nivel)
        {
            if (id < 1)
                throw new NaoEncontradoException();

            Impressora impressora = _repositorio.PegarPorId(id) ?? throw new NaoEncontradoException();

            impressora.NivelTonerColorido = nivel;
            return _repositorio.Atualizar(impressora);
        }
    }
}
