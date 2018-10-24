using System.Collections.Generic;

namespace LuisZanellaProva.Dominio.Base
{
    public interface IRepository<T> where T : Entidade
    {
        T Adicionar(T novaEntidade);

        T Editar(T entidadeEditada);

        T SelecionaPorId(int id);

        List<T> SelecionaTudo();

        void Deletar(int id);
    }
}
