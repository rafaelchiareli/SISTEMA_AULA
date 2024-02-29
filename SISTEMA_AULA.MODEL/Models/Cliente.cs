using System;
using System.Collections.Generic;

namespace SISTEMA_AULA.MODEL.Models;

public partial class Cliente
{
    public int CliCodigo { get; set; }

    public string CliNome { get; set; } = null!;

    public string CliSexo { get; set; } = null!;

    public string CliCpfcnpj { get; set; } = null!;

    public string CliTelefone { get; set; } = null!;

    public string? CliEmail { get; set; }

    public DateTime? CliDataNascimento { get; set; }

    public string CliNomeMae { get; set; } = null!;

    public DateTime? CliDataCadastro { get; set; }

    public virtual ICollection<Endereco> Enderecos { get; set; } = new List<Endereco>();

    public virtual ICollection<Vendum> Venda { get; set; } = new List<Vendum>();
}
