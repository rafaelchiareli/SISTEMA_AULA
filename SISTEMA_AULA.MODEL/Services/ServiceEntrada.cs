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

    public class ServiceEntrada
    {
        private DbsistemasContext _context;
        public RepositoryProduto oRepositoryProduto { get; set; }
        public RepositoryEntrada oRepositoryEntrada { get; set; }

        public ServiceEntrada(DbsistemasContext context)
        {
            _context = context;
            oRepositoryProduto = new RepositoryProduto(context);
            oRepositoryEntrada = new RepositoryEntrada(context);
        }

        public async Task<EntradaVM> IncluirEntradaProdutoAsync(EntradaVM entradaVM)
        {
            var entrada = new Entradum()
            {
                EnNuneroNotaFiscal = entradaVM.NumeroNF,
                EntDataHora = entradaVM.DataEntarda,

            };
            var listaEntradaProdutos = new List<EntradaProduto>();
            foreach (var item in entradaVM.ListaProdutos)
            {
                var entradaProduto = new EntradaProduto()
                {
                    EnpCodigoProduto = item.CodigoProduto,
                    EnpQuantidade = item.Quantidade,
                    EnpValorCusto = item.ValorCusto,
                    EnpValorVenda = item.ValorVenda,

                };
                listaEntradaProdutos.Add(entradaProduto);
            }
            entrada.EntradaProdutos = listaEntradaProdutos;
            await oRepositoryEntrada.IncluirAsync(entrada);
            return entradaVM;

        }

        public async Task<EntradaVM> AlterarEntradaProdutoAsync(EntradaVM entradaVM)
        {
            var entrada = new Entradum()
            {
                EntCodigo = (int)entradaVM.CodigoEntrada!,
                EnNuneroNotaFiscal = entradaVM.NumeroNF,
                EntDataHora = entradaVM.DataEntarda,

            };
            var listaEntradaProdutos = new List<EntradaProduto>();
            foreach (var item in entradaVM.ListaProdutos)
            {
                var entradaProduto = new EntradaProduto()
                {
                    EnpCodigoProduto = item.CodigoProduto,
                    EnpQuantidade = item.Quantidade,
                    EnpValorCusto = item.ValorCusto,
                    EnpValorVenda = item.ValorVenda,

                };
                listaEntradaProdutos.Add(entradaProduto);
            }
            entrada.EntradaProdutos = listaEntradaProdutos;

            await oRepositoryEntrada.AlterarAsync(entrada);
            return entradaVM;

        }
    }
}
