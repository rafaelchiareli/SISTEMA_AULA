using System;
using System.Collections.Generic;

namespace SISTEMA_AULA.MODEL.Models;

public partial class Vendum
{
    public int VenCodigo { get; set; }

    public DateTime VenData { get; set; }

    public int VenCodigoCliente { get; set; }

    public string VenUsuario { get; set; } = null!;

    public int VenCodigoTipoPagamento { get; set; }

    public int? VenQtdParcelas { get; set; }

    public virtual ICollection<Parcela> Parcelas { get; set; } = new List<Parcela>();

    public virtual Cliente VenCodigoClienteNavigation { get; set; } = null!;

    public virtual TipoPagamento VenCodigoTipoPagamentoNavigation { get; set; } = null!;

    public virtual ICollection<Produto> ItvCodigoProdutos { get; set; } = new List<Produto>();
}
