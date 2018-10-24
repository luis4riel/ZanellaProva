using ProvaTDD.Dominio.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace ProvaTDD.Dominio.Features.Avaliacoes
{
    [ExcludeFromCodeCoverage]
    public class AvaliacaoResultadoAlunoDuplicadoException : BusinessException
    {
        public AvaliacaoResultadoAlunoDuplicadoException() : base("Uma avaliação não deve conter dois resultados para o mesmo Aluno")
        {
        }
    }
}