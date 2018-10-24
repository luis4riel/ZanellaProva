using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Zanella.ORM.Common.Teste.Base;
using Zanella.ORM.Common.Teste.Funcionalidades;
using Zanella.ORM.Domain.Funcionalidades.Cargos;
using Zanella.ORM.Infra.Data.Contexto;
using Zanella.ORM.Infra.Data.Funcionalidades.Cargos;

namespace Zanella.ORM.Infra.Data.Teste.Funcionalidades.Cargos
{
    [TestFixture]
    public class CargoRepositorioTestes
    {
        private ORMContexto _contexto;
        private ICargoRepositorio _repositorio;
        private Cargo _cargo;

        [SetUp]
        public void SetUp()
        {
            Database.SetInitializer(new BaseSqlTest());
            _contexto = new ORMContexto();
            _repositorio = new CargoRepositorio(_contexto);
            _contexto.Database.Initialize(true);
        }

        [Test]
        public void Cargo_InfraData_deve_inserir_registro_na_base()
        {
            _cargo = ObjectMother.CargoValido();

            Cargo NovoCargo = _repositorio.Salvar(_cargo);

            NovoCargo.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Cargo_InfraData_deve_atualizar_registro_na_base()
        {
            var idEsperado = 1;
            Cargo CargoObtido = _repositorio.PegarPorId(idEsperado);
            CargoObtido.Descricao = "Tester";

            Cargo CargoEditado = _repositorio.Atualizar(CargoObtido);

            CargoEditado.Descricao.Should().Be(CargoObtido.Descricao);
        }

        [Test]
        public void Cargo_InfraData_deve_deletar_registro_na_base()
        {
            _cargo = ObjectMother.CargoValido();

            var cargoObtido = _repositorio.Salvar(_cargo);
            
            Cargo cargo = _repositorio.PegarPorId(cargoObtido.Id);

            _repositorio.Deletar(cargo);

            Cargo cargoEncontrado = _repositorio.PegarPorId(cargo.Id);
            cargoEncontrado.Should().BeNull();
        }

        [Test]
        public void Cargo_InfraData_deve_trazer_por_id_registro_na_base()
        {
            var idEsperado = 1;

            Cargo cargoObtido = _repositorio.PegarPorId(idEsperado);

            cargoObtido.Id.Should().Be(idEsperado);
        }

        [Test]
        public void Cargo_InfraData_deve_trazer_todos_registros_da_base()
        {
            IEnumerable<Cargo> CargosObtidos = _repositorio.PegarTodos();

            var qtdEsperado = 2;
            var idEsperado = 1;
            CargosObtidos.Count().Should().Be(qtdEsperado);
            CargosObtidos.First().Id.Should().Be(idEsperado);
        }
    }
}
