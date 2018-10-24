using FluentAssertions;
using MF6.Application.Features.Impressoras;
using MF6.Common.Tests.Features.Impressoras;
using MF6.Domain.Exceptions;
using MF6.Domain.Features.Impressoras;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MF6.Application.Tests.Features.Impressoras
{
    [TestFixture]
    public class ImpressoraServicoTestes
    {
        private ImpressoraServico _servico;
        private Mock<IImpressoraRepositorio> _repositorioFake;

        [SetUp]
        public void Initialize()
        {
            _repositorioFake = new Mock<IImpressoraRepositorio>();
            _servico = new ImpressoraServico(_repositorioFake.Object);
        }
      
        #region Add
        [Test]
        public void Impressora_servico_inserir_deve_funcionar()
        {
            var Impressora = ObjectMother.ImpressoraValidaSemId();
            _repositorioFake.Setup(pr => pr.Inserir(It.IsAny<Impressora>())).Returns(Impressora);

            var novaImpressoraId = _servico.Inserir(Impressora);

            _repositorioFake.Verify(pr => pr.Inserir(It.IsAny<Impressora>()), Times.Once);

            novaImpressoraId.Should().Be(Impressora.Id);
        }
        #endregion

        #region Get
        [Test]
        public void Impressora_servico_pegar_todos_deve_trazer_todos()
        {
            var Impressora = ObjectMother.ImpressoraValida();
            var repositoryMockValue = new List<Impressora>() { Impressora }.AsQueryable();
            _repositorioFake.Setup(pr => pr.PegarTodos()).Returns(repositoryMockValue);

            var listaImpressoras = _servico.PegarTodos();

            _repositorioFake.Verify(pr => pr.PegarTodos(), Times.Once);
            listaImpressoras.Should().NotBeNull();
            listaImpressoras.Count().Should().Be(repositoryMockValue.Count());
            listaImpressoras.First().Should().Be(repositoryMockValue.First());
        }

        [Test]
        public void Impressora_servico_pegar_por_id_deve_funcionar()
        {
            var Impressora = ObjectMother.ImpressoraValida();
            _repositorioFake.Setup(pr => pr.PegarPorId(Impressora.Id)).Returns(Impressora);

            var ImpressoraPega = _servico.PegarPorId(Impressora.Id);

            _repositorioFake.Verify(pr => pr.PegarPorId(Impressora.Id), Times.Once);
            ImpressoraPega.Should().NotBeNull();
            ImpressoraPega.Id.Should().Be(Impressora.Id);
        }
        
        [Test]
        public void Impressora_servico_pegar_por_id_deve_falhar_por_id_nao_encontrado()
        {
            var id = 999;
            var Impressora = ObjectMother.ImpressoraValida();
            _repositorioFake.Setup(pr => pr.PegarPorId(id)).Throws(new NaoEncontradoException());

            Action action = () => _servico.PegarPorId(id);

            action.Should().Throw<NaoEncontradoException>();
            _repositorioFake.Verify(pr => pr.PegarPorId(id), Times.Once);
        }

        [Test]
        public void Impressora_servico_pegar_por_id_deve_falhar_por_id_igual_zero()
        {
            var Impressora = ObjectMother.ImpressoraValida();
            Impressora.Id = 0;

            Action action = () => _servico.PegarPorId(Impressora.Id);

            action.Should().Throw<NaoEncontradoException>();
        }


        #endregion

        #region Delete
        [Test]
        public void Impressora_servico_deletar_deve_funcionar()
        {
            var Impressora = ObjectMother.ImpressoraValida();
            var retorno = true;
            _repositorioFake.Setup(pr => pr.Deletar(Impressora.Id)).Returns(retorno);

            var ImpressoraDeletada = _servico.Deletar(Impressora);

            _repositorioFake.Verify(pr => pr.Deletar(Impressora.Id), Times.Once);
            ImpressoraDeletada.Should().BeTrue();
        }

        [Test]
        public void Impressora_servico_deletar_id_nao_encontrado_deve_falhar()
        {
            var Impressora = ObjectMother.ImpressoraValida();
            Impressora.Id = 999;
            _repositorioFake.Setup(pr => pr.Deletar(Impressora.Id)).Throws<NaoEncontradoException>();

            Action action = () => _servico.Deletar(Impressora);

            action.Should().Throw<NaoEncontradoException>();
            _repositorioFake.Verify(pr => pr.Deletar(Impressora.Id), Times.Once);
        }

        [Test]
        public void Impressora_servico_deletar_id_zerado_deve_falhar()
        {
            var Impressora = ObjectMother.ImpressoraValidaSemId();

            Action action = () => _servico.Deletar(Impressora);

            action.Should().Throw<NaoEncontradoException>();
        }
        #endregion

        #region Put
        [Test]
        public void Impressora_servico_atualizar_deve_funcionar()
        {
            var Impressora = ObjectMother.ImpressoraValida();
            Impressora.Marca = "Kyocera";
            var isUpdated = true;
            _repositorioFake.Setup(pr => pr.PegarPorId(Impressora.Id)).Returns(Impressora);
            _repositorioFake.Setup(pr => pr.Atualizar(Impressora)).Returns(isUpdated);

            var ImpressoraAtualizada = _servico.Atualizar(Impressora);

            _repositorioFake.Verify(pr => pr.PegarPorId(Impressora.Id), Times.Once);
            _repositorioFake.Verify(pr => pr.Atualizar(Impressora), Times.Once);
            ImpressoraAtualizada.Should().BeTrue();
        }

        [Test]
        public void Impressora_servico_atualizar_deve_falhar_por_id_nao_encontrado()
        {
            var Impressora = ObjectMother.ImpressoraValida();
            _repositorioFake.Setup(pr => pr.PegarPorId(Impressora.Id)).Returns((Impressora)null);

            Action ImpressoraAction = () => _servico.Atualizar(Impressora);

            ImpressoraAction.Should().Throw<NaoEncontradoException>();

            _repositorioFake.Verify(pr => pr.PegarPorId(Impressora.Id), Times.Once);
            _repositorioFake.Verify(pr => pr.Atualizar(It.IsAny<Impressora>()), Times.Never);
        }
        #endregion

        #region patch
        [Test]
        public void Impressora_servico_atualizarTonerPreto_deve_funcionar()
        {
            var Impressora = ObjectMother.ImpressoraValida();
            var isUpdated = true;
            int nivel = 99;
            _repositorioFake.Setup(pr => pr.PegarPorId(Impressora.Id)).Returns(Impressora);
            _repositorioFake.Setup(pr => pr.Atualizar(Impressora)).Returns(isUpdated);

            var ImpressoraAtualizada = _servico.AtualizarTonerPreto(Impressora.Id, nivel);

            _repositorioFake.Verify(pr => pr.PegarPorId(Impressora.Id), Times.Once);
            _repositorioFake.Verify(pr => pr.Atualizar(Impressora), Times.Once);
            ImpressoraAtualizada.Should().BeTrue();
        }

        [Test]
        public void Impressora_servico_atualizarTonerColorido_deve_funcionar()
        {
            var Impressora = ObjectMother.ImpressoraValida();
            var isUpdated = true;
            int nivel = 99;
            _repositorioFake.Setup(pr => pr.PegarPorId(Impressora.Id)).Returns(Impressora);
            _repositorioFake.Setup(pr => pr.Atualizar(Impressora)).Returns(isUpdated);

            var ImpressoraAtualizada = _servico.AtualizarTonerColorido(Impressora.Id, nivel);

            _repositorioFake.Verify(pr => pr.PegarPorId(Impressora.Id), Times.Once);
            _repositorioFake.Verify(pr => pr.Atualizar(Impressora), Times.Once);
            ImpressoraAtualizada.Should().BeTrue();
        }


        [Test]
        public void Impressora_servico_atualizarTonerColorido_deve_falhar()
        {
            var Impressora = ObjectMother.ImpressoraValida();
            int nivel = 99;
            
            Action ImpressoraAtualizada = () => _servico.AtualizarTonerColorido(Impressora.Id, nivel);

            ImpressoraAtualizada.Should().Throw<NaoEncontradoException>();
        }

        [Test]
        public void Impressora_servico_atualizarTonerPreto_deve_falhar()
        {
            var Impressora = ObjectMother.ImpressoraValida();
            int nivel = 99;
            
            Action ImpressoraAtualizada = () => _servico.AtualizarTonerPreto(Impressora.Id, nivel);

            ImpressoraAtualizada.Should().Throw<NaoEncontradoException>();
        }


        [Test]
        public void Impressora_servico_atualizarTonerColorido_deve_falhar_id_zerado()
        {
            var Impressora = ObjectMother.ImpressoraValida();
            Impressora.Id = 0;
            int nivel = 99;

            Action ImpressoraAtualizada = () => _servico.AtualizarTonerColorido(Impressora.Id, nivel);

            ImpressoraAtualizada.Should().Throw<NaoEncontradoException>();
        }

        [Test]
        public void Impressora_servico_atualizarTonerPreto_deve_falhar_id_zerado()
        {
            var Impressora = ObjectMother.ImpressoraValida();
            Impressora.Id = 0;
            int nivel = 99;

            Action ImpressoraAtualizada = () => _servico.AtualizarTonerPreto(Impressora.Id, nivel);

            ImpressoraAtualizada.Should().Throw<NaoEncontradoException>();
        }


        #endregion
    }
}
