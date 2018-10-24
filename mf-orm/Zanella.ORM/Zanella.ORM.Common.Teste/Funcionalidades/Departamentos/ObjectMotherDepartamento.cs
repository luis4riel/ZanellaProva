using Zanella.ORM.Domain.Funcionalidades.Departamentos;

namespace Zanella.ORM.Common.Teste.Funcionalidades
{
    public static partial class ObjectMother
    {
        public static Departamento DepartamentoValido()
        {
            return new Departamento()
            {
                Id = 1,
                Descricao = "Desenvolvimento"
            };
        }
    }
}
