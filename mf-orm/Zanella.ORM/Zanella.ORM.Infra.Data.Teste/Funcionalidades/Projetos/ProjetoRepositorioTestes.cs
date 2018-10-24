using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Zanella.ORM.Common.Teste.Base;
using Zanella.ORM.Common.Teste.Funcionalidades;
using Zanella.ORM.Domain.Funcionalidades.Projetos;
using Zanella.ORM.Infra.Data.Contexto;
using Zanella.ORM.Infra.Data.Funcionalidades.Projetos;

namespace Zanella.ORM.Infra.Data.Teste.Funcionalidades.Projetos
{
    [TestFixture]
    public class ProjetoRepositorioTestes
    {
        private ORMContexto _contexto;
        private IProjetoRepositorio _repositorio;
        private Projeto _projeto;

        [SetUp]
        public void SetUp()
        {
            Database.SetInitializer(new BaseSqlTest());
            _contexto = new ORMContexto();
            _repositorio = new ProjetoRepositorio(_contexto);
            _contexto.Database.Initialize(true);
        }

        [Test]
        public void Projeto_InfraData_deve_inserir_registro_na_base()
        {
            _projeto = ObjectMother.ProjetoValido();

            Projeto NovoProjeto = _repositorio.Salvar(_projeto);

            NovoProjeto.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Projeto_InfraData_deve_atualizar_registro_na_base()
        {
            var idEsperado = 1;
            Projeto ProjetoObtido = _repositorio.PegarPorId(idEsperado);
            ProjetoObtido.NomeProjeto = "Provinha top";

            Projeto ProjetoEditado = _repositorio.Atualizar(ProjetoObtido);

            ProjetoEditado.NomeProjeto.Should().Be(ProjetoObtido.NomeProjeto);
        }

        [Test]
        public void Projeto_InfraData_deve_deletar_registro_na_base()
        {
            _projeto = ObjectMother.ProjetoValido();

            var projetoObtido = _repositorio.Salvar(_projeto);

            Projeto projeto = _repositorio.PegarPorId(projetoObtido.Id);

            _repositorio.Deletar(projeto);

            Projeto projetoEncontrado = _repositorio.PegarPorId(projeto.Id);
            projetoEncontrado.Should().BeNull();
        }

        [Test]
        public void Projeto_InfraData_deve_trazer_por_id_registro_na_base()
        {
            var idEsperado = 1;

            Projeto projetoObtido = _repositorio.PegarPorId(idEsperado);

            projetoObtido.Id.Should().Be(idEsperado);
        }

        [Test]
        public void Projeto_InfraData_deve_trazer_todos_registros_da_base()
        {
            IEnumerable<Projeto> ProjetosObtidos = _repositorio.PegarTodos();

            var qtdEsperado = 1;
            var idEsperado = 1;
            ProjetosObtidos.Count().Should().Be(qtdEsperado);
            ProjetosObtidos.First().Id.Should().Be(idEsperado);
        }
    }
}
