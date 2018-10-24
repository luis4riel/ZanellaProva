using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using ProvaTDD.Common.Testes.Features;
using ProvaTDD.Dominio.Features.Avaliacoes;

namespace ProvaTDD.Dominio.Testes.Features.Avaliacoes
{
    [TestFixture]
    public class AvaliacaoTestes
    {
        Avaliacao Avaliacao;

        [SetUp]
        public void TestMethod1()
        {
            Avaliacao = new Avaliacao();
        }

        [Test]
        public void Avaliacao_Dominio_Validar_DeveValidarOK()
        {
            Avaliacao.Assunto = "Prova de TDD";
            Avaliacao.Data = DateTime.Now;
            Avaliacao.AdicionarResultado(ObjectMother.ObterResultadoValidoNotaBoa());

            Action action = () => Avaliacao.Validar();

            action.Should().NotThrow();
        }

        [Test]
        public void Avaliacao_Dominio_Validar_DeveValidarOKInserindoDoisResultadosDiferentes()
        {
            Avaliacao.Assunto = "Prova de TDD";
            Avaliacao.Data = DateTime.Now;
            Avaliacao.AdicionarResultado(ObjectMother.ObterResultadoValidoNotaBoa());
            Avaliacao.AdicionarResultado(ObjectMother.ObterResultadoValidoNotaBoaUsuarioDiferente());

            Action action = () => Avaliacao.Validar();

            action.Should().NotThrow();
        }

        [Test]
        public void Avaliacao_Dominio_Validar_DeveEstourarExcessaoAssuntoVazio()
        {
            Avaliacao.Assunto = "";
            Avaliacao.Data = DateTime.Now;
            Avaliacao.AdicionarResultado(ObjectMother.ObterResultadoValidoNotaBoa());

            Action action = () => Avaliacao.Validar();

            action.Should().Throw<AvaliacaoAssuntoInvalidoException>();
        }

        [Test]
        public void Avaliacao_Dominio_AdcionarResultado_DeveEstourarExcessaoInserirResultadoDuasVezesParaOMesmoAluno()
        {
            Avaliacao.Assunto = "";
            Avaliacao.Data = DateTime.Now;
            Avaliacao.AdicionarResultado(ObjectMother.ObterResultadoValidoNotaBoa());

            Action action = () => Avaliacao.AdicionarResultado(ObjectMother.ObterResultadoValidoNotaBoa());

            action.Should().Throw<AvaliacaoResultadoAlunoDuplicadoException>();
        }
    }
}
