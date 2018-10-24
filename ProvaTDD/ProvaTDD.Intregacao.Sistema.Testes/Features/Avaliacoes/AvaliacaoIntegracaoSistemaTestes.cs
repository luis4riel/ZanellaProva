using FluentAssertions;
using NUnit.Framework;
using ProvaTDD.Aplicacao.Features.Avaliacoes;
using ProvaTDD.Common.Testes.Base;
using ProvaTDD.Common.Testes.Features;
using ProvaTDD.Dominio.Features.Avaliacoes;
using ProvaTDD.Infra.Data.Features.Avaliacoes;
using System.Collections.Generic;

namespace ProvaTDD.Intregacao.Sistema.Testes.Features.Avaliacoes
{
    [TestFixture]
    public class AvaliacaoIntegracaoSistemaTeste
    {
        AvaliacaoServico avaliacaoServico;
        IAvaliacaoRepositorio repositorio;

        [SetUp]
        public void InitializeObjects()
        {
            repositorio = new AvaliacaoRepositorio();
            avaliacaoServico = new AvaliacaoServico(repositorio);
            BaseSqlTest.SeedDatabase();
        }

        [Test]
        public void Avaliacao_IntegracaoSistema_Salvar_DeveSalvarOk()
        {
            Avaliacao avaliacao = ObjectMother.ObterAvaliacao();
            avaliacao.Id = 0;

            Avaliacao result = avaliacaoServico.Salvar(avaliacao);

            result.Id.Should().BeGreaterThan(0);
            IList<Avaliacao> AvaliacaoList = (IList<Avaliacao>)avaliacaoServico.PegarTodos();
            AvaliacaoList.Contains(result).Should().BeTrue();
        }

        [Test]
        public void Avaliacao_IntegracaoSistema_Atualizar_DeveFuncionar()
        {
            var assunto = "NovaProvaTDD²";
            Avaliacao avaliacao = ObjectMother.ObterAvaliacao();
            avaliacao.Assunto = assunto;
            avaliacao.Id = 1;

            Avaliacao result = avaliacaoServico.Atualizar(avaliacao);

            result.Assunto.Should().Be(assunto);
        }

        [Test]
        public void Avaliacao_IntegracaoSistema_BuscaTodos_DeveFuncionar()
        {
            IList<Avaliacao> ListaAvaliacao = new List<Avaliacao>();
            Avaliacao avaliacao = ObjectMother.ObterAvaliacao();
            ListaAvaliacao.Add(avaliacao);

            IList<Avaliacao> Result = (IList<Avaliacao>)avaliacaoServico.PegarTodos();

            Result.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void Avaliacao_IntegracaoSistema_BuscaPorId_DeveFuncionar()
        {
            var id = 1;
            Avaliacao avaliacao = ObjectMother.ObterAvaliacao();
            avaliacao.Id = id;
            Avaliacao result = avaliacaoServico.PegarPorId(avaliacao.Id);

            result.Should().NotBeNull();
            result.Id.Should().Be(id);

        }

        [Test]
        public void Avaliacao_IntegracaoSistema_Deletar_DeveFuncionar()
        {
            Avaliacao avaliacao = ObjectMother.ObterAvaliacao();
            avaliacao = avaliacaoServico.Salvar(avaliacao);

            avaliacaoServico.Deletar(avaliacao);

            Avaliacao result = avaliacaoServico.PegarPorId(avaliacao.Id);

            result.Should().BeNull();
        }
    }
}
