using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using ProvaTDD.Aplicacao.Features.Alunos;
using ProvaTDD.Common.Testes.Features;
using ProvaTDD.Dominio.Exceptions;
using ProvaTDD.Dominio.Features.Alunos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProvaTDD.Aplicacao.Testes.Features.Alunos
{
    [TestClass]
    public class AlunoAplicacaoTestes
    {
        AlunoServico alunoServico;
        Mock<IAlunoRepositorio> mockRepositorio;
        
        [SetUp]
        public void InitializeObjects()
        {
            mockRepositorio = new Mock<IAlunoRepositorio>();
            alunoServico = new AlunoServico(mockRepositorio.Object);
        }

        [Test]
        public void Aluno_Aplicacao_Salvar_DeveFuncionar()
        {
            Aluno aluno = ObjectMother.ObterAlunoValidoSemNota();
            aluno.Id = 0;
            mockRepositorio.Setup(m => m.Salvar(aluno)).Returns(new Aluno { Id = 1 });
           
            Aluno result = alunoServico.Salvar(aluno);

            result.Id.Should().BeGreaterThan(0);
            mockRepositorio.Verify(m => m.Salvar(aluno));
            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Aluno_Aplicacao_Atualizar_DeveFuncionar()
        {
            Aluno aluno = ObjectMother.ObterAlunoValidoSemNota();
            var esperado = "Luisxyz";
            aluno.Nome = esperado;
            mockRepositorio.Setup(m => m.Atualizar(aluno)).Returns(aluno);
            
            Aluno alunoObtido = alunoServico.Atualizar(aluno);

            alunoObtido.Nome.Should().Be(esperado);
            mockRepositorio.Verify(m => m.Atualizar(aluno));
            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Aluno_Aplicacao_Atualizar_DeveEstourarExcessaoIdZerado()
        {
            Aluno aluno = ObjectMother.ObterAlunoValidoSemNota();
            aluno.Id = 0;

            Action action = () => alunoServico.Atualizar(aluno);

            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Aluno_Aplicacao_BuscaTodos_DeveFuncionar()
        {
            var id = 1;
            IList<Aluno> ListaAlunos = new List<Aluno>();
            Aluno aluno = ObjectMother.ObterAlunoValidoSemNota();
            ListaAlunos.Add(aluno);
            mockRepositorio.Setup(m => m.PegarTodos()).Returns(ListaAlunos);

            IList<Aluno> listaDeAlunos = alunoServico.PegarTodos().ToList();

            listaDeAlunos.First().Id.Should().Be(id);
            listaDeAlunos.Count().Should().Be(id);
            mockRepositorio.Verify(m => m.PegarTodos());
            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Aluno_Aplicacao_BuscaPorId_DeveFuncionar()
        {
            var id = 1;
            Aluno aluno = ObjectMother.ObterAlunoValidoSemNota();
            mockRepositorio.Setup(m => m.PegarPorId(aluno.Id)).Returns(aluno);

            Aluno alunoObtido = alunoServico.PegarPorId(aluno.Id);

            alunoObtido.Should().NotBeNull();
            alunoObtido.Id.Should().Be(id);
            mockRepositorio.Verify(m => m.PegarPorId(aluno.Id));
            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Aluno_Aplicacao_BuscarPorId_DeveEstourarExcessaoIdZerado()
        {
            Aluno aluno = ObjectMother.ObterAlunoValidoSemNota();
            aluno.Id = 0;

            Action action = () => alunoServico.PegarPorId(aluno.Id);

            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Aluno_Aplicacao_Deletar_DeveFuncionar()
        {
            Aluno aluno = ObjectMother.ObterAlunoValidoSemNota();
            mockRepositorio.Setup(m => m.Deletar(aluno));

            alunoServico.Deletar(aluno);

            mockRepositorio.Verify(m => m.Deletar(aluno));
            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Aluno_Aplicacao_Deletar_DeveEstourarExcessaoIdZerado()
        {
            Aluno aluno = ObjectMother.ObterAlunoValidoSemNota();
            aluno.Id = 0;

            Action action = () => alunoServico.Deletar(aluno);

            action.Should().Throw<IdentifierUndefinedException>();
        }
    }
}
