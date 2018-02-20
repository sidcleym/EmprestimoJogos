using EmprestimoJogos.Domain.EscopoValidacao;
using EmprestimoJogos.Domain.Helpers;
using EmprestimoJogos.Domain.Infra;
using EmprestimoJogos.Domain.IRepository;
using EmprestimoJogos.Domain.IServices;
using EmprestimoJogos.Domain.Models;
using System;
using System.Linq;

namespace EmprestimoJogos.Domain.Service
{
    public class AmigoService :ApplicationServiceBase, IAmigoService
    {
        private readonly IRepositorioBase<Amigo> _repositorioAmigo;
        private readonly IRepositorioBase<Emprestimo> _repositorioEmprestimo;
        private readonly DataContext _context;


        public AmigoService(IUnitofWork unitOfWork,  DataContext context) : base(unitOfWork)
        {
            this._context               = context;
            this._repositorioAmigo      = new RepositorioBase<Amigo>(context);
            this._repositorioEmprestimo = new RepositorioBase<Emprestimo>(context);
        }
       
        public IQueryable Get()
        {
            return this._repositorioAmigo.Get() as IQueryable;
        }

        public Amigo Get(int id)
        {
            var Amigo   = _repositorioAmigo.Get()
                .Include("Emprestimo.Jogo")
                .Where(x => x.Id == id).First();
           
            if (Amigo == null)
                throw new Exception("Usuário inexistente");

            return Amigo;
        }

        public Amigo Get(string login)
        {
            var Amigo = _repositorioAmigo.Get()
                .Include("Emprestimo.Jogo")
                .Where(x => x.Email == login).FirstOrDefault();

            if (Amigo == null)
                throw new Exception("Usuário inexistente");

            return Amigo;
        }

        public Amigo Salva(Amigo AmigoPostado)
        {
            AmigoPostado.DtInclusao      = DateTime.Now;
            AmigoPostado.Emprestimo      = null;

            AmigoEscopo.SalvarIsValid(AmigoPostado);
            

            _repositorioAmigo.Save(AmigoPostado);

            if (Commit())
                return AmigoPostado;

            return null;
        }

        public Amigo Atualiza(int id, Amigo AmigoPostado )
        {

            Amigo Amigo = _repositorioAmigo.Get().AsNoTracking().Where(x=> x.Id==id).FirstOrDefault();
            if (Amigo == null)
                throw new Exception("Amigo inexistente");

            AmigoPostado.Id            = id;
            AmigoPostado.DtInclusao    = Amigo.DtInclusao;
            AmigoPostado.DtAtualizacao = DateTime.Now;
            AmigoPostado.Emprestimo = null;
            AmigoEscopo.AtualizarIsValid(AmigoPostado);

            _repositorioAmigo.Update(AmigoPostado);
            if (Commit())
                return AmigoPostado;

            return null;
        }

        //Método usado para operações internas do sistema (login)
        public void Atualiza(Amigo Amigo)
        {
            var ususarioAntigo = _repositorioAmigo.Get(Amigo.Id);
           // _context.AmigoPerfil.Attach(Amigo.pctAmigoPerfil);
            this._context.Entry(ususarioAntigo).CurrentValues.SetValues(Amigo);
           // _repositorio.Atualiza(Amigo);
            
            this._context.SaveChanges();
        }

        public Amigo Delete(int id)
        {
            var Amigo = this._repositorioAmigo.Get(id);

            if (Amigo == null)
            {
                AmigoEscopo.CriaNotificacao("Ação inválida", "Usuário inexistente!");
                return null;
            }
           
			if(!AmigoEscopo.ExcluirIsValid(Amigo))
				return null;

            var jogos = _repositorioEmprestimo.Get().Include("Jogos").AsNoTracking().Where(x => x.AmigoId == id && x.Ativo).Select(x=> x.Jogo).ToList();
            if(jogos.Count > 0)
            {
                var lista = String.Join(",", jogos.Select(x => x.Descricao).ToList());
                AmigoEscopo.CriaNotificacao("Ação inválida", "Este amigo possui jogos emprestados: "+ lista);
                return null;
            }


            this._repositorioAmigo.Delete(Amigo);
            
            if (Commit())
                return Amigo;

            return null;

        }

    }
}
