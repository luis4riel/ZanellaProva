using FluentAssertions;
using NUnit.Framework;
using ProvaTDD.Common.Testes.Base;
using ProvaTDD.Common.Testes.Features;
using ProvaTDD.Dominio.Features.Alunos;
using ProvaTDD.Infra.Data.Features.Alunos;
using System.Collections.Generic;
using System.Linq;

namespace ProvaTDD.Infra.Data.Testes.Features.Alunos
{
    [TestFixture]
    public class AlunoRepositorioTestes
    {
        IAlunoRepositorio repositorio;
        Aluno aluno;

        [SetUp]
        public void SetUp()
        {
            BaseSqlTest.SeedDatabase();
            repositorio = new AlunoRepositorio();
            aluno = new Aluno();
        }

        [Test]
        public void Aluno_InfraData_Salvar_DeveInserirOK()
        {
            var idEsperado = 2;
            aluno = ObjectMother.ObterAlunoValidoSemNota();

            Aluno alunoInserido = repositorio.Salvar(aluno);

            alunoInserido.Id.Should().Be(idEsperado);
            alunoInserido.Nome.Should().Be("Luis");
        }

        [Test]
        public void Aluno_InfraData_Atualizar_DeveAtualizarOk()
        {
            var _novoNome = "Arthur";
            aluno = ObjectMother.ObterAlunoValidoSemNota();
            aluno = repositorio.Salvar(aluno);
            aluno.Nome = _novoNome;

            Aluno destinatarioAtualizado = repositorio.Atualizar(aluno);

            destinatarioAtualizado.Nome.Should().Be(_novoNome);
        }

        [Test]
        public void Aluno_InfraData_PegarTodos_DevePegarTodos()
        {
            aluno = ObjectMother.ObterAlunoValidoSemNota();
            aluno = repositorio.Salvar(aluno);

            IEnumerable<Aluno> alunos = repositorio.PegarTodos();

            alunos.Count().Should().BeGreaterThan(0);
            alunos.Last().Id.Should().Be(aluno.Id);
        }

        [Test]
        public void Aluno_InfraData_Deletar_DeveDeletarOk()
        {
            aluno = ObjectMother.ObterAlunoValidoSemNota();
            aluno = repositorio.Salvar(aluno);

            repositorio.Deletar(aluno);

            Aluno alunoEncontrado = repositorio.PegarPorId(aluno.Id);
            alunoEncontrado.Should().BeNull();
        }
    }
}
