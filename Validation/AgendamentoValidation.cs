using SaudeCenter.Dto;
using SaudeCenter.Entidades;

namespace SaudeCenter.Validation
{
    public class AgendamentoValidation
    {
        public string validacao(AgendamentoDto agendamento) 
        {
            if (agendamento.IdHospital == 0 || agendamento.IdHospital == null)
                return "Hospital deve ser Preenchido";

            if (agendamento.IdEspecialidade == 0 || agendamento.IdEspecialidade == null)
                return "Especialidade deve ser Preenchido";

            return null;
        }
    }
}
