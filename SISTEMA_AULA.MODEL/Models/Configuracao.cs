using System;
using System.Collections.Generic;

namespace SISTEMA_AULA.MODEL.Models;

public partial class Configuracao
{
    public int CfgCodigo { get; set; }

    public decimal? CfgMargemLucro { get; set; }

    public decimal? CfgAcrescimoCartao { get; set; }

    public decimal? CfgDescontoAvista { get; set; }

    public string? CfgUsuarioAlteracao { get; set; }
}
