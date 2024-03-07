using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


namespace SISTEMA_AULA.MODEL.Models
{
    [ModelMetadataType(typeof(MD_Unidade))]
    public partial class Unidade
    {
         class MD_Unidade
        {
            [Display(Name ="Código")]
            public int UnCodigo { get; set; }
            [Display(Name = "Descricao")]
            public string UnDescricao { get; set; } = null!;
            [Display(Name = "Desativado")]
            public bool UnDesativado { get; set; }
        }

    }
}
