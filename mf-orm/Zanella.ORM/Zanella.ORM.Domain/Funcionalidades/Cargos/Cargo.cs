using Zanella.ORM.Domain.Base;
using Zanella.ORM.Domain.Excessoes;

namespace Zanella.ORM.Domain.Funcionalidades.Cargos
{
    public class Cargo : Entidade
    {
        public string Descricao { get; set; }

        public override void Validar()
        {
            if (string.IsNullOrEmpty(Descricao))
                throw new DescricaoInvalidaException();
        }
    }
}
