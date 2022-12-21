using SaudeCenter.Dto;

namespace SaudeCenter.Repository
{
    public interface IDadosBancariosRepository
    {
        int Alterar(DadosBancariosDto dadosBancarios);
        DadosBancariosDto Consultar(int idDadosBancarios);
        int Excluir(int idDadosBancarios);
        int Inserir(DadosBancariosDto dadosBancarios);
        IList<DadosBancariosDto>? ListarTodos();
    }
}