using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SISTEMA_AULA.MODEL.Models;
using SISTEMA_AULA.MODEL.Repositories;

namespace SISTEMA_AULA.Controllers
{
    public class TipoProdutoController : Controller
    {

        private DbsistemasContext _context;
        public RepositoryTipoProduto _RepositoryTipoProduto;

        public TipoProdutoController(DbsistemasContext context)
        {
            _context = context;
            _RepositoryTipoProduto = new RepositoryTipoProduto(context);
        }

        public async Task<IActionResult> Index()
        {


            return View(await _RepositoryTipoProduto.SelecionarTodosAsync());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TipoProduto tipoProduto)
        {

            if (ModelState.IsValid)
            {
                await _RepositoryTipoProduto.IncluirAsync(tipoProduto);
                ViewData["Mensagem"] = "Dados salvos com sucesso.";
            }
            else
            {
                ViewData["MensagemErro"] = "Ocorreu um erro ao salvar os dados.";
            }
            return View(tipoProduto);
        }

        public async Task<IActionResult> Edit(int id)
        {

            var tipoProduto = await _RepositoryTipoProduto.SelecionarChaveAsync(id);
            return View(tipoProduto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TipoProduto tipoProduto)
        {

            if (ModelState.IsValid)
            {

                await _RepositoryTipoProduto.AlterarAsync(tipoProduto);
                ViewData["Mensagem"] = "Dados alterados com sucesso.";
            }
            else
            {
                ViewData["MensagemErro"] = "Ocorreu um erro ao alterar os dados.";
            }
            return View(tipoProduto);
        }
        public async Task<IActionResult> Details(int id)
        {

            var tipoProduto = await _RepositoryTipoProduto.SelecionarChaveAsync(id);
            return View(tipoProduto);
        }

        public async Task<IActionResult> Delete(int id)
        {

            var unidade = await _RepositoryTipoProduto.SelecionarChaveAsync(id);
            return View(unidade);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TipoProduto tipoProduto)
        {
            await _RepositoryTipoProduto.ExcluirAsync(tipoProduto);
            return RedirectToAction("Index");
        }

    }
}
