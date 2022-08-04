using Fiap.Web.AspNet3.Models;
using Fiap.Web.AspNet3.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.AspNet3.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<RepresentanteModel> Representantes { get; set; }


        public DbSet<FornecedorModel> Fornecedores { get; set; }

        public DbSet<ClientModel> Clients { get; set; }

        public DbSet<GerenteModel> Gerentes { get; set; }

        public DbSet<ProdutoModel> Produtos { get; set; }

        public DbSet<LojaModel> Lojas { get; set; }

        public DbSet<ProdutoLojaModel> ProdutosLojas { get; set; }

        public DbSet<UsuarioModel> Usuarios { get; set; }

        public DbSet<LoginViewModel>? LoginViewModel { get; set; }



    }
}
