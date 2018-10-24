using LuisZanellaProva.Dominio.Funcionalidades.Contatos;
using System;
using System.Collections.Generic;

namespace LuisZanellaProva.Dominio.Funcionalidades.Compromissos
{
    public class Compromisso : Entidade
    {
        public string Assunto { get; set; }
        public IList<Contato> Contatos { get; set; }
        public string Local { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public bool DiaTodo { get; set; }
        public Compromisso()
        {
            Contatos = new List<Contato>();
        }

        public override void Valida()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Assunto)))
                throw new InvalidOperationException("Não é permitido cadastrar Compromisso com Assunto vazio.");
            if (Assunto.Length > 100)
                throw new InvalidOperationException("Assunto deve ser menor ou igual a 100 caracteres!");

            //if (Contatos.Count < 1)
            //    throw new InvalidOperationException("Não é permitido cadastrar Compromisso sem Contatos.");

            if (string.IsNullOrEmpty(Local))
                throw new InvalidOperationException("Não é permitido cadastrar Compromisso com Local vazio.");
            if (Local.Length > 30)
                throw new InvalidOperationException("Local deve ser menor ou igual a 100 caracteres!");

        }

        public override string ToString()
        {
            return String.Format("{0} - {1} | {2} | ", Assunto, Local, DataInicial);
        }
    }
}
