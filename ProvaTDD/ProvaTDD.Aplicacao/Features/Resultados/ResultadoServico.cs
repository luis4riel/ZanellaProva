using ProvaTDD.Aplicacao.Base;
using ProvaTDD.Dominio.Base;
using ProvaTDD.Dominio.Exceptions;
using ProvaTDD.Dominio.Features.Resultados;
using System.Collections.Generic;

namespace ProvaTDD.Aplicacao.Features.Resultados
{
    public class ResultadoServico : Servico<Resultado>
    {
        public ResultadoServico(IRepositorio<Resultado> repositorio) : base(repositorio)
        {
        }

        public override Resultado Atualizar(Resultado entidade)
        {
            if (entidade.Id == 0)
                throw new IdentifierUndefinedException();
            return base.Atualizar(entidade);
        }

        public override void Deletar(Resultado entidade)
        {
            if (entidade.Id == 0)
                throw new IdentifierUndefinedException();
            base.Deletar(entidade);
        }

        public override Resultado PegarPorId(long id)
        {
            if (id == 0)
                throw new IdentifierUndefinedException();
            return base.PegarPorId(id);
        }

        public override IEnumerable<Resultado> PegarTodos()
        {
            return base.PegarTodos();
        }

        public override Resultado Salvar(Resultado entidade)
        {
            return base.Salvar(entidade);
        }
    }
}
