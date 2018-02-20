using EmprestimoJogos.Domain.Infra;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace EmprestimoJogos.Domain.IRepository
{
    public class RepositorioBase<T> : IDisposable, IRepositorioBase<T> where T : class
    {
        protected readonly DataContext _context;
               
        public RepositorioBase(DataContext context)
        {
            this._context = context;
        }

        public DbSet<T> Get()
        {
            return this._context.Set<T>();
        }

        public T Get(object id)
        {
            return this._context.Set<T>().Find(id);
        }

        public void Save(T item)
        {
            this._context.Set<T>().Add(item);
            
        }

        public void Save(IList<T> itens)
        {
            this._context.Set<T>().AddRange(itens);
        }

        public void Delete(T item)
        {
            this._context.Set<T>().Remove(item);
        }

        public void Update(T item)
        {
            var enti = this._context.Entry<T>(item);
            enti.State = EntityState.Modified;
        }

        public void Dispose()
        {

           // this._context.Dispose();
        }

    }
}
