using ProvaTDD.Dominio.Features.Alunos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTDD.Common.Testes.Features
{
    public static partial class ObjectMother
    {
        public static Aluno ObterAlunoValidoSemNota()
        {
            return new Aluno
            {
                Id = 1,
                Idade = 22,
                Nome = "Luis"
            };
        }

        public static Aluno ObterAlunoValidoDiferente()
        {
            return new Aluno
            {
                Idade = 30,
                Nome = "Diego"
            };
        }

    }
}
