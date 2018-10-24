using FluentAssertions;
using NUnit.Framework;
using ProvaTDD.Common.Testes.Base;
using ProvaTDD.Common.Testes.Features;
using ProvaTDD.Dominio.Features.Resultados;
using ProvaTDD.Infra.Data.Features.Resultados;
using System.Collections.Generic;
using System.Linq;

namespace ProvaTDD.Infra.Data.Testes.Features.Resultados
{
    [TestFixture]
    public class ResultadoRepositorioTestes
    {
        IResultadoRepositorio repositorio;
        Resultado resultado;

        [SetUp]
        public void SetUp()
        {
            BaseSqlTest.SeedDatabase();
            repositorio = new ResultadoRepositorio();
            resultado = new Resultado();
        }

        [Test]
        public void Resultado_InfraData_Salvar_DeveInserirOK()
        {
            var idEsperado = 2;
            resultado = ObjectMother.ObterResultadoValidoNotaBoa();

            Resultado resultadoInserido = repositorio.Salvar(resultado);

            resultadoInserido.Id.Should().Be(idEsperado);
        }

        [Test]
        public void Resultado_InfraData_Atualizar_DeveAtualizarOk()
        {
            var _novoNota = 0.5;
            resultado = ObjectMother.ObterResultadoValidoNotaBoa();
            resultado = repositorio.Salvar(resultado);
            resultado.Nota = _novoNota;

            Resultado destinatarioAtualizado = repositorio.Atualizar(resultado);

            destinatarioAtualizado.Nota.Should().Be(_novoNota);
        }

        [Test]
        public void Resultado_InfraData_PegarTodos_DevePegarTodos()
        {
            resultado = ObjectMother.ObterResultadoValidoNotaBoa();
            resultado = repositorio.Salvar(resultado);

            IEnumerable<Resultado> resultados = repositorio.PegarTodos();

            resultados.Count().Should().BeGreaterThan(0);
            resultados.Last().Id.Should().Be(resultado.Id);
        }

        [Test]
        public void Resultado_InfraData_Deletar_DeveDeletarOk()
        {
            resultado = ObjectMother.ObterResultadoValidoNotaBoa();
            resultado = repositorio.Salvar(resultado);

            repositorio.Deletar(resultado);

            Resultado resultadoEncontrado = repositorio.PegarPorId(resultado.Id);
            resultadoEncontrado.Should().BeNull();
        }
    }
}
