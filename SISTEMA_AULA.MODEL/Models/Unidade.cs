using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SISTEMA_AULA.MODEL.Models;

public partial class Unidade
{
    public int UnCodigo { get; set; }
 
    public string UnDescricao { get; set; } = null!;

    public bool UnDesativado { get; set; }

    public virtual ICollection<Produto> Produtos { get; set; } = new List<Produto>();
}
