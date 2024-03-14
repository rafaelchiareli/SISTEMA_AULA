using SISTEMA_AULA.MODEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_AULA.MODEL.Repositories
{
    public class RepositoryTipoProduto : RepositoryBase<TipoProduto>
    {
        public RepositoryTipoProduto(DbsistemasContext context, bool saveChanges = true) : base(context, saveChanges)
        {
        }
    }
}
