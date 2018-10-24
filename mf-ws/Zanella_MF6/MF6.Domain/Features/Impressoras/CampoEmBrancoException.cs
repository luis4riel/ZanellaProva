using MF6.Domain.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace MF6.Domain.Features.Impressoras
{
    [ExcludeFromCodeCoverage]
    public class CampoEmBrancoException : BusinessException
    {
        public CampoEmBrancoException() : base(ErrorCodes.Unauthorized, "Não deve possuir Marca ou Ip em branco")
        {
        }
    }
}