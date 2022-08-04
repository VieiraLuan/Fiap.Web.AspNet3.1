using AutoMapper;
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

        public IActionResult Index()
        {
            return View();
        }



        public IActionResult Login(LoginViewModel loginViewModel)
        {
            var usuario = mapper.Map<UsuarioModel>(loginViewModel);

            usuarioRepository.Login(usuario);

            return View();
        }

    }
}
