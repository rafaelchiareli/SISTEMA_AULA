using SISTEMA_AULA.MODEL.Models;
using SISTEMA_AULA.MODEL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_AULA.MODEL.Services
{
    public  class ServiceProduto
    {
        public RepositoryProduto oRepositoryProduto { get; set; }
        public RepositoryTipoProduto oRepositoryTipoProduto { get; set; }

        private DbsistemasContext _context;

        public ServiceProduto(DbsistemasContext context)
        {
            _context = context;
            oRepositoryProduto = new RepositoryProduto(context);    
            oRepositoryTipoProduto = new RepositoryTipoProduto(context);    
        }
    }
}
