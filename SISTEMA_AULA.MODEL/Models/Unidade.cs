using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SISTEMA_AULA.MODEL.Models;

public partial class Unidade
{
    [Display(Name = "Código")]
    public int UnCodigo { get; set; }
    [Display(Name = "Descrição")]
    public string UnDescricao { get; set; } = null!;
    [Display(Name = "Desativado")]
    public bool UnDesativado { get; set; }

    public virtual ICollection<Produto> Produtos { get; set; } = new List<Produto>();
}
