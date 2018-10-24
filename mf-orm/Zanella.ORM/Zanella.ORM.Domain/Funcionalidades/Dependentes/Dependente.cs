using System.Collections.Generic;
using Zanella.ORM.Domain.Base;
using Zanella.ORM.Domain.Excessoes;
using Zanella.ORM.Domain.Funcionalidades.Funcionarios;

namespace Zanella.ORM.Domain.Funcionalidades.Dependentes
{
    public class Dependente : Entidade
    {
        public Dependente()
        {
            FuncionarioVinculado = new List<Funcionario>();
        }

        public string NomeDependente { get; set; }
        public int Idade { get; set; }

        public virtual List<Funcionario> FuncionarioVinculado { get; set; }

        public override void Validar()
        {
            if (string.IsNullOrEmpty(NomeDependente))
                throw new NomeVazioException();
            if (Idade < 0)
                throw new IdadeInvalidaException();
            if (FuncionarioVinculado.Count > 2)
                throw new VinculoFuncionarioException();
        }
    }
}
