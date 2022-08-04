

using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fiap.Web.AspNet3.ViewModels
{
    public class ClientePesquisaViewModel
    {
        //Vai
        public string ClienteNome { get; set; }

        public string ClienteEmail { get; set; }

        public int RepresentanteId { get; set; }

        public int ClientId { get; set; }

        //Carrega

        public SelectList Representantes { get; set; }


        //Volta
        public IList<ClienteViewModel> Clientes { get; set; }
    }
}
