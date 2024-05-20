namespace TechChallenge.Business.Dtos.Complexos
{
    public class DddComContatosDto
    {
        public DddDto Ddd { get; set; }
        public List<ContatoDto> Contatos { get; set; } = new();
    }
}
