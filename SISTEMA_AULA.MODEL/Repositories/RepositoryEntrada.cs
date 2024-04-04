using SISTEMA_AULA.MODEL.Interfaces;
using SISTEMA_AULA.MODEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_AULA.MODEL.Repositories
{
    public class RepositoryEntrada : RepositoryBase<Entradum>
    {
        public RepositoryEntrada(DbsistemasContext context, bool saveChanges = true) : base(context, saveChanges)
        {

        }


        public async Task AlterarEntradaAsync(Entradum entradum)
        {
            
            _context.Entry(entradum).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            var listaEntradaProduto = _context.EntradaProdutos.Where(x => x.EnpCodigoEntrada == entradum.EntCodigo).ToList();
            _context.RemoveRange(listaEntradaProduto);
            await _context.SaveChangesAsync();
            await _context.AddRangeAsync(entradum.EntradaProdutos);
            await _context.SaveChangesAsync();

        }
    }
}
