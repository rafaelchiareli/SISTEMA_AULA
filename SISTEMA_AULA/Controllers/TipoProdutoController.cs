using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SISTEMA_AULA.MODEL.Models;

namespace SISTEMA_AULA.Controllers
{
    public class TipoProdutoController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var db = new DbsistemasContext();

            return View(await db.TipoProdutos.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TipoProduto tipoProduto)
        {
            var db = new DbsistemasContext();
            if (ModelState.IsValid)
            {
                db.Entry(tipoProduto).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                await db.SaveChangesAsync();
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
            var db = new DbsistemasContext();
            var tipoProduto = await db.TipoProdutos.FindAsync(id);
            return View(tipoProduto);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(TipoProduto tipoProduto)
        {
            var db = new DbsistemasContext();
            if (ModelState.IsValid)
            {
                db.Entry(tipoProduto).State = EntityState.Modified;
                await db.SaveChangesAsync();
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
            var db = new DbsistemasContext();
            var tipoProduto = await db.TipoProdutos.FirstOrDefaultAsync(x => x.TipCodigo == id);
            return View(tipoProduto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var db = new DbsistemasContext();
            var unidade = await db.TipoProdutos.FirstOrDefaultAsync(x => x.TipCodigo == id);
            return View(unidade);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TipoProduto tipoProduto)
        {
            var db = new DbsistemasContext();
            db.Entry(tipoProduto).State = EntityState.Deleted;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
