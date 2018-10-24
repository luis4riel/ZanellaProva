using ProvaTDD.Dominio.Base;
using ProvaTDD.Dominio.Features.Alunos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTDD.Dominio.Features.Resultados
{
    public class Resultado : Entidade
    {
        public Aluno Aluno { get; set; }
        public double? Nota { get; set; }

        public override void Validar()
        {
            if (Aluno == null)
                throw new ResultadoAlunoInvalidoException();
            if (Nota == null)
                throw new ResultadoNotaInvalidaException();
        }
    }
}
