using System.Diagnostics.CodeAnalysis;
using Zanella.ORM.Domain.Excessoes;

namespace Zanella.ORM.Domain.Funcionalidades.Enderecos
{
    [ExcludeFromCodeCoverage]
    internal class EnderecoBairroVazioException : BusinessException
    {
        public EnderecoBairroVazioException() : base("Bairro não deve ser vazio")
        {
        }
}
}