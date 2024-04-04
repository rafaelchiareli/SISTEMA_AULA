using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_AULA.MODEL.ViewModel
{
    public class VendaVM
    {
        public int CodigoVenda { get; set; }
        public DateTime DataVenda { get; set; }
        public int CodigoCliente { get; set; }
        public int CodigoTipoPagamento { get; set; }
        public int QtdParcelas { get; set; }
        public string Usuario { get; set; }
        public string TipoPagamento { get; set; }
        public ItemVendaVM ItensVenda { get; set; }


    }
}
