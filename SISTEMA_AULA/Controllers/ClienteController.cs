using Microsoft.AspNetCore.Mvc;
using SISTEMA_AULA.MODEL.Models;
using SISTEMA_AULA.ViewModel;

namespace SISTEMA_AULA.Controllers
{
    public class ClienteController : Controller
    {
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
            var db = new DbsistemasContext();
            var cliente = new Cliente()
            {
                CliCpfcnpj = clienteVM.CNPJ != null ? clienteVM.CNPJ : clienteVM.CPF,
                CliDataCadastro = clienteVM.DataCadastro,
                CliDataNascimento = clienteVM.DataNascimento,
                CliEmail = clienteVM.Email,
                CliNome = clienteVM.NomeCliente,
                CliNomeMae = clienteVM.NomeMae,
                CliSexo = clienteVM.Sexo,
                CliTelefone = clienteVM.Telefone        
            };

            var endereco = new Endereco()
            {
                EndBairro = clienteVM.Bairro,
                EndCep   = clienteVM.CEP,
                EndCidade = clienteVM.Cidade,   
                EndComplemento  = clienteVM.Complemento,
                EndEstado = clienteVM.Estado,
                EndLogradouro = clienteVM.Logradouro,
                EndNumero = clienteVM.Numero
            };

           
            db.Entry(cliente).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await db.SaveChangesAsync();
            endereco.EndCodigoCliente = cliente.CliCodigo;
            db.Entry(endereco).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await db.SaveChangesAsync();
            return View(clienteVM);


        }
    }
}
