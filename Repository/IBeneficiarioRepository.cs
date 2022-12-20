using SaudeCenter.Dto;
using SaudeCenter.Entidades;

namespace SaudeCenter.Repository
{
    public interface IBeneficiarioRepository
    {
        int Alterar(BeneficiarioDto beneficiario);
        BeneficiarioDto Consultar(int idBeneficiario);
        int Excluir(int idBeneficiario);
        int Inserir(Beneficiario beneficiario);
        IList<BeneficiarioDto>? ListarTodos();
    }
}