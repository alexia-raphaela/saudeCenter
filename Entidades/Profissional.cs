using System;
using System.Collections.Generic;

namespace SaudeCenter.Entidades;

public partial class Profissional
{
    public int IdProfissional { get; set; }

    public string Nome { get; set; } = null!;

    public string? Telefone { get; set; }

    public string? Endereco { get; set; }

    public bool Ativo { get; set; }

    public virtual ICollection<AgendamentoConfiguracao> AgendamentoConfiguracaos { get; } = new List<AgendamentoConfiguracao>();

    public virtual ICollection<Agendamento> Agendamentos { get; } = new List<Agendamento>();

    public virtual ICollection<DadosBancarios> DadosBancarios { get; } = new List<DadosBancarios>();
}
