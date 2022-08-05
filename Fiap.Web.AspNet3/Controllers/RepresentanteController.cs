using Fiap.Web.AspNet3.Controllers.Filters;
using Fiap.Web.AspNet3.Models;
using Fiap.Web.AspNet3.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.AspNet3.Controllers
{
    [FiapLogFilter]
    public class RepresentanteController : Controller
    {


        private readonly IRepresentanteRepository representanteRepository;

        public RepresentanteController(IRepresentanteRepository repository)
        {
            representanteRepository = repository;
        }


        /*Chamada*/
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }


        /*Consulta*/


        [HttpGet]
        public IActionResult Index()
        {
            var listaRepresentates = representanteRepository.FindAll();

            return View(listaRepresentates);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {

            var representanteModel = representanteRepository.FindByIdWithClientes(id);
            if (representanteModel == null)
            {
                return NotFound();
            }

            return View(representanteModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {


            var representanteModel = representanteRepository.FindById(id);
            if (representanteModel == null)
            {
                return NotFound();
            }
            return View(representanteModel);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {


            var representanteModel = representanteRepository.FindById(id);
            if (representanteModel == null)
            {
                return NotFound();
            }

            return View(representanteModel);
        }
        /*Inserindo*/

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("RepresentanteId,NomeRepresentante")] RepresentanteModel representanteModel)
        {
            if (ModelState.IsValid)
            {
                representanteRepository.Insert(representanteModel);
                return RedirectToAction(nameof(Index));
            }
            return View(representanteModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("RepresentanteId,NomeRepresentante")] RepresentanteModel representanteModel)
        {
            if (id != representanteModel.RepresentanteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                representanteRepository.Update(representanteModel);

                return RedirectToAction(nameof(Index));
            }
            return View(representanteModel);
        }



        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {

            var representanteModel = representanteRepository.FindById(id);

            if (representanteModel != null)
            {
                representanteRepository.Delete(representanteModel);
            }

            return RedirectToAction(nameof(Index));
        }


    }
}
