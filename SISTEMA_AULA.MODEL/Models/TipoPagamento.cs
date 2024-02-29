using System;
using System.Collections.Generic;

namespace SISTEMA_AULA.MODEL.Models;

public partial class TipoPagamento
{
    public int TpgCodigo { get; set; }

    public string TpgDescricao { get; set; } = null!;

    public bool TpgDesativado { get; set; }

    public virtual ICollection<Vendum> Venda { get; set; } = new List<Vendum>();
}
