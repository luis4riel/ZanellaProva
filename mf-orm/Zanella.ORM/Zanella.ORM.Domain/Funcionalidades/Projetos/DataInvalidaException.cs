using System.Diagnostics.CodeAnalysis;
using Zanella.ORM.Domain.Excessoes;

namespace Zanella.ORM.Domain.Funcionalidades.Projetos
{
    [ExcludeFromCodeCoverage]
    internal class DataInvalidaException : BusinessException
    {
        public DataInvalidaException() : base("Não deve ter a data menor que a atual")
        {
        }
    }
}