using SISTEMA_AULA.MODEL.DTO;
using SISTEMA_AULA.MODEL.Interfaces;
using SISTEMA_AULA.MODEL.Models;
using SISTEMA_AULA.MODEL.Repositories;
using SISTEMA_AULA.MODEL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_AULA.MODEL.Services
{
    public class ServiceCliente
    {
        public RepositoryCliente oRepositoryCliente { get; set; }
        public RepositoryEndereco oRepositoryEndereco { get; set; }

        private DbsistemasContext _context;
        public ServiceCliente(DbsistemasContext context)
        {
            _context = context;
            oRepositoryCliente = new RepositoryCliente(context);
            oRepositoryEndereco = new RepositoryEndereco(context);
        }

        public async Task IncluirClienteDTO(ClienteDTO clienteDTO)
        {
            var cliente = new Cliente()
            {
                CliCodigo = clienteDTO.cliCodigo,
                CliCpfcnpj = clienteDTO.cliCpfcnpj,
                CliDataNascimento = clienteDTO.cliDataNascimento,
                CliEmail = clienteDTO.cliEmail,
                CliNome = clienteDTO.cliNome,
                CliSexo = clienteDTO.cliSexo,
                CliNomeMae = clienteDTO.cliNomeMae,
                CliTelefone = clienteDTO.CliTelefone

            };
           await  oRepositoryCliente.IncluirAsync(cliente);
        }

        public async Task AlterarClienteDTO(ClienteDTO clienteDTO)
        {
            var cliente = new Cliente()
            {
                CliCodigo = clienteDTO.cliCodigo,
                CliCpfcnpj = clienteDTO.cliCpfcnpj,
                CliDataNascimento = clienteDTO.cliDataNascimento,
                CliEmail = clienteDTO.cliEmail,
                CliNome = clienteDTO.cliNome,
                CliSexo = clienteDTO.cliSexo,
                CliNomeMae = clienteDTO.cliNomeMae,
                CliTelefone = clienteDTO.CliTelefone

            };
            await oRepositoryCliente.AlterarAsync(cliente);
        }
        public async Task<ClienteVM> IncluirClienteAsync(ClienteVM clienteVM)
        {
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
                EndCep = clienteVM.CEP,
                EndCidade = clienteVM.Cidade,
                EndComplemento = clienteVM.Complemento,
                EndEstado = clienteVM.Estado,
                EndLogradouro = clienteVM.Logradouro,
                EndNumero = clienteVM.Numero
            };

            cliente.EnderecoCliente = endereco;

            await oRepositoryCliente.IncluirAsync(cliente);
          //  endereco.EndCodigoCliente = cliente.CliCodigo;
         //   await oRepositoryEndereco.IncluirAsync(endereco);

            return clienteVM;
        }


    }
}
