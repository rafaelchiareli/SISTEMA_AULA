using Microsoft.EntityFrameworkCore;
using SISTEMA_AULA.MODEL.Models;
using System.ComponentModel.DataAnnotations;

namespace SISTEMA_AULA.MODEL.ViewModel
{
    public class ClienteVM
    {
        //Informações do cliente
        [Display(Name ="Código do Cliente")]
        public int? CodigoCliente { get; set; }

        [StringLength(100, MinimumLength = 5, ErrorMessage ="O Tamanho não pode ser menor que 5")]
        public string NomeCliente { get; set; }
        public string Sexo { get; set; }
        public string? CPF { get; set; }
        public string? CNPJ { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime? DataNascimento { get; set; }
        public DateTime? DataCadastro { get; set; }
        public string NomeMae { get; set; }

        //informações do Endereço

        public int? CodigoEndereco { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Complemento { get; set; }
        public string Numero { get; set; }
        public string Estado { get; set; }

        public ClienteVM()
        {
                
        }

        public async static Task<List<ClienteVM>> GetClienteVMs()
        {
            var db = new DbsistemasContext();
            var listaClientes = await db.Clientes.ToListAsync();
            return await (from cli in db.Clientes 
                    join end in db.Enderecos on cli.CliCodigo equals end.EndCodigoCliente
                    select new ClienteVM
                    {
                        Bairro = end.EndBairro,
                        CEP = end.EndCep,
                        Cidade = end.EndCidade,
                        CNPJ = cli.CliCpfcnpj.Length >11 ? cli.CliCpfcnpj : "",
                        CodigoCliente = cli.CliCodigo,
                        CodigoEndereco = end.EndCodigo,
                        Complemento  = end.EndComplemento,
                        Numero = end.EndNumero,
                        CPF = cli.CliCpfcnpj.Length == 11 ? cli.CliCpfcnpj : "",
                        DataCadastro = cli.CliDataCadastro,
                        DataNascimento  = cli.CliDataNascimento,
                        Email = cli.CliEmail,
                        Estado = end.EndEstado,
                        Logradouro = end.EndLogradouro,
                        NomeCliente  = cli.CliNome,
                        NomeMae = cli.CliNomeMae,  
                        Sexo = cli.CliSexo,
                        Telefone = cli.CliTelefone
                    }).ToListAsync();
            
            
        }


    }
}
