using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SISTEMA_AULA.MODEL.Models;
using System.Reflection.Metadata.Ecma335;

namespace SISTEMA_AULA.Controllers
{
    public class UnidadeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var db = new DbsistemasContext();

            return View(await db.Unidades.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Unidade unidade)
        {
            var db = new DbsistemasContext();
            if (ModelState.IsValid)
            {
                db.Entry(unidade).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                await db.SaveChangesAsync();
                ViewData["Mensagem"] = "Dados salvos com sucesso.";
            }
            else
            {
                ViewData["MensagemErro"] = "Ocorreu um erro ao salvar os dados.";
            }
            return View(unidade);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var db = new DbsistemasContext();
            var unidade = await db.Unidades.FindAsync(id);
            return View(unidade);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Unidade unidade)
        {
            var db = new DbsistemasContext();
            if (ModelState.IsValid)
            {
                db.Entry(unidade).State = EntityState.Modified;
                await db.SaveChangesAsync();
                ViewData["Mensagem"] = "Dados alterados com sucesso.";
            }
            else
            {
                ViewData["MensagemErro"] = "Ocorreu um erro ao alterar os dados.";
            }
            return View(unidade);
        }
        public async Task<IActionResult> Details(int id)
        {
            var db = new DbsistemasContext();
            var unidade = await db.Unidades.FirstOrDefaultAsync(x => x.UnCodigo == id);
            return View(unidade);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var db = new DbsistemasContext();
            var unidade = await db.Unidades.FirstOrDefaultAsync(x => x.UnCodigo == id);
            return View(unidade);
        }

        [HttpPost]
        public async Task <IActionResult> Delete(Unidade unidade)
        {
            var db = new DbsistemasContext();
            db.Entry(unidade).State = EntityState.Deleted;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
