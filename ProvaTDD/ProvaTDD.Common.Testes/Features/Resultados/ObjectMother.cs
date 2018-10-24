using ProvaTDD.Dominio.Features.Resultados;


namespace ProvaTDD.Common.Testes.Features
{
    public static partial class ObjectMother
    {
        public static Resultado ObterResultadoValidoNotaBoa()
        {
            return new Resultado()
            {
                Id = 1,
                Aluno = ObterAlunoValidoSemNota(),
                Nota = 10
            };
        }
        public static Resultado ObterResultadoValidoNotaRuim()
        {
            return new Resultado()
            {
                Aluno = ObterAlunoValidoSemNota(),
                Nota = 5
            };
        }

        public static Resultado ObterResultadoValidoNotaBoaUsuarioDiferente()
        {
            return new Resultado()
            {
                Aluno = ObterAlunoValidoDiferente(),
                Nota = 5
            };
        }
    }
}
