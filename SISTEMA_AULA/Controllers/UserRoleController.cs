using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SISTEMA_AULA.Models;

namespace SISTEMA_AULA.Controllers
{
    public class UserRoleController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<IdentityUser> _userManager;

        public UserRoleController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public void CarregaViewBag()
        {
            ViewBag.listaRoles = _roleManager.Roles.ToList();
            ViewBag.listaUsuarios = _userManager.Users.ToList();
        }
        public IActionResult Create()
        {
            CarregaViewBag();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserRole userRole)
        {
            var user = await _userManager.FindByIdAsync(userRole.UserId);
            if (user != null)
            {
                var result = await _userManager.AddToRoleAsync(user, userRole.RoleName);
                if (result.Succeeded)
                {
                    ViewData["Mensagem"] = "Usuário adicionado a role com sucesso";
                }
                else
                {
                    ViewData["MensagemErro"] = result.Errors;

                }
            }
            CarregaViewBag();
            return View();
        }
    }
}
