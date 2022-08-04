using Fiap.Web.AspNet3.Data;
using Fiap.Web.AspNet3.Models;
using Fiap.Web.AspNet3.Repository.Interface;

namespace Fiap.Web.AspNet3.Repository
{
    public class GerenteRepository : IGerenteRepository
    {
        private readonly DataContext dataContext;

        public GerenteRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public List<GerenteModel> FindAll()
        {

            return dataContext.Gerentes.ToList<GerenteModel>();

        }

        public GerenteModel FindById(int id)
        {
            return dataContext.Gerentes.Find(id);
        }

        public List<GerenteModel> FindByName(string name)
        {
            if (name != null)
            {
                return dataContext.Gerentes.ToList<GerenteModel>();
            }

            return null;

        }

        public void Insert(GerenteModel gerenteModel)
        {
            dataContext.Gerentes.Add(gerenteModel);
            //e
            dataContext.SaveChanges();
        }

        public void Update(GerenteModel gerenteModel)
        {
            dataContext.Gerentes.Update(gerenteModel);
            dataContext.SaveChanges();
        }

        public void Delete(int IdGerente)
        {
            var gerente = FindById(IdGerente);
            Delete(gerente);
        }
        public void Delete(GerenteModel gerenteModel)
        {
            dataContext.Gerentes.Remove(gerenteModel);
            dataContext.SaveChanges();
        }


    }
}
