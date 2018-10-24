using System.Diagnostics.CodeAnalysis;
using Zanella.ORM.Domain.Excessoes;

namespace Zanella.ORM.Domain.Funcionalidades.Enderecos
{
    [ExcludeFromCodeCoverage]
    internal class EnderecoComplementoVazioException : BusinessException
    {
        public EnderecoComplementoVazioException() : base("Complemento não deve ser vazio")
        {
        }
    }
}