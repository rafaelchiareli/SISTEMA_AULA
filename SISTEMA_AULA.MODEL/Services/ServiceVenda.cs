using SISTEMA_AULA.MODEL.Models;
using SISTEMA_AULA.MODEL.Repositories;
using SISTEMA_AULA.MODEL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_AULA.MODEL.Services
{

    public class ServiceVenda
    {
        private DbsistemasContext _context;
        public RepositoryVenda oRepositoryVenda { get; set; }
        public RepositoryProduto oRepositoryProduto { get; set; }
        public RepositoryCliente oRepositoryCliente { get; set; }
        public RepositoryTipoPagamento oRepositoryTipoPagamento { get; set; }
        public RepositoryVwEstoque oRepositoryVwEstoque { get; set; }


        public ServiceVenda(DbsistemasContext context)
        {
            _context = context;
            oRepositoryCliente = new RepositoryCliente(context);
            oRepositoryProduto = new RepositoryProduto(context);
            oRepositoryVenda = new RepositoryVenda(context);
            oRepositoryTipoPagamento = new RepositoryTipoPagamento(context);
            oRepositoryVwEstoque = new RepositoryVwEstoque(context);
        }

        public async Task<List<VendaVM>> ListarVendas()
        {
            return await VendaVM.ListarVendas();
        }



        public async Task CadastrarVenda(VendaVM vendaVM)
        {
            var venda = new Vendum()
            {
                VenCodigoCliente = vendaVM.CodigoCliente,
                VenCodigoTipoPagamento = vendaVM.CodigoTipoPagamento,
                VenData = vendaVM.DataVenda,
                VenQtdParcelas = vendaVM.QtdParcelas
            };

            var itensVenda = new List<ItensVendum>();
            foreach (var item in vendaVM.ItensVenda)
            {
                itensVenda.Add(new ItensVendum()
                {
                    ItvQuantidade = item.Quantidade,
                    ItvValorItem = item.ValorItem,

                });
            }
            venda.ItensVenda = itensVenda;
          await oRepositoryVenda.IncluirAsync(venda);
        }


    }
}
