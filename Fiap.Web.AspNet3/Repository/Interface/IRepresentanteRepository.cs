using Fiap.Web.AspNet3.Models;

namespace Fiap.Web.AspNet3.Repository.Interface
{
    public interface IRepresentanteRepository
    {


        public IList<RepresentanteModel> FindAll();

        public RepresentanteModel? FindById(int id);

        public RepresentanteModel? FindByIdWithClientes(int id);

        public IList<RepresentanteModel> FindByName(string name);

        public void Insert(RepresentanteModel representanteModel);

        public void Update(RepresentanteModel representanteModel);

        public void Delete(int idRepresentante);
        public void Delete(RepresentanteModel representanteModel);
    }
}
