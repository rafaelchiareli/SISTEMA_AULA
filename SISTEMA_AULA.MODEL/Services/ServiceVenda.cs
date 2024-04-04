using SISTEMA_AULA.MODEL.Models;
using SISTEMA_AULA.MODEL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_AULA.MODEL.Services
{
   
    public class ServiceVenda
    {
        private DbsistemasContext _context;
        public RepositoryVenda oRepositoryVenda { get; set; }
        public RepositoryProduto oRepositoryProduto { get; set; }
        public RepositoryCliente oRepositoryCliente { get; set; }
        public RepositoryTipoPagamento oRepositoryTipoPagamento { get; set; }

        public ServiceVenda(DbsistemasContext context)
        {
            _context = context;
            oRepositoryCliente = new RepositoryCliente(context);
            oRepositoryProduto = new RepositoryProduto(context);
            oRepositoryVenda = new RepositoryVenda(context);
            oRepositoryTipoPagamento = new RepositoryTipoPagamento(context);
        }

      



    }
}
