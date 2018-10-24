using System;
using System.Diagnostics.CodeAnalysis;

namespace Zanella.ORM.Domain.Excessoes
{
    [ExcludeFromCodeCoverage]
    public class BusinessException : Exception
    {
        public BusinessException()
        {

        }

        public BusinessException(string message) : base(message)
        {

        }
    }
}
