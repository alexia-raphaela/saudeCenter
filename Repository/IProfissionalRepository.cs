using SaudeCenter.Dto;

namespace SaudeCenter.Repository
{
    public interface IProfissionalRepository
    {
        int Alterar(ProfissionalDto profissional);
        ProfissionalDto Consultar(int idProfissional);
        int Excluir(int idProfissional);
        int Inserir(ProfissionalDto profissional);
        IList<ProfissionalDto>? ListarTodos();
    }
}