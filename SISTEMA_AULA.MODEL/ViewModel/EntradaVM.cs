using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using SISTEMA_AULA.MODEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_AULA.MODEL.ViewModel
{
    public class EntradaVM
    {
        public int? CodigoEntrada { get; set; }
        public DateTime? DataEntarda { get; set; }
        public string NumeroNF { get; set; }
        public List<EntradaProdutoVM> ListaProdutos { get; set; }

        public EntradaVM()
        {

        }


        public static async Task<EntradaVM> SelecionaEntradaVMAsync(int codEntrada)
        {
            var db = new DbsistemasContext();
            var entrada = await db.Entrada.FindAsync(codEntrada);
            var entradaVM = new EntradaVM();
            entradaVM.ListaProdutos = new List<EntradaProdutoVM>();
            entradaVM.DataEntarda = entrada!.EntDataHora;
            entradaVM.NumeroNF = entrada.EnNuneroNotaFiscal!;
            entradaVM.CodigoEntrada = entrada.EntCodigo;
            var listaEntradaProdutosVM = await db.EntradaProdutos.Where(x => x.EnpCodigoEntrada == entrada.EntCodigo).ToListAsync();
            foreach (var ep in listaEntradaProdutosVM)
            {
                var entradaProdutoVM = new EntradaProdutoVM();
                entradaProdutoVM.CodigoProduto = ep.EnpCodigoProduto;
                entradaProdutoVM.DescricaoProduto = db.Produtos.FirstOrDefault(x => x.ProCodigo == ep.EnpCodigoProduto)!.ProDescricao;
                entradaProdutoVM.CodigoEntrada = ep.EnpCodigoEntrada;
                entradaProdutoVM.Quantidade = ep.EnpQuantidade;
                entradaProdutoVM.ValorVenda = ep.EnpValorVenda;
                entradaProdutoVM.ValorCusto = ep.EnpValorCusto;
                entradaVM.ListaProdutos.Add(entradaProdutoVM);
            }
            return entradaVM;
        }
        public static async Task<List<EntradaVM>> ListarEntradasAsync()
        {
            var db = new DbsistemasContext();
            var listaRetorno = new List<EntradaVM>();    
            
            foreach (var item in db.Entrada.ToList())
            {
                var entradaVM = new EntradaVM();
                entradaVM.ListaProdutos = new List<EntradaProdutoVM>();
                entradaVM.DataEntarda = item.EntDataHora;
                entradaVM.NumeroNF = item.EnNuneroNotaFiscal;
                entradaVM.CodigoEntrada = item.EntCodigo;
                var listaEntradaProdutosVM = await db.EntradaProdutos.Where(x => x.EnpCodigoEntrada == item.EntCodigo).ToListAsync();
                foreach (var ep in listaEntradaProdutosVM)
                {
                    var entradaProdutoVM = new EntradaProdutoVM();
                    entradaProdutoVM.CodigoProduto = ep.EnpCodigoProduto;
                    entradaProdutoVM.DescricaoProduto = db.Produtos.FirstOrDefault(x => x.ProCodigo == ep.EnpCodigoProduto)!.ProDescricao;
                    entradaProdutoVM.CodigoEntrada = ep.EnpCodigoEntrada;
                    entradaProdutoVM.Quantidade = ep.EnpQuantidade;
                    entradaProdutoVM.ValorVenda = ep.EnpValorVenda;
                    entradaProdutoVM.ValorCusto = ep.EnpValorCusto;
                    entradaVM.ListaProdutos.Add(entradaProdutoVM);
                }
                listaRetorno.Add(entradaVM);
            }
            return listaRetorno;
        }
    }


}
