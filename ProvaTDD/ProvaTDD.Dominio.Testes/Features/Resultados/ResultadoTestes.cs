using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using ProvaTDD.Common.Testes.Features;
using ProvaTDD.Dominio.Features.Alunos;
using ProvaTDD.Dominio.Features.Resultados;

namespace ProvaTDD.Dominio.Testes.Features.Resultados
{
    [TestFixture]
    public class ResultadoTestes
    {
        Resultado Resultado;
        Aluno Aluno;

        [SetUp]
        public void TestMethod1()
        {
            Resultado = new Resultado();
            Aluno = new Aluno();
        }

        [Test]
        public void Resultado_Dominio_DeveValidarOk()
        {
            Resultado.Aluno = ObjectMother.ObterAlunoValidoSemNota();
            var notaBoa = 1.0;
            var notaruim = 0.5;
            Resultado.Aluno.Notas.Add(notaBoa);
            Resultado.Aluno.Notas.Add(notaruim);
            Resultado.Nota = Aluno.CalcularMedia(Resultado.Aluno.Notas);

            Action action = () => Resultado.Validar();

            action.Should().NotThrow();
        }

        [Test]
        public void Resultado_Dominio_DeveEstourarExcessaoAoInserirAlunoVazio()
        {
            var notaBoa = 1.0;
            Resultado.Nota = notaBoa;

            Action action = () => Resultado.Validar();

            action.Should().Throw<ResultadoAlunoInvalidoException>();
        }

        [Test]
        public void Resultado_Dominio_DeveEstourarExcessaoAoInserirNotaInvalida()
        {

            Resultado.Aluno = ObjectMother.ObterAlunoValidoSemNota();

            Action action = () => Resultado.Validar();

            action.Should().Throw<ResultadoNotaInvalidaException>();
        }

    }
}
