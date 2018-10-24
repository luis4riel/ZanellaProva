using System.Diagnostics.CodeAnalysis;
using Zanella.ORM.Domain.Excessoes;

namespace Zanella.ORM.Domain.Funcionalidades.Dependentes
{
    [ExcludeFromCodeCoverage]
    internal class IdadeInvalidaException : BusinessException
    {
        public IdadeInvalidaException() : base("Idade não deve ser menor que 0")
        {
        }

    }
}