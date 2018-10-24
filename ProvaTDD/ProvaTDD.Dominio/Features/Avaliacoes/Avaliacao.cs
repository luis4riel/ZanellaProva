using ProvaTDD.Dominio.Base;
using ProvaTDD.Dominio.Features.Resultados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTDD.Dominio.Features.Avaliacoes
{
    public class Avaliacao : Entidade
    {
        public Avaliacao()
        {
            Resultados = new List<Resultado>();
        }

        public string Assunto { get; set; }
        public DateTime Data { get; set; }
        private IList<Resultado> Resultados { get; set; }

        public void AdicionarResultado(Resultado Resultado)
        {
            if (Resultados.Count() == 0)
                Resultados.Add(Resultado);
            else
            {
                foreach (var item in Resultados)
                {
                    if (Resultado.Aluno.Nome != item.Aluno.Nome)
                    {
                        Resultados.Add(Resultado); break;
                    }
                    else
                        throw new AvaliacaoResultadoAlunoDuplicadoException();

                }

                //for (int i = 0; i < Resultados.Count(); i++)
                //{
                //    if (Resultado.Aluno.Nome != Resultados[i].Aluno.Nome)
                //    {
                //        Resultados.Add(Resultado);
                //        break;
                //    }
                //    else
                //        throw new AvaliacaoResultadoAlunoDuplicadoException();
                //}
            }
        }

        public override void Validar()
        {
            if (string.IsNullOrEmpty(Assunto))
                throw new AvaliacaoAssuntoInvalidoException();
        }
    }
}
