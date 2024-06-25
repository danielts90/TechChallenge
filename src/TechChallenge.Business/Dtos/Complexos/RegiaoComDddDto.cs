namespace TechChallenge.Business.Dtos.Complexos
{
    public  class RegiaoComDddDto
    {
        public RegiaoDto? Regiao  { get; set; }
        public List<DddDto> DddsRegiao { get; set; } = new();
    }
}
