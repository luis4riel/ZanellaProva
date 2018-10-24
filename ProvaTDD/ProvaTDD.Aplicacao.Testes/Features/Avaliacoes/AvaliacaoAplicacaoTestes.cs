using FluentAssertions;
using Moq;
using NUnit.Framework;
using ProvaTDD.Aplicacao.Features.Avaliacoes;
using ProvaTDD.Common.Testes.Features;
using ProvaTDD.Dominio.Exceptions;
using ProvaTDD.Dominio.Features.Avaliacoes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProvaTDD.Aplicacao.Testes.Features.Avaliacoes
{
    [TestFixture]
    public class AvaliacaoAplicacaoTestes
    {
        AvaliacaoServico avaliacaoServico;
        Mock<IAvaliacaoRepositorio> mockRepositorio;

        [SetUp]
        public void InitializeObjects()
        {
            mockRepositorio = new Mock<IAvaliacaoRepositorio>();
            avaliacaoServico = new AvaliacaoServico(mockRepositorio.Object);
        }

        [Test]
        public void Avaliacao_Aplicacao_Salvar_DeveFuncionar()
        {
            Avaliacao avaliacao = ObjectMother.ObterAvaliacao();
            avaliacao.Id = 0;
            mockRepositorio.Setup(m => m.Salvar(avaliacao)).Returns(new Avaliacao { Id = 1 });

            Avaliacao result = avaliacaoServico.Salvar(avaliacao);

            result.Id.Should().BeGreaterThan(0);
            mockRepositorio.Verify(m => m.Salvar(avaliacao));
            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Avaliacao_Aplicacao_Atualizar_DeveFuncionar()
        {
            Avaliacao avaliacao = ObjectMother.ObterAvaliacao();
            var esperado = "OutraProvaTDD";
            avaliacao.Assunto = esperado;
            avaliacao.Id = 1;
            mockRepositorio.Setup(m => m.Atualizar(avaliacao)).Returns(avaliacao);

            Avaliacao avaliacaoObtida = avaliacaoServico.Atualizar(avaliacao);

            avaliacaoObtida.Assunto.Should().Be(esperado);
            mockRepositorio.Verify(m => m.Atualizar(avaliacao));
            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Avaliacao_Aplicacao_Atualizar_DeveEstourarExcessaoIdZerado()
        {
            Avaliacao avaliacao = ObjectMother.ObterAvaliacao();
 
            Action action = () => avaliacaoServico.Atualizar(avaliacao);

            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Avaliacao_Aplicacao_BuscaTodos_DeveFuncionar()
        {
            var id = 1;
            IList<Avaliacao> ListaAvaliacaos = new List<Avaliacao>();
            Avaliacao avaliacao = ObjectMother.ObterAvaliacao();
            avaliacao.Id = id;
            ListaAvaliacaos.Add(avaliacao);
            mockRepositorio.Setup(m => m.PegarTodos()).Returns(ListaAvaliacaos);

            IList<Avaliacao> listaDeAvaliacaos = avaliacaoServico.PegarTodos().ToList();

            listaDeAvaliacaos.First().Id.Should().Be(id);
            listaDeAvaliacaos.Count().Should().Be(id);
            mockRepositorio.Verify(m => m.PegarTodos());
            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Avaliacao_Aplicacao_BuscaPorId_DeveFuncionar()
        {
            var id = 1;
            Avaliacao avaliacao = ObjectMother.ObterAvaliacao();
            avaliacao.Id = id;
            mockRepositorio.Setup(m => m.PegarPorId(avaliacao.Id)).Returns(avaliacao);

            Avaliacao avaliacaoObtido = avaliacaoServico.PegarPorId(avaliacao.Id);

            avaliacaoObtido.Should().NotBeNull();
            avaliacaoObtido.Id.Should().Be(id);
            mockRepositorio.Verify(m => m.PegarPorId(avaliacao.Id));
            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Avaliacao_Aplicacao_BuscarPorId_DeveEstourarExcessaoIdZerado()
        {
            Avaliacao avaliacao = ObjectMother.ObterAvaliacao();

            Action action = () => avaliacaoServico.PegarPorId(avaliacao.Id);

            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Avaliacao_Aplicacao_Deletar_DeveFuncionar()
        {
            Avaliacao avaliacao = ObjectMother.ObterAvaliacao();
            avaliacao.Id = 1;
            mockRepositorio.Setup(m => m.Deletar(avaliacao));

            avaliacaoServico.Deletar(avaliacao);

            mockRepositorio.Verify(m => m.Deletar(avaliacao));
            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Avaliacao_Aplicacao_Deletar_DeveEstourarExcessaoIdZerado()
        {
            Avaliacao avaliacao = ObjectMother.ObterAvaliacao();

            Action action = () => avaliacaoServico.Deletar(avaliacao);

            action.Should().Throw<IdentifierUndefinedException>();
        }
    }
}
