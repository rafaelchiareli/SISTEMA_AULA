using System;
using System.Collections.Generic;

namespace SISTEMA_AULA.MODEL.Models;

public partial class Parcela
{
    public int ParCodigo { get; set; }

    public int? ParCodigoVenda { get; set; }

    public int? ParNumeroParcela { get; set; }

    public decimal? ParValorParcela { get; set; }

    public decimal? ParDataVencimento { get; set; }

    public DateTime? ParDataPagamento { get; set; }

    public virtual Vendum? ParCodigoVendaNavigation { get; set; }
}
