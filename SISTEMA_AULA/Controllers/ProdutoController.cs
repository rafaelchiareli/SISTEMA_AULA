using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SISTEMA_AULA.MODEL.Models;
using SISTEMA_AULA.MODEL.Services;

namespace SISTEMA_AULA.Controllers
{
    public class ProdutoController : Controller
    {

        private DbsistemasContext _context;
        private ServiceProduto _ServiceProduto;

        public ProdutoController(DbsistemasContext context)
        {
            _context = context;
            _ServiceProduto = new ServiceProduto(context);
        }

        public async Task<IActionResult> Index()
        {

            return View(await _ServiceProduto.oRepositoryProduto.SelecionarTodosAsync());
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.listaTipoProduto = await  _ServiceProduto.oRepositoryTipoProduto.SelecionarTodosAsync();
            ViewBag.TiposProduto = new SelectList(await _ServiceProduto.oRepositoryTipoProduto.SelecionarTodosAsync(), nameof(TipoProduto.TipCodigo), nameof(TipoProduto.TipDescricao));
            return View();
        }


    }
}
