using Effort;
using FluentAssertions;
using MF6.Common.Tests.Features.Impressoras;
using MF6.Domain.Exceptions;
using MF6.Domain.Features.Impressoras;
using MF6.Infra.ORM.Features.Impressoras;
using MF6.Infra.ORM.Tests.Contexts;
using MF6.Infra.ORM.Tests.Initializer;
using NUnit.Framework;
using System;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace MF6.Infra.ORM.Tests.Features.Impressoras
{
    [TestFixture]
    public class ImpressoraRepositorioTestes : EffortTestBase
    {
        private FakeDbContext _ctx;
        private ImpressoraRepositorio _repositorio;
        private Impressora _impressora;
        private Impressora _impressoraSeed;

        [SetUp]
        public void Setup()
        {
            var connection = DbConnectionFactory.CreatePersistent(Guid.NewGuid().ToString());
            _ctx = new FakeDbContext(connection);
            _repositorio = new ImpressoraRepositorio(_ctx);
            _impressora = ObjectMother.ImpressoraValida();
            _impressoraSeed = ObjectMother.ImpressoraValida();
            _ctx.Impressoras.Add(_impressoraSeed);

            _ctx.SaveChanges();
        }

        #region ADD
        [Test]
        public void Impressora_repositorio_inserir_deve_funcionar()
        {
            _impressora = ObjectMother.ImpressoraValidaSemId();
            
            var ImpressoraRegistrada = _repositorio.Inserir(_impressora);

            ImpressoraRegistrada.Should().NotBeNull();
            ImpressoraRegistrada.Id.Should().NotBe(0);
            var impressoraEsperada = _ctx.Impressoras.Find(ImpressoraRegistrada.Id);
            impressoraEsperada.Should().NotBeNull();
            impressoraEsperada.Should().Be(ImpressoraRegistrada);
        }

        #endregion

        #region GET
        
        [Test]
        public void Impressora_Repositorio_PegarTodos_DeveFuncionar()
        {
            var Impressora = _repositorio.PegarTodos().ToList();

            Impressora.Should().NotBeNull();
            Impressora.Should().HaveCount(_ctx.Impressoras.Count());
            Impressora.First().Should().Be(_impressoraSeed);
        }

        [Test]
        public void Impressora_Repositorio_PegarPorId_DeveFuncionar()
        {
            var Impressoras = _repositorio.PegarPorId(_impressoraSeed.Id);
            Impressoras.Should().NotBeNull();
            Impressoras.Should().Be(_impressoraSeed);
        }

        [Test]
        public void Impressora_Repositorio_PegarPorId_Deve_Retornar_Null()
        {
            var idNaoEncontrado = 10;
            var FuncionarioResult = _repositorio.PegarPorId(idNaoEncontrado);
            FuncionarioResult.Should().BeNull();
        }

        #endregion

        #region DELETE
        [Test]
        public void Impressora_repositorio_deletar_deve_funcionar()
        {
            var ImpressoraRemovida = _repositorio.Deletar(_impressora.Id);
            ImpressoraRemovida.Should().BeTrue();
            _ctx.Impressoras.Where(p => p.Id == _impressora.Id).FirstOrDefault().Should().BeNull();
        }

        [Test]
        public void Impressora_repositorio_deletar_deve_retornar_excecao_funcionarioId_desconhecido()
        {
            var idNaoEncontrado = 10;
            Action removeAction = () => _repositorio.Deletar(idNaoEncontrado);
            removeAction.Should().Throw<NaoEncontradoException>();
        }
        #endregion

        #region UPDATE

        [Test]
        public void Impressora_repositorio_atualizar_deve_funcionar()
        {
            var foiAtualizado = false;
            var novoNivel = 50;
            _impressoraSeed.NivelTonerColorido = novoNivel;

            var actionAtualizar = new Action(() => { foiAtualizado = _repositorio.Atualizar(_impressoraSeed); });

            actionAtualizar.Should().NotThrow<Exception>();
            foiAtualizado.Should().BeTrue();
        }

        [Test]
        public void Impressora_repositorio_atualizar_deve_retornar_excecao_funcionarioId_desconhecido()
        {
            _impressora = ObjectMother.ImpressoraValida();
            var idDesconhecido = 20;
            _impressora.Id = idDesconhecido;

            Action updatedAction = () => _repositorio.Atualizar(_impressora);

            updatedAction.Should().Throw<DbUpdateConcurrencyException>();
        }
        #endregion
    }
}
