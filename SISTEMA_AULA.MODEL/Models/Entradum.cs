﻿using System;
using System.Collections.Generic;

namespace SISTEMA_AULA.MODEL.Models;

public partial class Entradum
{
    public int EntCodigo { get; set; }

    public DateTime? EntDataHora { get; set; }

    public string? EntUsuario { get; set; }

    public string? EnNuneroNotaFiscal { get; set; }

    public virtual ICollection<EntradaProduto> EntradaProdutos { get; set; } = new List<EntradaProduto>();
}