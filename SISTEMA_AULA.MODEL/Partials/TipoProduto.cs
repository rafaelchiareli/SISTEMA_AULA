using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_AULA.MODEL.Models
{
    [ModelMetadataType(typeof(MD_TipoProduto))]
    public partial class TipoProduto
    {
        public class MD_TipoProduto
        {
            [Display(Name = "Código")]
            public int TipCodigo { get; set; }
            [Display(Name = "Descrição")]
            public string TipDescricao { get; set; } = null!;
            [Display(Name = "Desativado")]
            public bool TipDestivado { get; set; }
        }
    }
}
