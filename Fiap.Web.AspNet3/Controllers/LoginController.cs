using AutoMapper;
using Fiap.Web.AspNet3.Controllers.Filters;
using Fiap.Web.AspNet3.Models;
using Fiap.Web.AspNet3.Repository.Interface;
using Fiap.Web.AspNet3.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.AspNet3.Controllers
{




    public class LoginController : Controller
    {

        private readonly IUsuarioRepository usuarioRepository;
        private readonly IMapper mapper;

        public LoginController(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            this.usuarioRepository = usuarioRepository;
            this.mapper = mapper;
        }
        [FiapLogFilter]
        public IActionResult Index()
        {
            return View();
        }
        [FiapAuthFilter]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
     
            return RedirectToAction("Index","Home");
        }



        public IActionResult Login(LoginViewModel loginViewModel)
        {
            var usuario = mapper.Map<UsuarioModel>(loginViewModel);

            var usuarioRetorno = usuarioRepository.Login(usuario);

            if(usuarioRetorno == null)
            {
                ViewBag.ErrorMessage = "Usuario ou senha inválido";
                return View("Index");
            }
            else
            {
                HttpContext.Session.SetString("email", loginViewModel.UsuarioEmail);
                HttpContext.Session.SetString("nome", usuarioRetorno.UsuarioNome);
                return RedirectToAction("Index","Home");
            }

            return View();
        }

    }
}
