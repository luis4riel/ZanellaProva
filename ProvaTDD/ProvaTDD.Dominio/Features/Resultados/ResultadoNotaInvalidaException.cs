using ProvaTDD.Dominio.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace ProvaTDD.Dominio.Features.Resultados
{
    [ExcludeFromCodeCoverage]
    public class ResultadoNotaInvalidaException : BusinessException
    {
        public ResultadoNotaInvalidaException() : base("A nota não deve ser nulo")
        {
        }
    }
}