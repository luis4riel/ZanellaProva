using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Zanella.ORM.Common.Teste.Base;
using Zanella.ORM.Common.Teste.Funcionalidades;
using Zanella.ORM.Domain.Funcionalidades.Funcionarios;
using Zanella.ORM.Infra.Data.Contexto;
using Zanella.ORM.Infra.Data.Funcionalidades.Funcionarios;

namespace Zanella.ORM.Infra.Data.Teste.Funcionalidades.Funcionarios
{
    [TestFixture]
    public class FuncionarioRepositorioTestes
    {
        private ORMContexto _contexto;
        private IFuncionarioRepositorio _repositorio;
        private Funcionario _funcionario;

        [SetUp]
        public void SetUp()
        {
            Database.SetInitializer(new BaseSqlTest());
            _contexto = new ORMContexto();
            _repositorio = new FuncionarioRepositorio(_contexto);
            _contexto.Database.Initialize(true);
        }

        [Test]
        public void Funcionario_InfraData_deve_inserir_registro_na_base()
        {
            _funcionario = ObjectMother.FuncionarioValido();

            Funcionario NovoFuncionario = _repositorio.Salvar(_funcionario);

            NovoFuncionario.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Funcionario_InfraData_deve_atualizar_registro_na_base()
        {
            var idEsperado = 1;
            Funcionario FuncionarioObtido = _repositorio.PegarPorId(idEsperado);
            FuncionarioObtido.NomeFuncionario = "Dieguera";

            Funcionario FuncionarioEditado = _repositorio.Atualizar(FuncionarioObtido);

            FuncionarioEditado.NomeFuncionario.Should().Be(FuncionarioObtido.NomeFuncionario);
        }

        [Test]
        public void Funcionario_InfraData_deve_deletar_registro_na_base()
        {
            _funcionario = ObjectMother.FuncionarioValido();

            var funcionarioObtido = _repositorio.Salvar(_funcionario);

            Funcionario funcionario = _repositorio.PegarPorId(funcionarioObtido.Id);

            _repositorio.Deletar(funcionario);

            Funcionario funcionarioEncontrado = _repositorio.PegarPorId(funcionario.Id);
            funcionarioEncontrado.Should().BeNull();
        }

        [Test]
        public void Funcionario_InfraData_deve_trazer_por_id_registro_na_base()
        {
            var idEsperado = 1;

            Funcionario funcionarioObtido = _repositorio.PegarPorId(idEsperado);

            funcionarioObtido.Id.Should().Be(idEsperado);
        }

        [Test]
        public void Funcionario_InfraData_deve_trazer_todos_registros_da_base()
        {
            IEnumerable<Funcionario> FuncionariosObtidos = _repositorio.PegarTodos();

            var qtdEsperado = 2;
            var idEsperado = 1;
            FuncionariosObtidos.Count().Should().Be(qtdEsperado);
            FuncionariosObtidos.First().Id.Should().Be(idEsperado);
        }

        [Test]
        public void Funcionario_InfraData_deve_trazer_todos_registros_da_base_pelo_nome()
        {
            var nome = "Luis";

            IEnumerable<Funcionario> FuncionariosObtidos = _repositorio.PegarPorNome(nome);

            var qtdEsperado = 2;
            FuncionariosObtidos.Count().Should().Be(qtdEsperado);
            FuncionariosObtidos.First().NomeFuncionario.ToLower().Contains(nome);
        }
    }
}
