using SaudeCenter.Dto;
using SaudeCenter.Entidades;

namespace SaudeCenter.Repository
{
    public interface IAgendamentoConfiguracaoRepository
    {
        int Alterar(AgendamentoConfiguracaoDto configuracao);
        AgendamentoConfiguracao Consultar(int idAgendamentoConfiguracao);
        int Excluir(int idConfiguracao);
        int Inserir(AgendamentoConfiguracao configuracao);
        IList<AgendamentoConfiguracaoDto>? ListarTodos();
    }
}