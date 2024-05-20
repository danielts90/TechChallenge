using TechChallenge.Business.Dtos;
using TechChallenge.Business.Interfaces;
using TechChallenge.Business.Services;

namespace TechChallenge.Tests.Tests
{
    [Trait("Category", "DddService")]
    [Collection("Ddd Collection")]
    public class DddTests(DddFixture dddFixture)
    {
        private readonly DddFixture _dddFixture = dddFixture;

        [Fact(DisplayName = "Validar Construtor")]
        [Trait("DDD", "Construtor")]
        public void Constructor_SetRepository()
        {
            //Arrange
            var mockRepo = _dddFixture.Mocker.GetMock<IDddRepository>();
            //Act
            var service = new DddService(mockRepo.Object);
            //Assert
            Assert.NotNull(service);
        }

        [Fact(DisplayName ="Validar DDD OK")]
        [Trait("DDD", "Validador")]
        public void Validar_Objeto_Sem_Erros()
        {
            //Arrange
            var ddd = _dddFixture.CreateValidDto();

            //Act
            var result = ddd.Validate();

            //Assert
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "Validadar DDD Qtd Dígitos")]
        [Trait("DDD", "Validador")]
        public void DDD_Digitos_Invalidos_Deve_Retornar_Erro()
        {
            //Arrange
            var ddd1 = new DddDto { Codigo = "0", RegiaoId = 1 };
            var ddd3 = new DddDto { Codigo = "012", RegiaoId = 1 };
            var mensagemEsperada = "O DDD deve ter dois dígitos.";

            //Act
            var result1 = ddd1.Validate();
            var result3 = ddd3.Validate();

            //Assert
            Assert.False(result1.IsValid);
            Assert.False(result3.IsValid);
            Assert.Equal(mensagemEsperada, result1.Errors[0].ErrorMessage);
            Assert.Equal(mensagemEsperada, result3.Errors[0].ErrorMessage);
        }

        [Fact(DisplayName = "Validadar DDD Invalido")]
        [Trait("DDD", "Validador")]
        public void DDD_Invalido_Deve_Retornar_Erros()
        {
            //Arrange
            var ddd = _dddFixture.CreateInvalidDto();
            var qtdErros = 2;

            //Act
            var result = ddd.Validate();
            //Assert
            Assert.False(result.IsValid);
            Assert.Equal(qtdErros, result.Errors.Count);
        }

        [Fact(DisplayName = "Validadar DDD Null")]
        [Trait("DDD", "Validador")]
        public void DDD_Null_Deve_Retornar_Erros()
        {
            //Arrange
            var ddd = _dddFixture.CreateNewDto();

            //Act
            var result = ddd.Validate();
            //Assert
            Assert.False(result.IsValid);
        }
    }

    public class DddFixture : FixtureBase<DddDto>
    {
        public DddService DddService { get; set; }

        public DddFixture()
        {
            DddService = Mocker.Resolve<DddService>();
        }
        public override DddDto CreateInvalidDto() => new() { Codigo = "", RegiaoId = null };
        public override DddDto CreateNewDto() => new();
        public override DddDto CreateValidDto() => new() { Codigo = "41", RegiaoId = 1, Id = 1 };
    }
 }

