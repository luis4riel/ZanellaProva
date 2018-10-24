using MF6.Domain.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace MF6.Domain.Features.Impressoras
{
    [ExcludeFromCodeCoverage]
    public class NivelInvalidoException : BusinessException
    {
        public NivelInvalidoException() : base(ErrorCodes.Unauthorized, "O nivel deve estar entre 0% e 100%")
        {
        }
    }
}