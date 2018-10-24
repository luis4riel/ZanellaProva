using FluentAssertions;
using MF6.Common.Tests.Features.Impressoras;
using MF6.Domain.Exceptions;
using MF6.Domain.Features.Impressoras;
using NUnit.Framework;
using System;

namespace MF6.Domain.Tests.Features.Impressoras
{
    [TestFixture]
    public class ImpressoraDominioTestes
    {
        private Impressora _impressora;

        [Test]
        public void Impressora_dominio_validar_deve_passar()
        {
            _impressora = ObjectMother.ImpressoraValida();

            Action action = () => _impressora.Validar();

            action.Should().NotThrow<BusinessException>();
        }

        [Test]
        public void Impressora_dominio_validar_deve_falhar_MarcaEmBranco()
        {
            _impressora = ObjectMother.ImpressoraValida();
            _impressora.Marca = "";

            Action action = () => _impressora.Validar();

            action.Should().Throw<CampoEmBrancoException>();
        }

        [Test]
        public void Impressora_dominio_validar_deve_falhar_IpEmBranco()
        {
            _impressora = ObjectMother.ImpressoraValida();
            _impressora.Ip = "";

            Action action = () => _impressora.Validar();

            action.Should().Throw<CampoEmBrancoException>();
        }

        [Test]
        public void Impressora_dominio_validar_deve_falhar_NivelColorido()
        {
            _impressora = ObjectMother.ImpressoraValida();
            _impressora.NivelTonerColorido = 150;

            Action action = () => _impressora.Validar();

            action.Should().Throw<NivelInvalidoException>();
        }

        [Test]
        public void Impressora_dominio_validar_deve_falhar_NivelPreto()
        {
            _impressora = ObjectMother.ImpressoraValida();
            _impressora.NivelTonerPreto = 150;

            Action action = () => _impressora.Validar();

            action.Should().Throw<NivelInvalidoException>();
        }
    }
}
