using System;
using System.Collections.Generic;

namespace SISTEMA_AULA.MODEL.Models;

public partial class TipoProduto
{
    public int TipCodigo { get; set; }

    public string TipDescricao { get; set; } = null!;

    public bool TipDestivado { get; set; }

    public virtual ICollection<Produto> Produtos { get; set; } = new List<Produto>();
}
