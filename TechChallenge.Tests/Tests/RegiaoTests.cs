using FluentValidation;
using Moq;
using TechChallenge.Business.Dtos;
using TechChallenge.Business.Entities;
using TechChallenge.Business.Interfaces;
using TechChallenge.Business.Services;

namespace TechChallenge.Tests.Tests
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

        [Fact(DisplayName = "Validar Região Nome Inválido")]
        [Trait("Regiao", "Validador")]
        public void Regiao_Com_Nome_Vazio_Deve_Retornar_Erro()
        {
            // Arrange
            var regiaoDto = _regiaoFixture.CreateInvalidDto();
            string mensagemEsperada = "Região deve ser informada.";

            // Act
            var result = regiaoDto.Validate();
            // Assert
            Assert.False(result.IsValid);
            Assert.Equal(mensagemEsperada, result.Errors[0].ErrorMessage);
        }

        [Fact(DisplayName = "Validar Região Nome Null")]
        [Trait("Regiao", "Validador")]
        public void Regiao_Com_Nome_Null_Deve_Retornar_Erro()
        {
            // Arrange
            var regiaoDto = _regiaoFixture.CreateNullDto();
            string mensagemEsperada = "Região deve ser informada.";
  
            // Act
            var result = regiaoDto.Validate();
            // Assert
            Assert.False(result.IsValid);
            Assert.Equal(mensagemEsperada, result.Errors[0].ErrorMessage);
        }

        [Fact(DisplayName = "Validar Regiao OK")]
        [Trait("Regiao", "Validador")]
        public void Regiao_Com_Nome_Valido_Nao_Deve_Retornar_Erro()
        {
            // Arrange
            var regiaoDto = _regiaoFixture.CreateValidDto();
            // Act
            var result = regiaoDto.Validate();
            // Assert
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "Inserir Regiao Inválida")]
        [Trait("Regiao", "Insert")]
        public void Regiao_Com_Erro_Nao_Deve_Ser_Inserida()
        {
            // Arrange
            var regiaoDto = _regiaoFixture.CreateInvalidDto();
            // Act
            _regiaoFixture.RegiaoService.Insert(regiaoDto);

            // Assert
            _regiaoFixture.Mocker.GetMock<IRegiaoRepository>().Verify(repo => repo.Insert((Regiao)regiaoDto), Times.Never());
        }

        [Fact(DisplayName = "Inserir Regiao OK")]
        [Trait("Regiao", "Insert")]
        public async Task Regiao_Sem_Erro_Deve_Ser_Inserida()
        {
            // Arrange
            var regiaoDto = _regiaoFixture.CreateValidDto();

            _regiaoFixture.Mocker.GetMock<IRegiaoRepository>()
                .Setup(repo => repo.Insert(It.IsAny<Regiao>()))
                .ReturnsAsync(1);

            // Act
            await _regiaoFixture.RegiaoService.Insert(regiaoDto);

            // Assert
            _regiaoFixture.Mocker.GetMock<IRegiaoRepository>()
                .Verify(repo => repo.Insert(It.IsAny<Regiao>()), Times.Once);
        }

        [Fact(DisplayName = "Update Regiao Dto inválido")]
        [Trait("Regiao", "Update")]
        public async Task Inserir_Regiao_Com_Erro_Deve_Lancar_Excecao_De_Validacao()
        {
            // Arrange
            var regiaoDto = _regiaoFixture.CreateInvalidDto();

            // Act & Assert
            await Assert.ThrowsAsync<ValidationException>(() => _regiaoFixture.RegiaoService.Update(regiaoDto));
        }

        [Fact(DisplayName = "Update Regiao OK")]
        [Trait("Regiao", "Update")]
        public async Task Regiao_Sem_Erro_Deve_Ser_Alterada()
        {
            // Arrange
            var regiaoDto = _regiaoFixture.CreateValidDto();

            _regiaoFixture.Mocker.GetMock<IRegiaoRepository>()
                .Setup(repo => repo.Update(It.IsAny<Regiao>()));

            _regiaoFixture.Mocker.GetMock<IRegiaoRepository>()
                .Setup(repo => repo.GetById(regiaoDto.Id))
                .Returns(Task.FromResult((Regiao)_regiaoFixture.CreateValidDto()));


            // Act
            await _regiaoFixture.RegiaoService.Update(regiaoDto);

            // Assert
            _regiaoFixture.Mocker.GetMock<IRegiaoRepository>()
                .Verify(repo => repo.Update(It.IsAny<Regiao>()), Times.Once);
        }

        [Fact(DisplayName ="Update Regiao Id não encontrado")]
        [Trait("Regiao", "Update")]
        public async Task Alterar_Regiao_Com_Entidade_Nao_Encontrada_Deve_Lancar_Excecao()
        {
            // Arrange
            var regiaoDto = _regiaoFixture.CreateValidDto();

            _regiaoFixture.Mocker.GetMock<IRegiaoRepository>()
                .Setup(repo => repo.Update(It.IsAny<Regiao>()));

            _regiaoFixture.Mocker.GetMock<IRegiaoRepository>()
                .Setup(repo => repo.GetById(regiaoDto.Id))
                .Returns(Task.FromResult<Regiao>(null));


            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(async () => await _regiaoFixture.RegiaoService.Update(regiaoDto));
        }

        [Fact(DisplayName = "Regiao GetById Ok")]
        [Trait("Regiao", "GetById")]
        public async Task GetById_Regiao_OK()
        {
            // Arrange
            var regiaoDto = _regiaoFixture.CreateValidDto();

            _regiaoFixture.Mocker.GetMock<IRegiaoRepository>()
               .Setup(repo => repo.GetById(regiaoDto.Id))
               .Returns(Task.FromResult((Regiao)_regiaoFixture.CreateValidDto()));


            // Act
            var retorno = await _regiaoFixture.RegiaoService.GetById(regiaoDto.Id);
            
            //Assert
            Assert.True(retorno is  RegiaoDto);
        }

        [Fact(DisplayName = "Regiao GetById Null")]
        [Trait("Regiao", "GetById")]
        public async Task GetById_Regiao_Null()
        {
            // Arrange
            var regiaoDto = _regiaoFixture.CreateValidDto();

            _regiaoFixture.Mocker.GetMock<IRegiaoRepository>()
               .Setup(repo => repo.GetById(regiaoDto.Id))
               .Returns(Task.FromResult((Regiao)null));

            // Act
            var retorno = await _regiaoFixture.RegiaoService.GetById(regiaoDto.Id);

            //Assert
            Assert.Null(retorno);
        }

        [Fact(DisplayName = "Regiao GetAll Ok")]
        [Trait("Regiao", "GetAll")]
        public async Task GetAll_Regiao_OK()
        {
            // Arrange
            var regioes = new List<Regiao>
            {
                (Regiao)_regiaoFixture.CreateValidDto(),
                (Regiao)_regiaoFixture.CreateValidDto(),
                (Regiao)_regiaoFixture.CreateValidDto(),
            };

            _regiaoFixture.Mocker.GetMock<IRegiaoRepository>()
               .Setup(repo => repo.GetAll())
               .ReturnsAsync(regioes);

            // Act
            var retorno = await _regiaoFixture.RegiaoService.GetAll();

            //Assert
            Assert.True(retorno is IEnumerable<RegiaoDto>);
            Assert.True(retorno.Any());
        }

        [Fact(DisplayName = "Regiao GetAll Vazio")]
        [Trait("Regiao", "GetAll")]
        public async Task GetByAll_Regiao_Null()
        {
            // Arrange
            var regioes = new List<Regiao>();


            _regiaoFixture.Mocker.GetMock<IRegiaoRepository>()
               .Setup(repo => repo.GetAll())
               .ReturnsAsync(regioes);

            // Act
            var retorno = await _regiaoFixture.RegiaoService.GetAll();

            //Assert
            Assert.True(retorno is IEnumerable<RegiaoDto>);
            Assert.False(retorno.Any());
        }

        [Fact(DisplayName = "Delete Regiao OK")]
        [Trait("Regiao", "Update")]
        public async Task Regiao_Sem_Erro_Deve_Ser_Excluida()
        {
            // Arrange
            var regiaoDto = _regiaoFixture.CreateValidDto();

            _regiaoFixture.Mocker.GetMock<IRegiaoRepository>()
                .Setup(repo => repo.Delete(It.IsAny<Regiao>()));

            _regiaoFixture.Mocker.GetMock<IRegiaoRepository>()
                .Setup(repo => repo.GetById(regiaoDto.Id))
                .Returns(Task.FromResult((Regiao)_regiaoFixture.CreateValidDto()));


            // Act
            await _regiaoFixture.RegiaoService.Delete(regiaoDto.Id);

            // Assert
            _regiaoFixture.Mocker.GetMock<IRegiaoRepository>()
                .Verify(repo => repo.Delete(It.IsAny<Regiao>()), Times.Once);
        }

        [Fact(DisplayName = "Delete Regiao Id não encontrado")]
        [Trait("Regiao", "Delete")]
        public async Task Excluir_Regiao_Com_Entidade_Nao_Encontrada_Deve_Lancar_Excecao()
        {
            // Arrange
            var regiaoDto = _regiaoFixture.CreateValidDto();

            _regiaoFixture.Mocker.GetMock<IRegiaoRepository>()
                .Setup(repo => repo.Delete((Regiao)regiaoDto));

            _regiaoFixture.Mocker.GetMock<IRegiaoRepository>()
                .Setup(repo => repo.GetById(regiaoDto.Id))
                .Returns(Task.FromResult<Regiao>(null));


            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(async () => await _regiaoFixture.RegiaoService.Delete(regiaoDto.Id));
        }
    }

    public class RegiaoFixture : FixtureBase<RegiaoDto>
    {
        public RegiaoService RegiaoService { get; private set; }
        public RegiaoFixture()
        {
            RegiaoService = Mocker.Resolve<RegiaoService>();
        }

        public override RegiaoDto CreateValidDto() => new RegiaoDto { Id = 1, Nome = "Nome Regiao" };
        public override RegiaoDto CreateInvalidDto() => new RegiaoDto { Nome = "" };
        public override RegiaoDto CreateNullDto() => new RegiaoDto();
    }
}