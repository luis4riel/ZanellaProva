using ProvaTDD.Dominio.Exceptions;
using System;
using System.Diagnostics.CodeAnalysis;

namespace ProvaTDD.Dominio.Features.Avaliacoes
{
    [ExcludeFromCodeCoverage]
    public class AvaliacaoAssuntoInvalidoException : BusinessException
    {
        public AvaliacaoAssuntoInvalidoException() : base("O campo assunto não deve ser nulo")
        {
        }
    }
}