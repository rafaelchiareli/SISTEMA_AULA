using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SISTEMA_AULA.MODEL.Models;
using SISTEMA_AULA.MODEL.Services;

namespace SISTEMA_AULA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private DbsistemasContext _context;
        private ServiceCliente _Service;

        public ClienteController(DbsistemasContext context)
        {
            _context = context;
            _Service = new ServiceCliente(_context);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _Service.oRepositoryCliente.SelecionarTodosAsync());
        }
        [HttpGet("GetClientesById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _Service.oRepositoryCliente.SelecionarChaveAsync(id));
        }
    }
}
