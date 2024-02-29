using System;
using System.Collections.Generic;

namespace SISTEMA_AULA.MODEL.Models;

public partial class EntradaProduto
{
    public int EnpCodigoProduto { get; set; }

    public int EnpCodigoEntrada { get; set; }

    public decimal EnpValorCusto { get; set; }

    public decimal EnpValorVenda { get; set; }

    public int EnpQuantidade { get; set; }

    public virtual Entradum EnpCodigoEntradaNavigation { get; set; } = null!;

    public virtual Produto EnpCodigoProdutoNavigation { get; set; } = null!;
}
