using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_AULA.MODEL.Models
{
    [ModelMetadataType(typeof(MD_TipoPagamento))]
    public partial class TipoPagamento
    {

        public class MD_TipoPagamento
        {
            [Display(Name ="Código")]
            public int TpgCodigo { get; set; }
            [Display(Name = "Descrição")]
            public string TpgDescricao { get; set; } = null!;
            [Display(Name = "Desativado")]
            public bool TpgDesativado { get; set; }
        }
    }
}
