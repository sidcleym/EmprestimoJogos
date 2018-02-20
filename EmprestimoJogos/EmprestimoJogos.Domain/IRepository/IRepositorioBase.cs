using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoJogos.Domain.IRepository
{
    public interface IEntity
    {
        int ID { get; }
    }
    public interface IRepositorioBase<T> where T : class
     {
        DbSet<T> Get();
        T Get(object id);
        void Save(T item);
        void Save(IList<T> itens);        
        void Delete(T item);
        void Update(T item);
     }

}
