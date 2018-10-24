namespace Zanella.ORM.Domain.Funcionalidades.Enderecos
{
    public class Endereco
    {
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public string Complemento { get; set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Logradouro))
                throw new EnderecoLogradouroVazioException();
            if (string.IsNullOrEmpty(Bairro))
                throw new EnderecoBairroVazioException();
            if (string.IsNullOrEmpty(Complemento))
                throw new EnderecoComplementoVazioException();
            if (string.IsNullOrEmpty(Numero))
                Numero = "s/n";
        }
    }
}
