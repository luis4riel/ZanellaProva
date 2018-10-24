using FluentAssertions;
using NUnit.Framework;
using ProvaTDD.Aplicacao.Features.Alunos;
using ProvaTDD.Common.Testes.Base;
using ProvaTDD.Common.Testes.Features;
using ProvaTDD.Dominio.Features.Alunos;
using ProvaTDD.Infra.Data.Features.Alunos;
using System.Collections.Generic;

namespace ProvaTDD.Intregacao.Sistema.Testes.Features.Alunos
{
    [TestFixture]
    public class AlunoIntegracaoSistemaTeste
    {
        AlunoServico alunoServico;
        IAlunoRepositorio repositorio;
        
        [SetUp]
        public void InitializeObjects()
        {
            repositorio = new AlunoRepositorio();
            alunoServico = new AlunoServico(repositorio);
            BaseSqlTest.SeedDatabase();
        }

        [Test]
        public void Aluno_IntegracaoSistema_Salvar_DeveSalvarOk()
        {
            Aluno aluno = ObjectMother.ObterAlunoValidoSemNota();
            aluno.Id = 0;

            Aluno result = alunoServico.Salvar(aluno);

            result.Id.Should().BeGreaterThan(0);
            IList<Aluno> AlunoList = (IList<Aluno>)alunoServico.PegarTodos();
            AlunoList.Contains(result).Should().BeTrue();
        }

        [Test]
        public void Aluno_IntegracaoSistema_Atualizar_DeveFuncionar()
        {
            var nome = "Luiszito";
            Aluno aluno = ObjectMother.ObterAlunoValidoSemNota();
            aluno.Nome= nome;

            Aluno result = alunoServico.Atualizar(aluno);

            result.Nome.Should().Be(nome);
        }

        [Test]
        public void Aluno_IntegracaoSistema_BuscaTodos_DeveFuncionar()
        {
            IList<Aluno> ListaAluno = new List<Aluno>();

            Aluno aluno = ObjectMother.ObterAlunoValidoSemNota();

            ListaAluno.Add(aluno);

            IList<Aluno> Result = (IList<Aluno>)alunoServico.PegarTodos();

            Result.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void Aluno_IntegracaoSistema_BuscaPorId_DeveFuncionar()
        {
            Aluno aluno = ObjectMother.ObterAlunoValidoSemNota();

            Aluno result = alunoServico.PegarPorId(aluno.Id);

            result.Should().NotBeNull();
            result.Id.Should().Be(1);

        }

        [Test]
        public void Aluno_IntegracaoSistema_Deletar_DeveFuncionar()
        {
            Aluno aluno = ObjectMother.ObterAlunoValidoSemNota();
            aluno = alunoServico.Salvar(aluno);

            alunoServico.Deletar(aluno);

            Aluno result = alunoServico.PegarPorId(aluno.Id);

            result.Should().BeNull();
        }
    }
}
