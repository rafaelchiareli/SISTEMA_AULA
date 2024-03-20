using Microsoft.AspNetCore.Mvc;
using SISTEMA_AULA.MODEL.Models;
using SISTEMA_AULA.MODEL.Services;
using SISTEMA_AULA.MODEL.ViewModel;

namespace SISTEMA_AULA.Controllers
{
    public class ClienteController : Controller
    {
        private DbsistemasContext _context;
        private ServiceCliente _serviceCliente;

      
        public ClienteController(DbsistemasContext context)
        {
            _context = context;
            _serviceCliente = new ServiceCliente(context);
        }

        public async Task<IActionResult> Index()
        {
            
            return View(await ClienteVM.GetClienteVMs());
        }

        public IActionResult Create()
        {
            return View();  
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClienteVM clienteVM)
        {
            if(ModelState.IsValid)
            {

                ClienteVM clienteVMNovo = new ClienteVM();
                clienteVMNovo = await _serviceCliente.IncluirClienteAsync(clienteVM);
                return View(clienteVMNovo);
            }
            return View(clienteVM);





        }
    }
}
