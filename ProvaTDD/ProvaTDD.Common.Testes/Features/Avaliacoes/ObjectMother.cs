using ProvaTDD.Dominio.Features.Avaliacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTDD.Common.Testes.Features
{
    public static partial class ObjectMother
    {
        public static Avaliacao ObterAvaliacao()
        {
            return new Avaliacao()
            {
                Assunto = "ProvaTdd",
                Data = DateTime.Now,
            };
        }
    }
}