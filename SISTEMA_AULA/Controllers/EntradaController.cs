using Microsoft.AspNetCore.Mvc;
using SISTEMA_AULA.MODEL.Models;
using SISTEMA_AULA.MODEL.Services;
using SISTEMA_AULA.MODEL.ViewModel;

namespace SISTEMA_AULA.Controllers
{
    public class EntradaController : Controller
    {
        private ServiceEntrada _serviceEntrada;
        private DbsistemasContext _context;

        public EntradaController(DbsistemasContext context)
        {
            _context = context;
            _serviceEntrada = new ServiceEntrada(_context);
        }

        public async Task<IActionResult> Index()
        {
            var listaEntradaVM = await EntradaVM.ListarEntradasAsync();
            return View(listaEntradaVM);
        }

        public async Task<IActionResult> Create(int id = 0)
        {
            ViewBag.listaProdutos = await _serviceEntrada.oRepositoryProduto.SelecionarTodosAsync();
            if (id > 0)
            {
                var entradaVM = await EntradaVM.SelecionaEntradaVMAsync(id);
                return View(entradaVM);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EntradaVM entradaVM)
        {
            if (entradaVM.CodigoEntrada > 0)
            {
                await _serviceEntrada.AlterarEntradaProdutoAsync(entradaVM);
                return RedirectToAction("Index");
            }
            else
            {
                await _serviceEntrada.IncluirEntradaProdutoAsync(entradaVM);
                return RedirectToAction("Index");
            }
           
        }



    }
}
