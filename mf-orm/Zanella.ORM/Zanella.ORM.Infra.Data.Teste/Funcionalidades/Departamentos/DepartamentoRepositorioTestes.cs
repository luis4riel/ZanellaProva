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
using Zanella.ORM.Domain.Funcionalidades.Departamentos;
using Zanella.ORM.Infra.Data.Contexto;
using Zanella.ORM.Infra.Data.Funcionalidades.Departamentos;

namespace Zanella.ORM.Infra.Data.Teste.Funcionalidades.Departamentos
{
    [TestFixture]
    public class DepartamentoRepositorioTestes
    {
        private ORMContexto _contexto;
        private IDepartamentoRepositorio _repositorio;
        private Departamento _departamento;

        [SetUp]
        public void SetUp()
        {
            Database.SetInitializer(new BaseSqlTest());
            _contexto = new ORMContexto();
            _repositorio = new DepartamentoRepositorio(_contexto);
            _contexto.Database.Initialize(true);
        }

        [Test]
        public void Departamento_InfraData_deve_inserir_registro_na_base()
        {
            _departamento = ObjectMother.DepartamentoValido();

            Departamento NovoDepartamento = _repositorio.Salvar(_departamento);

            NovoDepartamento.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Departamento_InfraData_deve_atualizar_registro_na_base()
        {
            var idEsperado = 1;
            Departamento DepartamentoObtido = _repositorio.PegarPorId(idEsperado);
            DepartamentoObtido.Descricao = "Testadores";

            Departamento DepartamentoEditado = _repositorio.Atualizar(DepartamentoObtido);

            DepartamentoEditado.Descricao.Should().Be(DepartamentoObtido.Descricao);
        }

        [Test]
        public void Departamento_InfraData_deve_deletar_registro_na_base()
        {
            _departamento = ObjectMother.DepartamentoValido();

            var departamentoObtido = _repositorio.Salvar(_departamento);

            Departamento departamento = _repositorio.PegarPorId(departamentoObtido.Id);

            _repositorio.Deletar(departamento);

            Departamento departamentoEncontrado = _repositorio.PegarPorId(departamento.Id);
            departamentoEncontrado.Should().BeNull();
        }

        [Test]
        public void Departamento_InfraData_deve_trazer_por_id_registro_na_base()
        {
            var idEsperado = 1;

            Departamento departamentoObtido = _repositorio.PegarPorId(idEsperado);

            departamentoObtido.Id.Should().Be(idEsperado);
        }

        [Test]
        public void Departamento_InfraData_deve_trazer_todos_registros_da_base()
        {
            IEnumerable<Departamento> DepartamentosObtidos = _repositorio.PegarTodos();

            var qtdEsperado = 2;
            var idEsperado = 1;
            DepartamentosObtidos.Count().Should().Be(qtdEsperado);
            DepartamentosObtidos.First().Id.Should().Be(idEsperado);
        }

        [Test]
        public void Departamento_InfraData_deve_trazer_todos_registros_da_base_pela_descricao()
        {

            var desc = "Desenvolvimento";
            IEnumerable<Departamento> DepartamentosObtidos = _repositorio.PegarPorDescricao(desc);

            var qtdEsperado = 2;
            DepartamentosObtidos.Count().Should().Be(qtdEsperado);
            DepartamentosObtidos.First().Descricao.Contains(desc);
        }
    }
}
