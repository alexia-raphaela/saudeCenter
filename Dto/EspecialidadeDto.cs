namespace SaudeCenter.Dto
{
    public class EspecialidadeDto
    {
        public int IdEspecialidade { get; set; }
        public string Nome { get; set; } = null!;

        public string? Descrição { get; set; }

        public bool Ativo { get; set; }
    }
}
