using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_AULA.MODEL.ViewModel
{
    public class EntradaProdutoVM
    {
        public int CodigoProduto { get; set; }
        public int CodigoEntrada { get; set; }
        public decimal ValorCusto { get; set; }
        public decimal ValorVenda { get; set; }
        public int Quantidade { get; set; }
        public string DescricaoProduto { get; set; }
    }
}
