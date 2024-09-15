using APIAmbiental.Controllers;
using APIAmbiental.Models;
using APIAmbiental.Services;
using APIAmbiental.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AmbientalControllerTest.Test
{
    public class AmbientalControllerTest
    {
        private readonly Mock<ICondicoesAmbientaisService> _mockService;
        private readonly Mock<IMapper> _mockMapper;
        private readonly AmbientalController _controller;

        public AmbientalControllerTest()
        {
            _mockService = new Mock<ICondicoesAmbientaisService>();
            _mockMapper = new Mock<IMapper>();
            _controller = new AmbientalController(_mockService.Object, _mockMapper.Object);
        }

        [Fact]
        public void Get_ById_ReturnsCondicaoAmbiental()
        {
            // Arrange
            var model = new CondicoesAmbientaisModel { id = 1, desastreNatural = "INCÊNDIO", qualidadeAr = "Ruim", umidade = "22", temperatura = "30 graus", contatoEmergencia = "11945" };
            var viewModel = new CondicoesAmbientaisViewModel { id = 1, desastreNatural = "INCÊNDIO", qualidadeAr = "Ruim", umidade = "22", temperatura = "30 graus", contatoEmergencia = "11945" };

            _mockService.Setup(s => s.ObterCondicoesAmbientaisPorID(1)).Returns(model);
            _mockMapper.Setup(m => m.Map<CondicoesAmbientaisViewModel>(It.IsAny<CondicoesAmbientaisModel>())).Returns(viewModel);

            // Act
            var result = _controller.Get(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var resultViewModel = Assert.IsAssignableFrom<CondicoesAmbientaisViewModel>(okResult.Value);
            Assert.Equal(1, resultViewModel.id);
            Assert.Equal("INCÊNDIO", resultViewModel.desastreNatural);
        }

        [Fact]
        public void Get_ReturnsNoContent_WhenListIsNull()
        {
            // Arrange
            _mockService.Setup(s => s.ListarCondicoesAmbientais()).Returns((List<CondicoesAmbientaisModel>)null);

            // Act
            var result = _controller.Get();

            // Assert
            Assert.IsType<NoContentResult>(result.Result);
        }

        [Fact]
        public void Get_ReturnsNoContent_WhenListIsEmpty()
        {
            // Arrange
            var emptyList = new List<CondicoesAmbientaisModel>();
            _mockService.Setup(s => s.ListarCondicoesAmbientais()).Returns(emptyList);
            _mockMapper.Setup(m => m.Map<IEnumerable<CondicoesAmbientaisViewModel>>(It.IsAny<IEnumerable<CondicoesAmbientaisModel>>())).Returns(new List<CondicoesAmbientaisViewModel>());

            // Act
            var result = _controller.Get();

            // Assert
            Assert.IsType<NoContentResult>(result.Result);
        }

    }
}
