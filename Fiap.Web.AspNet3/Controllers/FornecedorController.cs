using Fiap.Web.AspNet3.Controllers.Filters;
using Fiap.Web.AspNet3.Models;
using Fiap.Web.AspNet3.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.AspNet3.Controllers
{
    [FiapLogFilter]
    [FiapAuthFilter]
    public class FornecedorController : Controller
    {
        private readonly IFornecedorRepository fornecedoresRepository;

        public FornecedorController(IFornecedorRepository fornecedor)
        {
            this.fornecedoresRepository = fornecedor;
        }


        public IActionResult Index()
        {
            var forn = fornecedoresRepository.FindAll();

            return View(forn);
        }


        public IActionResult Details(int id)
        {

            var fornecedorModel = fornecedoresRepository.FindById(id);
            if (fornecedorModel == null)
            {
                return NotFound();
            }

            return View(fornecedorModel);
        }

        // GET: Fornecedor/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FornecedorId,FornecedorNome,Cnpj,Telefone,Email")] FornecedorModel fornecedorModel)
        {
            if (ModelState.IsValid)
            {
                fornecedoresRepository.Insert(fornecedorModel);
                return RedirectToAction(nameof(Index));
            }
            return View(fornecedorModel);
        }

        // GET: Fornecedor/Edit/5
        public IActionResult Edit(int id)
        {
            var fornecedorModel = fornecedoresRepository.FindById(id);
            if (fornecedorModel == null)
            {
                return NotFound();
            }
            return View(fornecedorModel);
        }

        // POST: Fornecedor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("FornecedorId,FornecedorNome,Cnpj,Telefone,Email")] FornecedorModel fornecedorModel)
        {
            if (id != fornecedorModel.FornecedorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                fornecedoresRepository.Update(fornecedorModel);
                return RedirectToAction(nameof(Index));
            }
            return View(fornecedorModel);
        }

        // GET: Fornecedor/Delete/5
        public IActionResult Delete(int id)
        {


            var fornecedorModel = fornecedoresRepository.FindById(id);
            if (fornecedorModel == null)
            {
                return NotFound();
            }

            return View(fornecedorModel);
        }

        // POST: Fornecedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {

            var fornecedorModel = fornecedoresRepository.FindById(id);
            if (fornecedorModel != null)
            {
                fornecedoresRepository.Delete(fornecedorModel);
            }

            return RedirectToAction(nameof(Index));
        }


    }
}
