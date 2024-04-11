using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SISTEMA_AULA.MODEL.Models;
using SISTEMA_AULA.MODEL.Services;

namespace SISTEMA_AULA.Controllers
{
    public class VendaController : Controller
    {

        private DbsistemasContext _context;
        private ServiceVenda _ServiceVenda;

        public VendaController(DbsistemasContext context)
        {
            _context = context;
            _ServiceVenda = new ServiceVenda(context);
        }

        public async Task<IActionResult> Index()
        {
          
            return View(await _ServiceVenda.ListarVendas());
        }

        public async Task<IActionResult> MaintainAsync()
        {
            ViewBag.listaTipoPagamento = new SelectList(await _ServiceVenda.oRepositoryTipoPagamento.SelecionarTodosAsync(), nameof(TipoPagamento.TpgCodigo), nameof(TipoPagamento.TpgDescricao));
            ViewBag.listaProdutos = await _ServiceVenda.oRepositoryVwEstoque.SelecionarTodosAsync();
            ViewBag.listaClientes = new SelectList(await _ServiceVenda.oRepositoryCliente.SelecionarTodosAsync(), nameof(Cliente.CliCodigo), nameof(Cliente.CliNome));
            return View();
        }

        
        public async Task<IActionResult> SelecionarProduto(int codProduto)
        {
            var produto = await _ServiceVenda.oRepositoryVwEstoque.SelecionarChaveAsync(codProduto);
            return Ok(produto);
        }
    }


}
