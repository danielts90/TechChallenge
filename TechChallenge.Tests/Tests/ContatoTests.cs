using TechChallenge.Business.Dtos;
using TechChallenge.Business.Entities;
using TechChallenge.Business.Interfaces;
using TechChallenge.Business.Services;

namespace TechChallenge.Tests.Tests
{
    [Trait("Category", "ContatoService")]
    [Collection("Contato Collection")]
    public class ContatoTests(ContatoFixture contatoFixture)
    {
        private readonly ContatoFixture _contatoFixture = contatoFixture;

        [Fact(DisplayName = "Validar Construtor")]
        [Trait("Contato", "Construtor")]
        public void Constructor_SetRepository()
        {
            //Arrange
            var mockRepo = _contatoFixture.Mocker.GetMock<IContatoRepository>();
            //Act
            var service = new ContatoService(mockRepo.Object);
            //Assert
            Assert.NotNull(service);
        }

        [Fact(DisplayName = "Validar contato OK")]
        [Trait("Contato", "Validador Nome")]
        public void Contato_OK_Nao_Deve_Retornar_Erro()
        {
            // Arrange
            var contatoDto = _contatoFixture.CreateValidDto();

            // Act
            var result = contatoDto.Validate();

            // Assert           
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "Validar Contato Nao Ok")]
        [Trait("Contato", "Validador Nome")]
        public void Contato_ERRO_Deve_Retornar_Erro()
        {
            // Arrange
            var contatoDto = _contatoFixture.CreateInvalidDto();

            // Act
            var result = contatoDto.Validate();

            // Assert           
            Assert.False(result.IsValid);
        }

        [Fact(DisplayName = "Validar Contato com NOME Null")]
        [Trait("Contato", "Validador Nome")]
        public void Contato_Com_Nome_ERRO_Deve_Retornar_Erro()
        {
            // Arrange
            var contatoDto = _contatoFixture.CreateValidDto();
            contatoDto.Nome = "";
            string mensagemEsperada = "Obrigatório informar o nome do contato.";

            // Act
            var result = contatoDto.Validate();

            // Assert           
            Assert.False(result.IsValid);
            Assert.Equal(mensagemEsperada, result.Errors[0].ErrorMessage);
        }


        [Fact(DisplayName = "Validar Contato com TELEFONE Null")]
        [Trait("Contato", "Validador Telefone")]
        public void Contato_Com_Telefone_ERRO_Deve_Retornar_Erro()
        {
            // Arrange
            var contatoDto = _contatoFixture.CreateValidDto();
            contatoDto.Telefone = string.Empty;
            string mensagemEsperada = "O campo telefone é obrigatório";

            // Act
            var result = contatoDto.Validate();

            // Assert           
            Assert.False(result.IsValid);
            Assert.Equal(mensagemEsperada, result.Errors[0].ErrorMessage);
        }

        [Theory(DisplayName = "Validar Contato com TELEFONE Invalido")]
        [Trait("Contato", "Validador Telefone")]
        [InlineData("12345678910")]
        [InlineData("1234567")]
        [InlineData("1234-5678")]
        [InlineData(null)]
        public void Contato_Com_Telefone_INVALIDO_Deve_Retornar_Erro(string? telefone)
        {
            // Arrange
            var contatoDto = _contatoFixture.CreateValidDto();

            contatoDto.Telefone = telefone;

            string mensagemEsperada = "O telefone inválido, o número do telefone deve ter 8 ou 9 dígitos.";

            // Act
            var result = contatoDto.Validate();

            // Assert           
            Assert.False(result.IsValid);
            Assert.NotNull(result.Errors.FirstOrDefault(o => o.ErrorMessage == mensagemEsperada));
        }

        [Fact(DisplayName = "Validar Contato com EMAIL Invalido")]
        [Trait("Contato", "Validador Email")]
        public void Contato_Com_Email_Null_Deve_Retornar_Erro()
        {
            // Arrange
            var contatoDto = _contatoFixture.CreateValidDto();
            contatoDto.Email = "";
            string mensagemEsperada = "O campo e-mail é obrigatório.";

            // Act
            var result = contatoDto.Validate();

            // Assert           
            Assert.False(result.IsValid);
            Assert.Equal(mensagemEsperada, result.Errors[0].ErrorMessage);
        }

        [Fact(DisplayName = "Validar Contato com EMAIL Sem @@")]
        [Trait("Contato", "Validador Email")]
        public void Contato_Com_Email_Sem_Arroba_Deve_Retornar_Erro()
        {
            // Arrange
            var contatoDto = _contatoFixture.CreateValidDto();
            contatoDto.Email = "gustavo.scabuzzi";
            var contatoDto2 = _contatoFixture.CreateValidDto();
            contatoDto2.Email = "teste@teste";

            string mensagemEsperada = "E-mail inválido.";

            // Act
            var result = contatoDto.Validate();
            var result2 = contatoDto.Validate();

            // Assert           
            Assert.False(result.IsValid);
            Assert.Equal(mensagemEsperada, result.Errors[0].ErrorMessage);            
            Assert.False(result2.IsValid);
            Assert.Equal(mensagemEsperada, result2.Errors[0].ErrorMessage);
        }

        [Fact(DisplayName = "Validar contato com DDD null")]
        [Trait("Contato", "Validador Contato")]
        public void Contato_Com_DDD_ERRO_Deve_Retornar_Erro()
        {
            // Arrange
            var contatoDto = _contatoFixture.CreateValidDto();
            contatoDto.DddId = null;
            string mensagemEsperada = "O ddd é obrigatório.";

            // Act
            var result = contatoDto.Validate();

            // Assert           
            Assert.False(result.IsValid);
            Assert.Equal(mensagemEsperada, result.Errors[0].ErrorMessage);
        }

        [Fact(DisplayName ="Validar conversão em Entidade")]
        [Trait("Contato", "Conversão")]
        public void Contato_Deve_Retornar_Entidade()
        {
            //Arrange
            var contatoDto = _contatoFixture.CreateValidDto();

            //Act
            var result = (Contato)contatoDto;

            Assert.Equal(contatoDto.Email, result.email);
            Assert.Equal(contatoDto.Telefone, result.telefone);
            Assert.Equal(contatoDto.DddId, result.ddd_id);
            Assert.Equal(contatoDto.Nome, result.nome);
            Assert.Equal(contatoDto.Id, result.id);
        }
    }

    public class ContatoFixture : FixtureBase<ContatoDto>
    {
        public ContatoService ContatoService { get; set; }

        public ContatoFixture()
        {
            ContatoService = Mocker.Resolve<ContatoService>();
        }
        public override ContatoDto CreateInvalidDto()
        {
            return new ContatoDto()
            {
                Nome = "",
                DddId = 1,
                Email = "gustavo.scabuzzi",
                Telefone = ""
            };
        }

        public override ContatoDto CreateNewDto()
        {
            return new ContatoDto();
        }

        public override ContatoDto CreateValidDto()
        {
            return new ContatoDto()
            {
                Nome = "Gustavo",
                DddId = 1,
                Email = "gustavo.scabuzzi@gmail.com",
                Telefone = "999999999"
            };
        }


    }

}
