using ProvaTDD.Aplicacao.Base;
using ProvaTDD.Dominio.Base;
using ProvaTDD.Dominio.Exceptions;
using ProvaTDD.Dominio.Features.Alunos;
using System.Collections.Generic;

namespace ProvaTDD.Aplicacao.Features.Alunos
{
    public class AlunoServico : Servico<Aluno>
    {

        public AlunoServico(IRepositorio<Aluno> repositorio) : base(repositorio)
        {
        }

        public override Aluno Atualizar(Aluno entidade)
        {
            if (entidade.Id == 0)
                throw new IdentifierUndefinedException();

            return base.Atualizar(entidade);
        }

        public override void Deletar(Aluno entidade)
        {
            if (entidade.Id == 0)
                throw new IdentifierUndefinedException();

            base.Deletar(entidade);
        }

        public override Aluno PegarPorId(long id)
        {
            if (id == 0)
                throw new IdentifierUndefinedException();

            return base.PegarPorId(id);
        }

        public override IEnumerable<Aluno> PegarTodos()
        {
            return base.PegarTodos();
        }

        public override Aluno Salvar(Aluno entidade)
        {
            return base.Salvar(entidade);
        }
    }
}
