using EmprestimoJogos.Domain.Infra;
using EmprestimoJogos.Domain.Infra.Notificacoes;
using EmprestimoJogos.Domain.IServices;
using EmprestimoJogos.Domain.Models;
using EmprestimoJogos.Domain.Service;
using System.Web.Mvc;

namespace EmprestimoJogos.Controllers
{
    [Authorize]
    public class AmigosController : Controller
    {
        private readonly IAmigoService _AmigoService;
        private DataContext _context;

        public AmigosController()
        {
            //TConexao.Open();
            _AmigoService = new AmigoService(TConexao.unitofWork, TConexao.context);            
        }

        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Amigo amigo)
        {
            var amigoSalvo = _AmigoService.Salva(amigo);

            if (amigoSalvo != null)
                return Redirect("\\Amigos\\Amigos");
            else
            {
                ViewBag.Message = EscopoBase._notificacoes;
                return View(amigoSalvo);
            }
        }

        public ActionResult Amigos()
        {
            var amigos = _AmigoService.Get();
            return View(amigos);
        }

        public ActionResult Details(int id)
        {
            var amigo = _AmigoService.Get(id);
            return View(amigo);
        }

 
        public ActionResult Edit(int id)
        {
            var amigo = _AmigoService.Get(id);
            return View(amigo);
        }

        [HttpPost]
        public ActionResult Edit( Amigo amigo)
        {
            var amigoAtualizado = _AmigoService.Atualiza(amigo.Id, amigo);
            if (amigoAtualizado != null)
                return Redirect("\\Amigos\\Amigos");
            else
            {
                ViewBag.Mensagem = EscopoBase._notificacoes;
                return View(amigo);
            }
        }

        public ActionResult Exclusao(int id)
        {
            var jogo = _AmigoService.Get(id);
            return View(jogo);
        }

        [HttpPost]
        public ActionResult Exclusao(Amigo amigo)
        {
            var jogoExcluido = _AmigoService.Delete(amigo.Id);

            if (jogoExcluido != null)
                return Redirect("\\Amigos\\Amigos");
            else
            {
                ViewBag.Mensagem = EscopoBase._notificacoes;
                return View(amigo);
            }
        }



    }
}