using AutoMoq;
using FluentValidation;
using Moq;

using TechChallenge.Business.Dtos;
using TechChallenge.Business.Entities;
using TechChallenge.Business.Interfaces;
using TechChallenge.Business.Services;

namespace TechChallenge.Tests
{
    [Trait("Category", "RegiaoService")]
    [Collection("Regiao Collection")]
    public class RegiaoTests
    {
        private readonly RegiaoFixture _regiaoFixture;

        public RegiaoTests(RegiaoFixture regiaoFixture)
        {
            _regiaoFixture = regiaoFixture;
        }

        [Fact]
        [Trait("Type", "Unit")]
        public void Regiao_Com_Nome_Vazio_Deve_Retornar_Erro()
        {
            // Arrange
            var regiaoDto = new RegiaoDto
            {
                Nome = string.Empty
            };
            // Act
            var result = regiaoDto.Validate();
            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Região deve ser informada.", result.Errors.First().ErrorMessage);
        }

        [Fact]
        [Trait("Type", "Unit")]
        public void Regiao_Com_Nome_Valido_Nao_Deve_Retornar_Erro()
        {
            // Arrange
            var regiaoDto = new RegiaoDto
            {
                Nome = "Sudeste"
            };
            // Act
            var result = regiaoDto.Validate();
            // Assert
            Assert.True(result.IsValid);
        }
        
        [Fact]
        [Trait("Type", "Unit")]
        public void Regiao_Com_Erro_Nao_Deve_Ser_Inserida()
        {
            // Arrange
            var regiaoDto = new RegiaoDto
            {
                Nome = string.Empty
            };
            // Act
            _regiaoFixture.RegiaoService.Insert(regiaoDto);

            // Assert
            _regiaoFixture.Mocker.GetMock<IRegiaoRepository>().Verify(repo => repo.Insert((Regiao)regiaoDto), Times.Never());
        }

        [Fact]
        [Trait("Type", "Unit")]
        public async Task Regiao_Sem_Erro_Deve_Ser_Inserida()
        {
            // Arrange
            var regiaoDto = new RegiaoDto
            {
                Nome = "Regiao Teste"
            };

            _regiaoFixture.Mocker.GetMock<IRegiaoRepository>()
                .Setup(repo => repo.Insert(It.IsAny<Regiao>()))
                .ReturnsAsync(1); 

            // Act
            await _regiaoFixture.RegiaoService.Insert(regiaoDto);

            // Assert
            _regiaoFixture.Mocker.GetMock<IRegiaoRepository>()
                .Verify(repo => repo.Insert(It.IsAny<Regiao>()), Times.Once);
        }

        [Fact]
        [Trait("Type", "Unit")]
        public async Task Regiao_Com_Erro_Deve_Lancar_Excecao_De_Validacao()
        {
            // Arrange
            var regiaoDto = new RegiaoDto
            {
                Nome = ""
            };

            // Act & Assert
            await Assert.ThrowsAsync<ValidationException>(() => _regiaoFixture.RegiaoService.Insert(regiaoDto));
        }
    }

    public class RegiaoFixture : IDisposable
    {
        public AutoMoqer Mocker { get; private set; }
        public RegiaoService RegiaoService { get; private set; }

        public RegiaoFixture()
        {
            Mocker = new AutoMoqer();
            RegiaoService = Mocker.Resolve<RegiaoService>();
        }

        public void Dispose()
        {
        }
    }
}