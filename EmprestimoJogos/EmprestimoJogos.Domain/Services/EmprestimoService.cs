using EmprestimoJogos.Domain.Infra;
using EmprestimoJogos.Domain.IRepository;
using EmprestimoJogos.Domain.IServices;
using EmprestimoJogos.Domain.Models;
using System;
using System.Linq;

namespace EmprestimoEmprestimos.Domain.Service
{
    public class EmprestimoService :ApplicationServiceBase, IEmprestimoService
    {
        private readonly IRepositorioBase<Emprestimo> _repositorioEmprestimo;

        private DataContext _context;


        public EmprestimoService(IUnitofWork unitOfWork,  DataContext context) : base(unitOfWork)
        {            
            this._repositorioEmprestimo = new RepositorioBase<Emprestimo>(context);
            this._context            = context;
        }
        
        public IQueryable Get()
        {
            return this._repositorioEmprestimo.Get().Include("Jogo") as IQueryable;
        }
        
        public Emprestimo Get(int id)
        {
            var Emprestimo   = _repositorioEmprestimo.Get().Include("Jogo").Where(x => x.Id == id).First();
           
            if (Emprestimo == null)
                throw new Exception("Emprestimo inexistente");

            return Emprestimo;
        }
        

    }
}
