namespace EmprestimoJogos.Domain.Infra
{
    public class UnitofWork : IUnitofWork
    {
        private DataContext _context;

        public UnitofWork(DataContext context)
        {
            this._context = context;
        }

        public object  Commit(object objeto)
        {
            this._context.SaveChanges();			
            return this._context.Entry(objeto).GetDatabaseValues().ToObject();            

        }

        public void  Commit()
        {
            this._context.SaveChanges();           

        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}
