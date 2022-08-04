using Fiap.Web.AspNet3.Models;
using Fiap.Web.AspNet3.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.AspNet3.Controllers
{
    public class GerenteController : Controller
    {
        private readonly IGerenteRepository gerenteRepository;

        public GerenteController(IGerenteRepository gerente)
        {
            this.gerenteRepository = gerente;
        }


        /*Chamada*/
        public IActionResult Create()
        {
            return View();
        }

        /*Consulta*/

        [HttpGet]
        public IActionResult Index()
        {
            var listaGerentes = gerenteRepository.FindAll();

            return View(listaGerentes);
        }



        [HttpGet]
        public IActionResult Details(int id)
        {

            var gerenteModel = gerenteRepository.FindById(id);

            if (gerenteModel == null)
            {
                return NotFound();
            }

            return View(gerenteModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            var gerenteModel = gerenteRepository.FindById(id);
            gerenteRepository.Update(gerenteModel);


            if (gerenteModel == null)
            {
                return NotFound();
            }
            return View(gerenteModel);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var gerenteModel = gerenteRepository.FindById(id);
            gerenteRepository.Delete(gerenteModel);

            if (gerenteModel == null)
            {
                return NotFound();
            }

            return View(gerenteModel);
        }



        /*Inserir*/


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("GerenteId,Nome,Sobrenome")] GerenteModel gerenteModel)
        {
            if (ModelState.IsValid)
            {
                gerenteRepository.Insert(gerenteModel);
                return RedirectToAction(nameof(Index));
            }

            return View(gerenteModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("GerenteId,Nome,Sobrenome")] GerenteModel gerenteModel)
        {
            if (id != gerenteModel.GerenteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                gerenteRepository.Update(gerenteModel);

                return RedirectToAction(nameof(Index));
            }
            return View(gerenteModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {

            var gerenteModel = gerenteRepository.FindById(id);

            if (gerenteModel != null)
            {
                gerenteRepository.Delete(gerenteModel);
            }

            return RedirectToAction(nameof(Index));
        }




    }
}
