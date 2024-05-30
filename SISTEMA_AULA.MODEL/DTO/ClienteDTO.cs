using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_AULA.MODEL.DTO
{
    public  class ClienteDTO
    {
        public int cliCodigo { get; set; }
        public string cliCpfcnpj { get; set; }
        public DateTime cliDataNascimento { get; set; }
        public string cliEmail { get; set; }
        public string cliNome { get; set; }
        public string cliNomeMae { get; set; }
        public string cliSexo { get; set; }
        public string CliTelefone { get; set; } = null!;

    }
}
