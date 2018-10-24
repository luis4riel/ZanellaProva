using ProvaTDD.Dominio.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace ProvaTDD.Dominio.Features.Alunos
{
    [ExcludeFromCodeCoverage]
    public class AlunoIdadeInvalidaException : BusinessException
    {
        public AlunoIdadeInvalidaException() : base("A idade não pode ser menor que 0")
        {
        }

    }
}