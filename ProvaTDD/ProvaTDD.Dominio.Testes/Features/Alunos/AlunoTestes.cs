using FluentAssertions;
using NUnit.Framework;
using ProvaTDD.Common.Testes.Features;
using ProvaTDD.Dominio.Features.Alunos;
using System;

namespace ProvaTDD.Dominio.Testes.Features.Alunos
{
    [TestFixture]
    public class AlunoTestes
    {
        Aluno Aluno;

        [SetUp]
        public void Setup()
        {
            Aluno = new Aluno();
        }

        [Test]
        public void Aluno_Dominio_Validar_DeveValidarNomeeIdadeOk()
        {
            Aluno = ObjectMother.ObterAlunoValidoSemNota();

            Action action = () => Aluno.Validar();

            action.Should().NotThrow();
        }

        [Test]
        public void Aluno_Dominio_CalcularMedia_DeveCalcularMediaUmPonto()
        {
            Aluno = ObjectMother.ObterAlunoValidoSemNota();
            var notaObtidaBoa = 1.0;
            var notaObtidaRuim = 0.5;
            Aluno.Notas.Add(notaObtidaBoa);
            Aluno.Notas.Add(notaObtidaRuim);
            var resultadoEsperado = 1;

            double mediaObtida = Aluno.CalcularMedia(Aluno.Notas);
            
            mediaObtida.Should().Be(resultadoEsperado);
        }

        [Test]
        public void Aluno_Dominio_CalcularMedia_DeveCalcularMediaUmPontoSegundaVerificacao()
        {
            Aluno = ObjectMother.ObterAlunoValidoSemNota();
            var notaObtidaBoa = 1.0;
            var notaObtidaBoaTambem = 1.0;
            Aluno.Notas.Add(notaObtidaBoa);
            Aluno.Notas.Add(notaObtidaBoaTambem);
            var resultadoEsperado = 1;

            double mediaObtida = Aluno.CalcularMedia(Aluno.Notas);

            mediaObtida.Should().Be(resultadoEsperado);
        }

        [Test]
        public void Aluno_Dominio_CalcularMedia_DeveCalcularMediaZerado()
        {
            Aluno = ObjectMother.ObterAlunoValidoSemNota();
            var notaObtidaRuim = 0.0;
            var notaObtidaRuimTambem = 0.0;
            Aluno.Notas.Add(notaObtidaRuim);
            Aluno.Notas.Add(notaObtidaRuimTambem);
            var resultadoEsperado = 0;

            double mediaObtida = Aluno.CalcularMedia(Aluno.Notas);

            mediaObtida.Should().Be(resultadoEsperado);
        }

        [Test]
        public void Aluno_Dominio_CalcularMedia_DeveCalcularMediaMeioPonto()
        {
            Aluno = ObjectMother.ObterAlunoValidoSemNota();
            var notaObtidaBoa = 0.5;
            var notaObtidaMaisouMenos = 0.5;
            Aluno.Notas.Add(notaObtidaBoa);
            Aluno.Notas.Add(notaObtidaMaisouMenos);
            var resultadoEsperado = 0.5;

            double mediaObtida = Aluno.CalcularMedia(Aluno.Notas);

            mediaObtida.Should().Be(resultadoEsperado);
        }

        [Test]
        public void Aluno_Dominio_CalcularMedia_DeveCalcularMediaMeioPontoSegundaVerificacao()
        {
            Aluno = ObjectMother.ObterAlunoValidoSemNota();
            var notaObtidaBoa = 0.75;
            var notaObtidaRuim = 0.5;
            Aluno.Notas.Add(notaObtidaBoa);
            Aluno.Notas.Add(notaObtidaRuim);
            var resultadoEsperado = 0.5;

            double mediaObtida = Aluno.CalcularMedia(Aluno.Notas);

            mediaObtida.Should().Be(resultadoEsperado);
        }

        [Test]
        public void Aluno_Dominio_Validar_DeveEstourarExcessaoNomeVazio()
        {
            Aluno.Nome = "";
            Aluno.Idade = 22;

            Action action = () => Aluno.Validar();

            action.Should().Throw<AlunoNomeVazioException>();
        }

        [Test]
        public void Aluno_Dominio_Validar_DeveEstourarExcessaoIdadeInvalida()
        {
            Aluno.Nome = "Luis";
            Aluno.Idade = 1;

            Action action = () => Aluno.Validar();

            action.Should().Throw<AlunoIdadeInvalidaException>();
        }

    }
}
