using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.ObjectModelRemoting;
using Microsoft.EntityFrameworkCore;
using SISTEMA_AULA.MODEL.Models;

namespace SISTEMA_AULA.Controllers
{
    public class TipoPagamentoController : DefaultController
    {
        [AllowAnonymous]
        public async Task<IActionResult> Index() {
            var db = new DbsistemasContext();
            var listaTipoPagamento = await db.TipoPagamentos.ToListAsync();
            return View(listaTipoPagamento);
        }

       
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TipoPagamento tipoPagamento)
        {
            if (ModelState.IsValid)
            {
                var db = new DbsistemasContext();
                db.Entry(tipoPagamento).State = EntityState.Added;
                await db.SaveChangesAsync();
                ViewData["Mensagem"] = "Dados salvos com sucesso";
                return View(tipoPagamento);
            }
            else
            {
                ViewData["MensagemErro"] = "Ocorreu um erro";
                return View(tipoPagamento);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var db = new DbsistemasContext();
            var tipoPagamento = await db.TipoPagamentos.FindAsync(id);
            return View(tipoPagamento);
           
        }
        [Authorize]
        public async Task<IActionResult> Edit(TipoPagamento tipoPagamento)
        {
            if (ModelState.IsValid)
            {
                var db = new DbsistemasContext();
                db.Entry(tipoPagamento).State = EntityState.Modified;
                await db.SaveChangesAsync();
                ViewData["Mensagem"] = "Dados alterados com sucesso";
                return View(tipoPagamento);
            }
            else
            {
                ViewData["MensagemErro"] = "Ocorreu um erro";
                return View(tipoPagamento);
            }
        }



    }
}
