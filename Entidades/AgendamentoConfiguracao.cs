using System;
using System.Collections.Generic;

namespace SaudeCenter.Entidades;

public partial class AgendamentoConfiguracao
{
    public int IdConfiguracao { get; set; }

    public int IdHospital { get; set; }

    public int IdEspecialidade { get; set; }

    public int IdProfissional { get; set; }

    public DateTime DataHoraInicioAtendimento { get; set; }

    public DateTime DataHoraFinalAtendimento { get; set; }

    public virtual Especialidade IdEspecialidadeNavigation { get; set; } = null!;

    public virtual Hospital IdHospitalNavigation { get; set; } = null!;

    public virtual Profissional IdProfissionalNavigation { get; set; } = null!;
}
