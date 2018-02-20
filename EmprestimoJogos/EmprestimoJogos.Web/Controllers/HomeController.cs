using EmprestimoJogos.Domain.Infra;
using EmprestimoJogos.Domain.IServices;
using EmprestimoJogos.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EmprestimoJogos.Controllers
{
    public class HomeController : Controller
    {
        private IUsuarioService _usuarioService;
        private IAmigoService _amigoService;
        private IJogoService _jogoService;

        public HomeController()
        {
            _usuarioService = new UsuarioService(TConexao.unitofWork, TConexao.context);
            _amigoService   = new AmigoService(TConexao.unitofWork, TConexao.context);
            _jogoService    = new JogoService(TConexao.unitofWork, TConexao.context);
        }
        public ActionResult Index()
        {
            return Redirect("\\Home\\Login");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Acessar";

            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return Redirect("\\Home");
        }

        [HttpPost]
        public ActionResult Login(Models.LoginMVC user, string ReturnUrl=null)
        {
            ViewBag.Message = "Acessar";

            if (_usuarioService.isLoginValid(user.Email, user.Senha))
            {
                FormsAuthentication.SetAuthCookie(user.Email, false);
                if (ReturnUrl != null)
                    return Redirect(ReturnUrl);
                else
                    return Redirect("\\Jogos\\Jogos");
            }
            else
            {
                return View(user);
            }
        }

        public ActionResult Amigos()
        {
            ViewBag.Message = "Amigos";
            var amigos = _amigoService.Get();
            
            return View(amigos);
        }


        public ActionResult Jogos()
        {
            var jogos = _jogoService.Get();

            return View(jogos);
        }

    }
}