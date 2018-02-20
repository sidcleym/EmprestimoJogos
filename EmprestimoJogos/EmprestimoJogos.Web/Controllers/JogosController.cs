using EmprestimoEmprestimos.Domain.Service;
using EmprestimoJogos.Domain.Infra;
using EmprestimoJogos.Domain.Infra.Notificacoes;
using EmprestimoJogos.Domain.IServices;
using EmprestimoJogos.Domain.Models;
using EmprestimoJogos.Domain.Service;
using EmprestimoJogos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EmprestimoJogos.Controllers
{
    [Authorize]
    public class JogosController : Controller
    {
        private IUsuarioService _usuarioService;
        private IAmigoService _amigoService;
        private IJogoService _jogoService;
        private IEmprestimoService _emprestimoService;

        public JogosController()
        {
            _usuarioService    = new UsuarioService(TConexao.unitofWork, TConexao.context);
            _amigoService      = new AmigoService(TConexao.unitofWork, TConexao.context);
            _jogoService       = new JogoService(TConexao.unitofWork, TConexao.context);
            _emprestimoService = new EmprestimoService(TConexao.unitofWork, TConexao.context);
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var amigo = _jogoService.Get(id);
            return View(amigo);
        }

        public ActionResult Jogos()
        {
            var Jogos = _jogoService.Get();
            return View(Jogos);
        }

        public ActionResult Create()
        {
            return View(new Jogo());
        }

        [HttpPost]
        public ActionResult Create(Jogo jogo)
        {
            var jogoSalvo = _jogoService.Salva(jogo);

            if (jogoSalvo != null)
                return Redirect("\\Jogos\\Jogos");
            else
                return View(jogoSalvo);
        }

        public ActionResult Edit(int id)
        {
            var amigo = _jogoService.Get(id);
            return View(amigo);
        }

        public ActionResult Exclusao(int id)
        {
            var jogo = _jogoService.Get(id);
            return View(jogo);
        }

        [HttpPost]
        public ActionResult Exclusao(Jogo jogo)
        {
            var jogoExcluido = _jogoService.Delete(jogo.Id);

            if (jogoExcluido != null)
                return Redirect("\\Jogos\\Jogos");
            else
            {
                ViewBag.Mensagem = EscopoBase._notificacoes;
                return View(jogo);
            }
        }

        [HttpPost]
        public ActionResult Edit(Jogo jogo)
        {
            var Jogo = _jogoService.Atualiza(jogo.Id,jogo);
            if (jogo != null)
                return Redirect("\\Jogos\\Jogos");
            else
                return View(jogo);
        }

        public ActionResult Emprestimo(int id)
        {
            ViewBag.Message = "Acessar";

            var jogo = _jogoService.Get(id);
            var emprestimo = new Emprestimo() { JogoId = id, Jogo = jogo };
            var model = new ModelEmprestimo() {Emprestimo = emprestimo };
            model.Amigos = (_amigoService.Get() as IQueryable<Amigo>).ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Emprestimo(Emprestimo emprestimo )
        {
            

            var retorno = _jogoService.Emprestar(emprestimo);

            if (retorno != null)
                return Redirect("\\Jogos\\Jogos");
            else
            {
                var jogo = _jogoService.Get(emprestimo.JogoId);
                emprestimo.Jogo = jogo;
                var model = new ModelEmprestimo() { Emprestimo = emprestimo, };
                model.Amigos = (_amigoService.Get() as IQueryable<Amigo>).ToList();

                ViewBag.Message = EscopoBase._notificacoes;
                return View(model);
            }
          
        }

        public ActionResult Devolucao(int id)
        {
            var emprestimo = (_emprestimoService.Get() as IQueryable<Emprestimo>).Where(x => x.JogoId == id && x.Ativo == true).FirstOrDefault();

            var amigo = _amigoService.Get(emprestimo.AmigoId);
            var model = new ModelEmprestimo() { Emprestimo = emprestimo, Amigos= new List<Amigo>(){ amigo } };
            
            //var amigo = _jogoService.Get(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Devolver(Emprestimo emprestimo)
        {
            var Jogo = _jogoService.Devolver(emprestimo);
            return Redirect("\\Jogos\\Jogos");
        }



    }
}