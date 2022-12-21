using SaudeCenter.Dto;
using SaudeCenter.Entidades;

namespace SaudeCenter.Repository
{
    public interface IHospitalRepository
    {
        int Alterar(HospitalDto hospital);
        HospitalDto Consultar(int idHospital);
        int Excluir(int idHospital);
        int Inserir(Hospital hospital);
        IList<HospitalDto>? ListarTodos();
    }
}