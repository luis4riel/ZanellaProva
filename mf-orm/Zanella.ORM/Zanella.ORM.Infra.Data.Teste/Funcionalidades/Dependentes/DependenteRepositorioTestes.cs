using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zanella.ORM.Common.Teste.Base;
using Zanella.ORM.Common.Teste.Funcionalidades;
using Zanella.ORM.Domain.Funcionalidades.Dependentes;
using Zanella.ORM.Infra.Data.Contexto;
using Zanella.ORM.Infra.Data.Funcionalidades.Dependentes;

namespace Zanella.ORM.Infra.Data.Teste.Funcionalidades.Dependentes
{
    [TestFixture]
    public class DependenteRepositorioTestes
    {
        private ORMContexto _contexto;
        private IDependenteRepositorio _repositorio;
        private Dependente _dependente;

        [SetUp]
        public void SetUp()
        {
            Database.SetInitializer(new BaseSqlTest());
            _contexto = new ORMContexto();
            _repositorio = new DependenteRepositorio(_contexto);
            _contexto.Database.Initialize(true);
        }

        [Test]
        public void Dependente_InfraData_deve_inserir_registro_na_base()
        {
            _dependente = ObjectMother.DependenteValido();

            Dependente NovoDependente = _repositorio.Salvar(_dependente);

            NovoDependente.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Dependente_InfraData_deve_atualizar_registro_na_base()
        {
            var idEsperado = 1;
            Dependente DependenteObtido = _repositorio.PegarPorId(idEsperado);
            DependenteObtido.NomeDependente = "João";

            Dependente DependenteEditado = _repositorio.Atualizar(DependenteObtido);

            DependenteEditado.NomeDependente.Should().Be(DependenteObtido.NomeDependente);
        }

        [Test]
        public void Dependente_InfraData_deve_deletar_registro_na_base()
        {
            _dependente = ObjectMother.DependenteValido();

            var departamentoObtido = _repositorio.Salvar(_dependente);

            Dependente departamento = _repositorio.PegarPorId(departamentoObtido.Id);

            _repositorio.Deletar(departamento);

            Dependente departamentoEncontrado = _repositorio.PegarPorId(departamento.Id);
            departamentoEncontrado.Should().BeNull();
        }

        [Test]
        public void Dependente_InfraData_deve_trazer_por_id_registro_na_base()
        {
            var idEsperado = 1;

            Dependente departamentoObtido = _repositorio.PegarPorId(idEsperado);

            departamentoObtido.Id.Should().Be(idEsperado);
        }

        [Test]
        public void Dependente_InfraData_deve_trazer_todos_registros_da_base()
        {
            IEnumerable<Dependente> DependentesObtidos = _repositorio.PegarTodos();

            var qtdEsperado = 1;
            var idEsperado = 1;
            DependentesObtidos.Count().Should().Be(qtdEsperado);
            DependentesObtidos.First().Id.Should().Be(idEsperado);
        }
    }
}
