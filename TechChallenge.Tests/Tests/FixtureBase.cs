using AutoMoq;
using TechChallenge.Business.Dtos;

namespace TechChallenge.Tests.Tests
{
    public abstract class FixtureBase<TDto> where TDto : DtoBase
    {
        public AutoMoqer Mocker { get; private set; }

        public FixtureBase()
        {
            Mocker = new AutoMoqer();
        }

        public abstract TDto CreateValidDto();
        public abstract TDto CreateInvalidDto();
        public abstract TDto CreateNewDto();
    }

}
