using SISTEMA_AULA.MODEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_AULA.MODEL.Repositories
{
    public class RepositotyTipoPagamento : RepositoryBase<TipoPagamento>
    {
        public RepositotyTipoPagamento(DbsistemasContext context, bool saveChanges) : base(context, saveChanges)
        {

        }
    }
}
