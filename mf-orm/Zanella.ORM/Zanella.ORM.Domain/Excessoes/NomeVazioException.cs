using System.Diagnostics.CodeAnalysis;

namespace Zanella.ORM.Domain.Excessoes
{
    [ExcludeFromCodeCoverage]
    internal class NomeVazioException : BusinessException
    {
        public NomeVazioException() : base("Não deve ter o nome vazio")
        {
        }

    }
}