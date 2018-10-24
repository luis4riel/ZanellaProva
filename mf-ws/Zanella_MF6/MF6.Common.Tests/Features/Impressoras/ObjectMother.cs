using MF6.Domain.Features.Impressoras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF6.Common.Tests.Features.Impressoras
{
    public static partial class ObjectMother
    {
        public static Impressora ImpressoraValida()
        {
            return new Impressora
            {
                Id = 1,
                Marca = "Brother",
                Ip = "172.31.253.111",
                EmUso = false,
                NivelTonerColorido = 99,
                NivelTonerPreto = 50
            };
        }

        public static Impressora ImpressoraValidaSemId()
        {
            return new Impressora
            {
                Marca = "Brother",
                Ip = "172.31.253.111",
                EmUso = false,
                NivelTonerColorido = 99,
                NivelTonerPreto = 50
            };
        }
    }
}
