using MF6.Domain.Features.Impressoras;
using System.Linq;

namespace MF6.Application.Features.Impressoras
{
    public interface IImpressoraServico
    {
        int Inserir(Impressora entidade);
        bool Atualizar(Impressora entidade);
        bool AtualizarTonerPreto(int id, int nivel);
        bool AtualizarTonerColorido(int id, int nivel);
        bool Deletar(Impressora entidade);
        IQueryable<Impressora> PegarTodos();
        Impressora PegarPorId(int id);
    }
}
