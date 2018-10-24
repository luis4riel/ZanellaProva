using System;
using System.Collections.Generic;
using Zanella.ORM.Domain.Base;
using Zanella.ORM.Domain.Excessoes;
using Zanella.ORM.Domain.Funcionalidades.Funcionarios;

namespace Zanella.ORM.Domain.Funcionalidades.Projetos
{
    public class Projeto : Entidade
    {
        public Projeto()
        {
            Equipe = new List<Funcionario>();
        }

        public string NomeProjeto { get; set; }
        public DateTime DataDeInicio { get; set; }
        public List<Funcionario> Equipe { get; set; }

        public override void Validar()
        {
            if (string.IsNullOrEmpty(NomeProjeto))
                throw new NomeVazioException();
            if (DataDeInicio.Date < DateTime.Now)
                throw new DataInvalidaException();

        }
    }
}
