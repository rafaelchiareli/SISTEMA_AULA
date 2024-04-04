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

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> MaintainAsync()
        {
            ViewBag.listaTipoPagamento = new SelectList(await _ServiceVenda.oRepositoryTipoPagamento.SelecionarTodosAsync(), nameof(TipoPagamento.TpgCodigo), nameof(TipoPagamento.TpgDescricao));
            ViewBag.listaProdutos = new SelectList(await _ServiceVenda.oRepositoryProduto.SelecionarTodosAsync(), nameof(Produto.ProCodigo), nameof(Produto.ProDescricao));
            ViewBag.listaClientes = new SelectList(await _ServiceVenda.oRepositoryCliente.SelecionarTodosAsync(), nameof(Cliente.CliCodigo), nameof(Cliente.CliNome));
            return View();
        }
    }


}
