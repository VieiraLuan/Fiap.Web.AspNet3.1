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
    [FiapAuthFilter]
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository produtoRepository;
        private readonly ILojaRepository lojaRepository;
        private readonly IMapper mapper;

        public ProdutoController(IProdutoRepository produtoRepository, ILojaRepository lojaRepository, IMapper mapper)
        {
            this.produtoRepository = produtoRepository;
            this.lojaRepository = lojaRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {


            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var vm = new CadastroProdutoViewModel();
            var listaLojas = lojaRepository.FindAllLojas();

            vm.Lojas = mapper.Map<IList<LojaViewModel>>(listaLojas);
            /*AutoMapper Exemplo*/

            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(CadastroProdutoViewModel itemsCadastroVm)
        {
            try
            {
                //var produtoModel = mapper.Map<ProdutoModel>(itemsCadastroVm);

                ProdutoModel model = new ProdutoModel();
                //Montando o produto

                model.ProdutoNome = itemsCadastroVm.ProdutoNome;

                model.ProdutosLojas = new List<ProdutoLojaModel>();


                foreach (var item in itemsCadastroVm.LojaId)
                {
                    var pLM = new ProdutoLojaModel()
                    {
                        LojaId = item,
                        Produto = model
                    };
                    model.ProdutosLojas.Add(pLM);
                }


                produtoRepository.Insert(model);
                TempData["mensagemSucesso"] = $"Produto Cadastrado com sucesso!";



            }
            catch (Exception ex)
            {

                TempData["mensagemSucesso"] = $"Não foi possivel cadastrar o produto. Detalhe: {ex.Message}";
            }
            return RedirectToAction("Index");
        }

    }
}
