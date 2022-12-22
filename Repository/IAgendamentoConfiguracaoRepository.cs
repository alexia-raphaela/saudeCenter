using SaudeCenter.Dto;

namespace SaudeCenter.Repository
{
    public interface IAgendamentoConfiguracaoRepository
    {
        int Alterar(AgendamentoConfiguracaoDto configuracao);
        AgendamentoConfiguracaoDto Consultar(int idAgendamentoConfiguracao);
        int Excluir(int idConfiguracao);
        int Inserir(AgendamentoConfiguracaoDto configuracao);
        IList<AgendamentoConfiguracaoDto>? ListarTodos();
    }
}