using Zanella.ORM.Domain.Funcionalidades.Cargos;

namespace Zanella.ORM.Common.Teste.Funcionalidades
{
    public static partial class ObjectMother
    {
        public static Cargo CargoValido()
        {
            return new Cargo()
            {
                Id = 1,
                Descricao = "Desenvolvedor"
            };
        }
    }
}
