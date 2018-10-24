using ProvaTDD.Dominio.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace ProvaTDD.Dominio.Features.Resultados
{
    [ExcludeFromCodeCoverage]
    public class ResultadoAlunoInvalidoException : BusinessException
    {
        public ResultadoAlunoInvalidoException() : base("O Aluno não deve ser nulo")
        {
        }
    }
}