using System.Data.Entity;
using Zanella.ORM.Common.Teste.Funcionalidades;
using Zanella.ORM.Domain.Funcionalidades.Cargos;
using Zanella.ORM.Domain.Funcionalidades.Departamentos;
using Zanella.ORM.Domain.Funcionalidades.Dependentes;
using Zanella.ORM.Domain.Funcionalidades.Funcionarios;
using Zanella.ORM.Domain.Funcionalidades.Projetos;
using Zanella.ORM.Infra.Data.Contexto;

namespace Zanella.ORM.Common.Teste.Base
{
    public class BaseSqlTest : DropCreateDatabaseAlways<ORMContexto>
    {
        protected override void Seed(ORMContexto contexto)
        {
            Cargo Cargo = ObjectMother.CargoValido();
            //contexto.Cargos.Add(Cargo);

            Departamento Dep = ObjectMother.DepartamentoValido();
            //contexto.Departamentos.Add(Dep);

            Dependente Dependente = ObjectMother.DependenteValido();
            contexto.Dependentes.Add(Dependente);

            Funcionario funcionario = ObjectMother.FuncionarioValido();
            //contexto.Funcionarios.Add(funcionario);

            Projeto projeto = ObjectMother.ProjetoValido();
            contexto.Projetos.Add(projeto);

            contexto.SaveChanges();

            base.Seed(contexto);
        }
    }
}
