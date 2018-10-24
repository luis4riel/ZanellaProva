using ProvaTDD.Dominio.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace ProvaTDD.Dominio.Features.Alunos
{
    [ExcludeFromCodeCoverage]
    public class AlunoNomeVazioException : BusinessException
    {
        public AlunoNomeVazioException() : base("O Nome do aluno não pode estar vazio")
        {
        }
    }
}