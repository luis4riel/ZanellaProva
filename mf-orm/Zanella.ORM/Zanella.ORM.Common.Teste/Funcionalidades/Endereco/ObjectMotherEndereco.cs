using Zanella.ORM.Domain.Funcionalidades.Enderecos;

namespace Zanella.ORM.Common.Teste.Funcionalidades
{
    public static partial class ObjectMother
    {
        public static Endereco EnderecoValido()
        {
            return new Endereco
            {
                Bairro = "Penha",
                Estado = "SC",
                Logradouro = "Olavo Bilac",
                Municipio = "Lages",
                Numero = "81",
                Complemento = "Casa Prox. ao Posto São Miguel"
            };
        }
    }
}
