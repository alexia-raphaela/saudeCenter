using SaudeCenter.Dto;
using SaudeCenter.Entidades;

namespace SaudeCenter.Repository
{
    public interface IEspecialidadeRepository
    {
        int Alterar(EspecialidadeDto especialidade);
        EspecialidadeDto Consultar(int idEspecialidade);
        int Excluir(int idEspecialidade);
        int Inserir(Especialidade especialidade);
        IList<EspecialidadeDto>? ListarTodos();
    }
}