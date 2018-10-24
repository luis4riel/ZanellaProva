using FluentAssertions;
using NUnit.Framework;
using ProvaTDD.Common.Testes.Base;
using ProvaTDD.Common.Testes.Features;
using ProvaTDD.Dominio.Features.Avaliacoes;
using ProvaTDD.Infra.Data.Features.Avaliacoes;
using System.Collections.Generic;
using System.Linq;

namespace ProvaTDD.Infra.Data.Testes.Features.Avaliacoes
{

    [TestFixture]
    public class AvaliacaoRepositorioTestes
    {
        IAvaliacaoRepositorio repositorio;
        Avaliacao avaliacao;

        [SetUp]
        public void SetUp()
        {
            BaseSqlTest.SeedDatabase();
            repositorio = new AvaliacaoRepositorio();
            avaliacao = new Avaliacao();
        }

        [Test]
        public void Avaliacao_InfraData_Salvar_DeveInserirOK()
        {
            var idEsperado = 2;
            avaliacao = ObjectMother.ObterAvaliacao();

            Avaliacao avaliacaoInserido = repositorio.Salvar(avaliacao);

            avaliacaoInserido.Id.Should().Be(idEsperado);
            avaliacaoInserido.Assunto.Should().Be("ProvaTdd");
        }

        [Test]
        public void Avaliacao_InfraData_Atualizar_DeveAtualizarOk()
        {
            var _novoAssunto = "ProvaTop";
            avaliacao = ObjectMother.ObterAvaliacao();
            avaliacao = repositorio.Salvar(avaliacao);
            avaliacao.Assunto = _novoAssunto;

            Avaliacao destinatarioAtualizado = repositorio.Atualizar(avaliacao);

            destinatarioAtualizado.Assunto.Should().Be(_novoAssunto);
        }

        [Test]
        public void Avaliacao_InfraData_PegarTodos_DevePegarTodos()
        {
            avaliacao = ObjectMother.ObterAvaliacao();
            avaliacao = repositorio.Salvar(avaliacao);

            IEnumerable<Avaliacao> avaliacoes = repositorio.PegarTodos();

            avaliacoes.Count().Should().BeGreaterThan(0);
            avaliacoes.Last().Id.Should().Be(avaliacao.Id);
        }

        [Test]
        public void Avaliacao_InfraData_Deletar_DeveDeletarOk()
        {
            avaliacao = ObjectMother.ObterAvaliacao();
            avaliacao = repositorio.Salvar(avaliacao);

            repositorio.Deletar(avaliacao);

            Avaliacao avaliacaoEncontrada = repositorio.PegarPorId(avaliacao.Id);
            avaliacaoEncontrada.Should().BeNull();
        }
    }
}
