using Fiap.Web.AspNet3.Data;
using Fiap.Web.AspNet3.Models;
using Fiap.Web.AspNet3.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.AspNet3.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        public DataContext context { get; set; }
        public ClienteRepository(DataContext ctx)
        {
            context = ctx;
        }
        public IList<ClientModel> FindAll()
        {
            var listaclientes = context.Clients.Include(c => c.Representante).ToList();
            return listaclientes;
        }

        public IList<ClientModel> FindAllOrderByNomeAsc()
        {
            var listaclientes = context.Clients.
                Include(c => c.Representante).
                OrderBy(c => c.Name).ToList();


            return listaclientes;
        }

        public IList<ClientModel> FindAllOrderByNomeDesc()
        {
            var listaclientes = context.Clients.
                Include(c => c.Representante).
                OrderByDescending(c => c.Name).ToList();


            return listaclientes;
        }

        public ClientModel FindById(int id)
        {                   /*select * from clientes  inner join representantes   where    condicao*/
            var cliente = context.Clients.Include(c => c.Representante).SingleOrDefault(c => c.ClientId == id);


            return cliente;
        }
        public void Insert(ClientModel ClienteModel)
        {
            context.Clients.Add(ClienteModel);
            context.SaveChanges();
        }
        public void Update(ClientModel ClienteModel)
        {
            context.Clients.Update(ClienteModel);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            var cliente = FindById(id);
            Delete(cliente);
        }
        public void Delete(ClientModel ClienteModel)
        {
            context.Clients.Remove(ClienteModel);
            context.SaveChanges();
        }

        public IList<ClientModel> FindByName(string name)
        {
            var listaclientes = context.Clients.
               Include(c => c.Representante).
               Where(n => n.Name.Contains(name)).
               OrderBy(c => c.Name).ToList();
            return listaclientes;
        }

        public IList<ClientModel> FindByNameAndEmail(string name, string email)
        {
            var listaclientes = context.Clients.
               Include(c => c.Representante).
               Where(n => n.Name.Contains(name) && n.Email.Contains(email)).
               OrderBy(c => c.Name).ToList();
            return listaclientes;
        }

        public IList<ClientModel> FindByNameAndEmailAndRepresentante(string name, string email, int Idrepresentante)
        {
            var listaclientes = context.Clients.
               Include(c => c.Representante).
               Where(n => n.Name.Contains(name) && n.Email.Contains(email) && (0 == Idrepresentante || n.RepresentanteId == Idrepresentante)).
               OrderBy(c => c.Name).ToList();
            return listaclientes;
        }
    }
}