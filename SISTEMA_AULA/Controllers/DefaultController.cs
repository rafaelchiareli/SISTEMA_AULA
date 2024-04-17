using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SISTEMA_AULA.Controllers
{
    [Authorize(Roles = "Admin,Gerente")]
    public class DefaultController : Controller
    {
        public IActionResult Ola()
        {
            return View();
        }
    }
}
