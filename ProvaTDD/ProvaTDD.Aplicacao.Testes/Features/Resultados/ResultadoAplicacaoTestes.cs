using FluentAssertions;
using Moq;
using NUnit.Framework;
using ProvaTDD.Aplicacao.Features.Resultados;
using ProvaTDD.Common.Testes.Features;
using ProvaTDD.Dominio.Exceptions;
using ProvaTDD.Dominio.Features.Resultados;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProvaTDD.Aplicacao.Testes.Features.Resultados
{
    [TestFixture]
    public class ResultadoAplicacaoTestes
    {
        ResultadoServico resultadoServico;
        Mock<IResultadoRepositorio> mockRepositorio;

        [SetUp]
        public void InitializeObjects()
        {
            mockRepositorio = new Mock<IResultadoRepositorio>();
            resultadoServico = new ResultadoServico(mockRepositorio.Object);
        }

        [Test]
        public void Resultado_Aplicacao_Salvar_DeveFuncionar()
        {
            Resultado resultado = ObjectMother.ObterResultadoValidoNotaBoa();
            resultado.Id = 0;
            mockRepositorio.Setup(m => m.Salvar(resultado)).Returns(new Resultado { Id = 1 });

            Resultado result = resultadoServico.Salvar(resultado);

            result.Id.Should().BeGreaterThan(0);
            mockRepositorio.Verify(m => m.Salvar(resultado));
            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Resultado_Aplicacao_Atualizar_DeveFuncionar()
        {
            Resultado resultado = ObjectMother.ObterResultadoValidoNotaBoa();
            var notaEsperada = 1.0;
            resultado.Nota = notaEsperada;
            mockRepositorio.Setup(m => m.Atualizar(resultado)).Returns(resultado);

            Resultado resultadoObtido = resultadoServico.Atualizar(resultado);

            resultadoObtido.Nota.Should().Be(notaEsperada);
            mockRepositorio.Verify(m => m.Atualizar(resultado));
            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Resultado_Aplicacao_Atualizar_DeveEstourarExcessaoIdZerado()
        {
            Resultado resultado = ObjectMother.ObterResultadoValidoNotaBoa();
            resultado.Id = 0;

            Action action = () => resultadoServico.Atualizar(resultado);

            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Resultado_Aplicacao_BuscaTodos_DeveFuncionar()
        {
            var id = 1;
            IList<Resultado> ListaResultados = new List<Resultado>();
            Resultado resultado = ObjectMother.ObterResultadoValidoNotaBoa();
            resultado.Id = id;
            ListaResultados.Add(resultado);
            mockRepositorio.Setup(m => m.PegarTodos()).Returns(ListaResultados);

            IList<Resultado> listaDeResultados = resultadoServico.PegarTodos().ToList();

            listaDeResultados.First().Id.Should().Be(id);
            listaDeResultados.Count().Should().Be(id);
            mockRepositorio.Verify(m => m.PegarTodos());
            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Resultado_Aplicacao_BuscaPorId_DeveFuncionar()
        {
            var id = 1;
            Resultado resultado = ObjectMother.ObterResultadoValidoNotaBoa();
            resultado.Id = id;
            mockRepositorio.Setup(m => m.PegarPorId(resultado.Id)).Returns(resultado);

            Resultado resultadoObtido = resultadoServico.PegarPorId(resultado.Id);

            resultadoObtido.Should().NotBeNull();
            resultadoObtido.Id.Should().Be(id);
            mockRepositorio.Verify(m => m.PegarPorId(resultado.Id));
            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Resultado_Aplicacao_BuscarPorId_DeveEstourarExcessaoIdZerado()
        {
            Resultado resultado = ObjectMother.ObterResultadoValidoNotaBoa();
            resultado.Id = 0;

            Action action = () => resultadoServico.PegarPorId(resultado.Id);

            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Resultado_Aplicacao_Deletar_DeveFuncionar()
        {
            Resultado resultado = ObjectMother.ObterResultadoValidoNotaBoa();
            mockRepositorio.Setup(m => m.Deletar(resultado));

            resultadoServico.Deletar(resultado);

            mockRepositorio.Verify(m => m.Deletar(resultado));
            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Resultado_Aplicacao_Deletar_DeveEstourarExcessaoIdZerado()
        {
            Resultado resultado = ObjectMother.ObterResultadoValidoNotaBoa();
            resultado.Id = 0;

            Action action = () => resultadoServico.Deletar(resultado);

            action.Should().Throw<IdentifierUndefinedException>();
        }
    }
}
