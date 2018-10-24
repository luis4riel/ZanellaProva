using System;

namespace LuisZanellaProva.Dominio.Funcionalidades.Contatos
{
    public class Contato : Entidade
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Departamento { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public override void Valida()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Nome)))
                throw new InvalidOperationException("Não é permitido cadastrar Contato com Nome vazio.");
            if (Nome.Length > 60)
                throw new InvalidOperationException("Nome deve ser menor ou igual a 60 caracteres!");

            if (string.IsNullOrEmpty(Email))
                throw new InvalidOperationException("Não é permitido cadastrar Contato com Email vazio.");
            if (Email.Length > 60)
                throw new InvalidOperationException("Email deve ser menor ou igual a 60 caracteres!");

            if (string.IsNullOrEmpty(Departamento))
                throw new InvalidOperationException("Não é permitido cadastrar Contato com Departamento vazio.");
            if (Departamento.Length > 30)
                throw new InvalidOperationException("Departamento deve ser menor ou igual a 30 caracteres!");

            if (string.IsNullOrEmpty(Endereco))
                throw new InvalidOperationException("Não é permitido cadastrar Contato com Endereço vazio.");
            if (Endereco.Length > 60)
                throw new InvalidOperationException("Endereço deve ser menor ou igual a 60 caracteres!");

            if (string.IsNullOrEmpty(Telefone))
                throw new InvalidOperationException("Não é permitido cadastrar Contato com Telefone vazio.");
            if (Telefone.Length > 20)
                throw new InvalidOperationException("Telefone deve ser menor ou igual a 20 caracteres!");
        }

        public override string ToString()
        {
            return String.Format("{0} - {1} | {2} | ({3}, {4})", Nome, Email, Departamento, Endereco, Telefone);
        }
    }
}
