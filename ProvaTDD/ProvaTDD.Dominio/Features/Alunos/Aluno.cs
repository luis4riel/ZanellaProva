using ProvaTDD.Dominio.Base;
using ProvaTDD.Dominio.Features.Resultados;
using System.Collections.Generic;
using System.Linq;

namespace ProvaTDD.Dominio.Features.Alunos
{
    public class Aluno : Entidade
    {
        public Aluno()
        {
            Notas = new List<double>();
        }

        public string Nome { get; set; }

        public int Idade { get; set; }

        public IList<double> Notas { get; set; }

        public double CalcularMedia(IList<double> Notas)
        {
            double NotasSomadas = 0;
            foreach (var item in Notas)
            {
                NotasSomadas += item;
            }

            var media = (NotasSomadas / Notas.Count());
            return CalcularArredondamento(media);
        }

        private double CalcularArredondamento(double media)
        {
            if (media < 0.35)
                media = 0;
            else if (media >= 0.35 && media < 0.55)
                media = 0.5;
            else if (media >= 0.55 && media < 0.75)
                media = 0.5;
            else if (media >= 0.75 && media < 1)
                media = 1;

            return media;
        }

        public override void Validar()
        {
            if (string.IsNullOrEmpty(Nome))
                throw new AlunoNomeVazioException();
            if (Idade < 10)
                throw new AlunoIdadeInvalidaException();
        }
    }
}
