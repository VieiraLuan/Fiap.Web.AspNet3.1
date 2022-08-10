using Fiap.Web.AspNet3.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fiap.Web.AspNet3.ViewModels
{
    public class CadastroProdutoViewModel
    {
        /*
        //Alimenta
        public IList<LojaModel> Lojas { get; set; }

        //Volta

        public int ProdutoLojaId { get; set; }

        public string ProdutoNome { get; set; }

        public string[] LojasSelecionadas { get; set; }
        */

        public string? ProdutoNome { get; set; } // Cadastro do nome do Produto
        public ICollection<int> LojaId { get; set; } // Cadastro das lojas para o produto
        public IList<LojaViewModel> Lojas { get; set; } // View das Lojas 







    }




}
