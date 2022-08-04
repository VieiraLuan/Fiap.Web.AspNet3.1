using Fiap.Web.AspNet3.Models;

namespace Fiap.Web.AspNet3.Repository.Interface
{
    public interface IGerenteRepository
    {

        public List<GerenteModel> FindAll();

        public GerenteModel FindById(int id);

        public List<GerenteModel> FindByName(string name);

        public void Insert(GerenteModel gerenteModel);

        public void Update(GerenteModel gerenteModel);

        public void Delete(int IdGerente);
        public void Delete(GerenteModel gerenteModel);



    }
}
