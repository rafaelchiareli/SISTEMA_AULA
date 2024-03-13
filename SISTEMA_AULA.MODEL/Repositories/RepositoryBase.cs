using Microsoft.EntityFrameworkCore;
using SISTEMA_AULA.MODEL.Interfaces;
using SISTEMA_AULA.MODEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_AULA.MODEL.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T>, IDisposable where T : class
    {
        public DbsistemasContext _context;
        public bool _saveChanges = true;

        public RepositoryBase(DbsistemasContext context, bool saveChanges)
        {
            _context = context;
            _saveChanges = saveChanges;
        }

        public T Alterar(T obj)
        {
            _context.Entry<T>(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            if (_saveChanges)
            {
                _context.SaveChanges();
            }         
            return obj;
        }

        public async Task<T> AlterarAsync(T obj)
        {
            _context.Entry<T>(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            if (_saveChanges)
            {
                await _context.SaveChangesAsync();
            }
            return obj;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Excluir(T obj)
        {
            _context.Set<T>().Remove(obj);
            if (_saveChanges)
            {
                _context.SaveChanges();
            }
        }

        public void Excluir(params object[] variavel)
        {
            var obj =  _context.Set<T>().Find(variavel);
             Excluir(obj!);
        }

        public async Task ExcluirAsync(T obj)
        {
            _context.Set<T>().Remove(obj);
            if (_saveChanges)
            {
                await _context.SaveChangesAsync();
            }
        }

        public async Task ExcluirAsync(params object[] variavel)
        {
            var obj = await _context.Set<T>().FindAsync(variavel);
            await ExcluirAsync(obj!);

        }

        public T Incluir(T obj)
        {
            _context.Set<T>().Add(obj);
            if ( _saveChanges)
            {
                _context.SaveChanges();
            }
            return obj;
        }

        public async Task<T> IncluirAsync(T obj)
        {
            await _context.Set<T>().AddAsync(obj);
            if (_saveChanges)
            {
                await _context.SaveChangesAsync();
            }
            return obj;
        }

        public T SelecionarChave(params object[] variavel)
        {
            return _context.Set<T>().Find(variavel)!;
           
        }

        public async Task<T> SelecionarChaveAsync(params object[] variavel)
        {
            return await _context.Set<T>().FindAsync(variavel);
        }

        public List<T> SelecionarTodos()
        {
            return _context.Set<T>().ToList();
        }

        public async Task<List<T>> SelecionarTodosAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}
