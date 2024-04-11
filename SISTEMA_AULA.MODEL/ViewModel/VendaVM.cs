using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SISTEMA_AULA.MODEL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public string Cliente { get; set; }
        public int CodigoTipoPagamento { get; set; }
        public int? QtdParcelas { get; set; }
        public string Usuario { get; set; }
        public string TipoPagamento { get; set; }
        public List<ItemVendaVM> ItensVenda { get; set; }

        public VendaVM()
        {
         
        }

        public async static Task<List<VendaVM>> ListarVendas()
        {
            var db = new DbsistemasContext();
            var listaVendas = await db.Venda.ToListAsync();
            var listaRetorno = new List<VendaVM>();
            foreach (var venda in listaVendas)
            {
                VendaVM vendaVM = new VendaVM();
                vendaVM.DataVenda = venda.VenData;
                vendaVM.CodigoVenda = venda.VenCodigo;
                vendaVM.CodigoTipoPagamento = venda.VenCodigoTipoPagamento;
                vendaVM.TipoPagamento = db.TipoPagamentos.FirstOrDefault(x => x.TpgCodigo == venda.VenCodigoTipoPagamento).TpgDescricao;
                vendaVM.CodigoCliente = venda.VenCodigoCliente;
                vendaVM.Cliente = db.Clientes.FirstOrDefault(x => x.CliCodigo == venda.VenCodigoCliente).CliNome;
                vendaVM.QtdParcelas = venda.VenQtdParcelas;
                listaRetorno.Add(vendaVM);
            }
            return listaRetorno;
        }

    }

}
