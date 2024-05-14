using AutoMoq;
using TechChallenge.Business.Dtos;
using TechChallenge.Business.Interfaces;
using TechChallenge.Business.Services;

namespace TechChallenge.Tests.Tests
{
    [Trait("Category", "DddService")]
    [Collection("Ddd Collection")]
    public class DddTests
    {
        private readonly DddFixture _dddFixture;

        public DddTests(DddFixture dddFixture)
        {
            _dddFixture = dddFixture;
        }

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
    }

    public class DddFixture : FixtureBase<DddDto>
    {
        public DddService DddService { get; set; }

        public DddFixture()
        {
            DddService = Mocker.Resolve<DddService>();
        }
        public override DddDto CreateInvalidDto() => new DddDto { Codigo = "", RegiaoId = null };
        public override DddDto CreateNullDto() => new DddDto();
        public override DddDto CreateValidDto() => new DddDto { Codigo = "41", RegiaoId = 1, Id = 1 };
    }
 }

