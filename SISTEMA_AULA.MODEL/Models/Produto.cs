using System;
using System.Collections.Generic;

namespace SISTEMA_AULA.MODEL.Models;

public partial class Produto
{
    public int ProCodigo { get; set; }

    public string ProCodigoBarras { get; set; } = null!;

    public string ProDescricao { get; set; } = null!;

    public DateTime ProDataCadastro { get; set; }

    public bool ProDesativado { get; set; }

    public int? ProCodigoTipoProduto { get; set; }

    public int? ProCodigoUnidade { get; set; }

    public virtual EntradaProduto? EntradaProduto { get; set; }

    public virtual TipoProduto? ProCodigoTipoProdutoNavigation { get; set; }

    public virtual Unidade? ProCodigoUnidadeNavigation { get; set; }

    public virtual ICollection<Vendum> ItvCodigoVenda { get; set; } = new List<Vendum>();
}
