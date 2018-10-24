using FluentAssertions;
using MF6.API.Controllers.Impressoras;
using MF6.API.Exceptions;
using MF6.Application.Features.Impressoras;
using MF6.Common.Tests.Features.Impressoras;
using MF6.Controller.Tests.Initializer;
using MF6.Domain.Exceptions;
using MF6.Domain.Features.Impressoras;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace MF6.Controller.Tests.Features.Impressoras
{
    [TestFixture]
    class ImpressoraControllerTestes : TestControllerBase
    {
        private ImpressoraController _controller;
        private Mock<IImpressoraServico> _servico;
        private Mock<Impressora> _impressora;

        [SetUp]
        public void SetUp()
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.SetConfiguration(new HttpConfiguration());
            _servico = new Mock<IImpressoraServico>();
            _controller = new ImpressoraController()
            {
                Request = request,
                _impressoraServico = _servico.Object
            };
            _impressora = new Mock<Impressora>();
        }

        #region GET

        [Test]
        public void Impressora_Controller_PegarTodos_Deve_Funcionar()
        {
            Impressora impressora = ObjectMother.ImpressoraValida();
            var response = new List<Impressora>() { impressora }.AsQueryable();

            _servico.Setup(s => s.PegarTodos()).Returns(response);

            var result = _controller.Get();
            _servico.Verify(x => x.PegarTodos());
            var httpResponse = result.Should().BeOfType<OkNegotiatedContentResult<List<Impressora>>>().Subject;
            httpResponse.Content.Should().NotBeNullOrEmpty();
            httpResponse.Content.First().Id.Should().Be(impressora.Id);
        }

        [Test]
        public void Impressora_Controller_PegarPorId_DeveFuncionar()
        {
            var id = 1;
            _servico.Setup(c => c.PegarPorId(id)).Returns(_impressora.Object);

            IHttpActionResult callback = _controller.GetById(id);

            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<Impressora>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            _servico.Verify(s => s.PegarPorId(id), Times.Once);
        }

        #endregion

        #region POST

        [Test]
        public void Impressora_Controller_Post_DeveFuncionar()
        {
            var id = 1;
            _servico.Setup(c => c.Inserir(_impressora.Object)).Returns(id);

            IHttpActionResult callback = _controller.Post(_impressora.Object);

            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<int>>().Subject;
            httpResponse.Content.Should().Be(id);
            _servico.Verify(s => s.Inserir(_impressora.Object), Times.Once);
        }

        #endregion

        #region PUT

        [Test]
        public void Impressora_Controller_Put_DeveFuncionar()
        {
            var isUpdated = true;
            _servico.Setup(c => c.Atualizar(_impressora.Object)).Returns(isUpdated);

            IHttpActionResult callback = _controller.Update(_impressora.Object);

            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            httpResponse.Content.Should().BeTrue();
            _servico.Verify(s => s.Atualizar(_impressora.Object), Times.Once);
        }

        [Test]
        public void Impressora_Controller_Put_Id_nao_encontrado()
        {
            _servico.Setup(c => c.Atualizar(_impressora.Object)).Throws<NaoEncontradoException>();

            IHttpActionResult callback = _controller.Update(_impressora.Object);

            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<ExceptionPayload>>().Subject;
            httpResponse.Content.ErrorCode.Should().Be((int)ErrorCodes.NotFound);

            _servico.Verify(s => s.Atualizar(_impressora.Object), Times.Once);
        }

        #endregion

        #region DELETE

        [Test]
        public void Impressora_Controller_Delete_DeveFuncionar()
        {
            var isUpdated = true;
            _servico.Setup(c => c.Deletar(_impressora.Object)).Returns(isUpdated);

            IHttpActionResult callback = _controller.Delete(_impressora.Object);

            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            _servico.Verify(s => s.Deletar(_impressora.Object), Times.Once);
            httpResponse.Content.Should().BeTrue();
        }

        #endregion

        #region PATCH
        [Test]
        public void Impressora_Controller_Patch_AtulizarNivelTonerPreto_DeveFuncionar()
        {
            var isUpdated = true;
            var nivel = 66;
            _servico.Setup(c => c.AtualizarTonerPreto(_impressora.Object.Id, nivel)).Returns(isUpdated);

            IHttpActionResult callback = _controller.UpdateLevelBlack(_impressora.Object.Id, nivel);

            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            httpResponse.Content.Should().BeTrue();
            _servico.Verify(s => s.AtualizarTonerPreto(_impressora.Object.Id, nivel), Times.Once);
        }

        [Test]
        public void Impressora_Controller_Patch_AtulizarNivelTonerColor_DeveFuncionar()
        {
            var isUpdated = true;
            var nivel = 55;
            _servico.Setup(c => c.AtualizarTonerColorido(_impressora.Object.Id, nivel)).Returns(isUpdated);

            IHttpActionResult callback = _controller.UpdateLevelColor(_impressora.Object.Id, nivel);

            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            httpResponse.Content.Should().BeTrue();
            _servico.Verify(s => s.AtualizarTonerColorido(_impressora.Object.Id, nivel), Times.Once);
        }
        #endregion
    }
}
