using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using Zanella.ORM.Domain.Excessoes;

namespace Zanella.ORM.Domain.Funcionalidades.Dependentes
{
    [ExcludeFromCodeCoverage]
    internal class VinculoFuncionarioException : BusinessException
    {
        public VinculoFuncionarioException() : base("Deve ser permitido vinculo de até 2 funcionários")
        {
        }
     }
}