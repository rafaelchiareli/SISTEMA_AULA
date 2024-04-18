using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SISTEMA_AULA.Models;
using System.Formats.Tar;

namespace SISTEMA_AULA.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
                _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var listaRoles = new List<IdentityRole>();
             listaRoles = _roleManager.Roles.ToList();
            return View(listaRoles);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Role role)
        {

            var identityRole = new IdentityRole(role.RoleName);
            var result = await _roleManager.CreateAsync(identityRole);
            if (result.Succeeded)
            {
                ViewData["Mensagem"] = "Role criada com sucesso";
            }
            else
            {
                ViewData["MensagemErro"] = result.Errors;
            }
            return View();
        }
    }
}
