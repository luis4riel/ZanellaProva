using ProvaTDD.Aplicacao.Base;
using ProvaTDD.Dominio.Base;
using ProvaTDD.Dominio.Exceptions;
using ProvaTDD.Dominio.Features.Avaliacoes;
using System.Collections.Generic;

namespace ProvaTDD.Aplicacao.Features.Avaliacoes
{
    public class AvaliacaoServico : Servico<Avaliacao>
    {

        public AvaliacaoServico(IRepositorio<Avaliacao> repositorio) : base(repositorio)
        {
        }

        public override Avaliacao Atualizar(Avaliacao entidade)
        {
            if (entidade.Id == 0)
                throw new IdentifierUndefinedException();

            return base.Atualizar(entidade);
        }

        public override void Deletar(Avaliacao entidade)
        {
            if (entidade.Id == 0)
                throw new IdentifierUndefinedException();

            base.Deletar(entidade);
        }

        public override Avaliacao PegarPorId(long id)
        {
            if (id == 0)
                throw new IdentifierUndefinedException();

            return base.PegarPorId(id);
        }

        public override IEnumerable<Avaliacao> PegarTodos()
        {
            return base.PegarTodos();
        }

        public override Avaliacao Salvar(Avaliacao entidade)
        {
            return base.Salvar(entidade);
        }
    }
}
