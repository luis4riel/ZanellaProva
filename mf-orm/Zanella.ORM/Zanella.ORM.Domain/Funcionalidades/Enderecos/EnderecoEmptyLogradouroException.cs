using System.Diagnostics.CodeAnalysis;
using Zanella.ORM.Domain.Excessoes;

namespace Zanella.ORM.Domain.Funcionalidades.Enderecos
{
    [ExcludeFromCodeCoverage]
    internal class EnderecoLogradouroVazioException : BusinessException
    {
        public EnderecoLogradouroVazioException() : base("Logradouro não deve ser vazio")
        {
        }
    }
}