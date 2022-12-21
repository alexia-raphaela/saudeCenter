using SaudeCenter.Dto;

namespace SaudeCenter.Repository
{
    public interface IAgendamentoRepository
    {
        int Alterar(AgendamentoDto agendamento);
        AgendamentoDto Consultar(int idAgendamento);
        int Excluir(int idAgendamento);
        int Inserir(AgendamentoDto agendamento);
        IList<AgendamentoDto>? ListarTodos();
    }
}