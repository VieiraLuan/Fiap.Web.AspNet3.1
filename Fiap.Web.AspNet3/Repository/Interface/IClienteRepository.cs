using Fiap.Web.AspNet3.Models;

namespace Fiap.Web.AspNet3.Repository.Interface
{
    public interface IClienteRepository
    {
        public IList<ClientModel> FindAll();

        public IList<ClientModel> FindAllOrderByNomeAsc();

        public IList<ClientModel> FindAllOrderByNomeDesc();

        public ClientModel FindById(int id);
        public void Insert(ClientModel ClienteModel);
        public void Update(ClientModel ClienteModel);
        public void Delete(int id);
        public void Delete(ClientModel ClienteModel);

        public IList<ClientModel> FindByName(string name);

        public IList<ClientModel> FindByNameAndEmail(string name, string email);

        public IList<ClientModel> FindByNameAndEmailAndRepresentante(string name, string email, int Idrepresentante);
    }
}
