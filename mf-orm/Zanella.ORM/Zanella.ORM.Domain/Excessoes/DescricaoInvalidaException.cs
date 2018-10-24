using System.Diagnostics.CodeAnalysis;

namespace Zanella.ORM.Domain.Excessoes
{
    [ExcludeFromCodeCoverage]
    internal class DescricaoInvalidaException : BusinessException
    {
        public DescricaoInvalidaException() : base("Descrição não deve ser vazio")
        {
        }
    }
}