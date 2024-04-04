using SISTEMA_AULA.MODEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_AULA.MODEL.Repositories
{
    public class RepositoryTipoPagamento : RepositoryBase<TipoPagamento>
    {
        public RepositoryTipoPagamento(DbsistemasContext context, bool saveChanges = true) : base(context, saveChanges)
        {

        }
    }
}
