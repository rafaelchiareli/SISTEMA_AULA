using System;
using System.Collections.Generic;

namespace SISTEMA_AULA.MODEL.Models;

public partial class Endereco
{
    public int EndCodigo { get; set; }

    public int EndCodigoCliente { get; set; }

    public string EndCep { get; set; } = null!;

    public string EndLogradouro { get; set; } = null!;

    public string EndBairro { get; set; } = null!;

    public string EndCidade { get; set; } = null!;

    public string? EndComplemento { get; set; }

    public string EndNumero { get; set; } = null!;

    public string EndEstado { get; set; } = null!;

    public Cliente ClienteEndereco { get; set; }

}