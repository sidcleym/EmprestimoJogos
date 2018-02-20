using EmprestimoJogos.Domain.EscopoValidacao;
using EmprestimoJogos.Domain.Helpers;
using EmprestimoJogos.Domain.Infra;
using EmprestimoJogos.Domain.Infra.Notificacoes;
using EmprestimoJogos.Domain.IRepository;
using EmprestimoJogos.Domain.IServices;
using EmprestimoJogos.Domain.Models;
using System;
using System.Linq;

namespace EmprestimoJogos.Domain.Service
{
    public class JogoService :ApplicationServiceBase, IJogoService
    {
        private readonly IRepositorioBase<Jogo> _repositorioJogo;
        private readonly IRepositorioBase<Emprestimo> _repositorioEmprestimo;

        private DataContext _context;


        public JogoService(IUnitofWork unitOfWork,  DataContext context) : base(unitOfWork)
        {            
            this._repositorioJogo = new RepositorioBase<Jogo>(context);
            this._repositorioEmprestimo = new RepositorioBase<Emprestimo>(context);
            this._context            = context;
        }
        
        public IQueryable Get()
        {
            return this._repositorioJogo.Get() as IQueryable;
        }
        
        public Jogo Get(int id)
        {
            var Jogo   = _repositorioJogo.Get()
                .Include("Historico.Amigo")
                .Where(x => x.Id == id).First();
           
            if (Jogo == null)
                throw new Exception("Jogo inexistente");

            return Jogo;
        }
        
        public Jogo Salva(Jogo JogoPostado)
        {
            JogoPostado.DtInclusao      = DateTime.Now;
        
            JogoEscopo.SalvarIsValid(JogoPostado);

            JogoPostado.Historico = null;
            
            _repositorioJogo.Save(JogoPostado);

            if (Commit())
                return JogoPostado;

            return null;
        }

        public Emprestimo Emprestar(Emprestimo emprestimo)
        {
            emprestimo.DtInclusao  = DateTime.Now;
            emprestimo.DtDevolucao = null;
            emprestimo.Ativo       = true;
            
            var jogo        = _repositorioJogo.Get(emprestimo.JogoId);
            if (jogo.Emprestado) {
                EscopoBase.CriaNotificacao("Ação inválida","Este jogo já se encontra emprestado!");
                return null;
            }

            jogo.Emprestado = true;
            _repositorioJogo.Update(jogo);

            
            //Anulando o objeto jogo para naum ser cadastrado novamente
            emprestimo.Jogo = null;
            emprestimo.Amigo = null;
            
            _repositorioEmprestimo.Save(emprestimo);

            if (!Commit())
                return null;

            return emprestimo;

        }

        public Emprestimo Devolver(Emprestimo emprestimoPostado)
        {
           
            var jogo = _repositorioJogo.Get(emprestimoPostado.JogoId);
            jogo.Emprestado = false;
            _repositorioJogo.Update(jogo);


            var emprestimo = _repositorioEmprestimo.Get().AsNoTracking().Where(x=> x.Id== emprestimoPostado.Id).FirstOrDefault();
            //Anulando o objeto jogo para naum ser cadastrado novamente
            emprestimoPostado.Jogo = null;

            emprestimoPostado.Id          = emprestimo.Id;
            emprestimoPostado.Ativo       = false;
            emprestimoPostado.AmigoId     = emprestimo.AmigoId;
            emprestimoPostado.JogoId      = emprestimo.JogoId;
            emprestimoPostado.DtInclusao  = emprestimo.DtInclusao;
            emprestimoPostado.DtDevolucao = DateTime.Now;
            _repositorioEmprestimo.Update(emprestimoPostado);

            if (!Commit())
                return null;

            return emprestimoPostado;

        }


        public Jogo Atualiza(int id, Jogo JogoPostado )
        {

            Jogo Jogo = _repositorioJogo.Get().AsNoTracking().Where(x=> x.Id == id).FirstOrDefault();
            if (Jogo == null)
                throw new Exception("Jogo inexistente");

            JogoPostado.Id = id;
            JogoPostado.Emprestado = Jogo.Emprestado;
            JogoPostado.DtInclusao = Jogo.DtInclusao;
            JogoPostado.DtAtualizacao = DateTime.Now;
            JogoPostado.Historico = null;

            JogoEscopo.AtualizarIsValid(JogoPostado);

            _repositorioJogo.Update(JogoPostado);
            if (Commit())
                return Jogo;

            return null;
        }
        
        public Jogo Delete(int id)
        {
            var Jogo = this._repositorioJogo.Get(id);

            if (Jogo == null)
            {
                JogoEscopo.CriaNotificacao("Ação inválida","Usuário inexistente");
                return null;
            }
           
			if(!JogoEscopo.ExcluirIsValid(Jogo))
				return null;

            this._repositorioJogo.Delete(Jogo);
            
            if (Commit())
                return Jogo;

            return null;
        }

    }
}
