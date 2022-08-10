using Fiap.Web.AspNet3.Models;

namespace Fiap.Web.AspNet3.Repository.Interface
{
    public interface ILojaRepository
    {
        public IList<LojaModel> FindAllLojas();

        public int FindByName(string name);
    }
}
