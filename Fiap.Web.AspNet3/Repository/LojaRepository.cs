using Fiap.Web.AspNet3.Data;
using Fiap.Web.AspNet3.Models;
using Fiap.Web.AspNet3.Repository.Interface;

namespace Fiap.Web.AspNet3.Repository
{
    public class LojaRepository : ILojaRepository
    {
        private readonly DataContext dataContext;

        public LojaRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public IList<LojaModel> FindAllLojas()
        {
            return dataContext.Lojas.ToList();
        }

        public int FindByName(string name)
        {
            var listaLojas = FindAllLojas();
            int idLoja = 0;
            foreach(var item in listaLojas)
            {
                if (item.LojaNome.Equals(name))
                {
                    idLoja = item.LojaId;
                }
            }
            return idLoja;
        }
    }
}
