using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_AULA.MODEL.Models
{
    public  class VwEstoque
    {
        public string ProDescricao { get; set; }
        [Key]
        public int ProCodigo { get; set; }
        public int Quantidade { get; set; }

        public decimal ValorVenda { get; set; }
    }
}
