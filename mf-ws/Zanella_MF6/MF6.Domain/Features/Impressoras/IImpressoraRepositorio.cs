using System.Linq;

namespace MF6.Domain.Features.Impressoras
{
    public interface IImpressoraRepositorio
    {
        IQueryable<Impressora> PegarTodos();

        Impressora Inserir(Impressora impressora);

        bool Atualizar(Impressora impressora);

        Impressora PegarPorId(int impressoraId);

        bool Deletar(int impressoraId);
    }
}
