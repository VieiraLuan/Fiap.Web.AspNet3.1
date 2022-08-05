
using AutoMapper;
using Fiap.Web.AspNet3.Controllers.Filters;
using Fiap.Web.AspNet3.Models;
using Fiap.Web.AspNet3.Repository.Interface;
using Fiap.Web.AspNet3.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fiap.Web.AspNet3.Controllers
{
    [FiapLogFilter]
    public class ClientController : Controller
    {

        private readonly IClienteRepository clienteRepository;
        private readonly IRepresentanteRepository representanteRepository;
        private readonly IMapper mapper;

        public ClientController(IClienteRepository cliente, IRepresentanteRepository representante, IMapper mapper)
        {
            clienteRepository = cliente;
            representanteRepository = representante;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {

            var isLogged = String.IsNullOrEmpty(HttpContext.Session.GetString("email")) ? false : true;

            if (!isLogged)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {

                var vm = new ClientePesquisaViewModel();


                // ViewBag.representantes = ComboRepresentantes();
                vm.Representantes = ComboRepresentantes();

                return View(vm);
            }
        }


        [HttpPost]
        public IActionResult Pesquisar(ClientePesquisaViewModel clientePesquisaViewModel)
        {
            var nome = clientePesquisaViewModel.ClienteNome;

            var email = clientePesquisaViewModel.ClienteEmail;

            var idRepre = clientePesquisaViewModel.RepresentanteId;

            if (nome == null)
            {
                nome = "";
            }
            if (email == null)
            {
                email = "";
            }

            var listaClientes = clienteRepository.FindByNameAndEmailAndRepresentante(nome, email, idRepre);

            var listaRepresentantesVM = mapper.Map<List<ClienteViewModel>>(listaClientes);

            clientePesquisaViewModel.Clientes = listaRepresentantesVM;

            clientePesquisaViewModel.Representantes = ComboRepresentantes();

            return View("Index", clientePesquisaViewModel);
        }


        public IActionResult NewClient()
        {
            ViewBag.representantes = ComboRepresentantes();

            return View(new ClientModel());
        }

        private SelectList ComboRepresentantes()
        {
            var listaRepresentantes = representanteRepository.FindAll();
            var listaRepresentantesVM = mapper.Map<List<RepresentanteViewModel>>(listaRepresentantes);

            var selectListRepresentantes = new SelectList(listaRepresentantesVM, "RepresentanteId", "NomeRepresentante");
            return selectListRepresentantes;
        }

        private IList<ClientModel> ListarTodosClientes()
        {
            return clienteRepository.FindAll();
        }

        [HttpPost]
        public IActionResult NewClient(ClientModel clientModel)
        {
            if (ModelState.IsValid)
            {
                clienteRepository.Insert(clientModel);
                TempData["mensagem"] = "Cliente cadastrado com sucesso";/*Retorna Mensagem de Sucesso na View*/

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.representantes = ComboRepresentantes();

                return View(clientModel);
            }
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var cliente = clienteRepository.FindById(id);

            ViewBag.representantes = ComboRepresentantes();


            return View(cliente);
        }

        [HttpPost]
        public IActionResult Edit(ClientModel clientModel)/*Passar por parametro a classe e um objeto para carregar*/
        {

            if (ModelState.IsValid)
            {
                clienteRepository.Update(clientModel);
                TempData["mensagem"] = "Cliente Alterado com Sucesso"; /*Exibe Mensagem de Sucesso na View*/

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.representantes = ComboRepresentantes();
                return View(clientModel);
            }

        }


        public IActionResult Detales(int id)
        {
            var cliente = clienteRepository.FindById(id);

            return View(cliente);
        }




    }
}
