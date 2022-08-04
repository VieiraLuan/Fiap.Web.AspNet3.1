using Fiap.Web.AspNet3.Data;
using Fiap.Web.AspNet3.Models;
using Fiap.Web.AspNet3.Repository.Interface;

namespace Fiap.Web.AspNet3.Repository
{

    public class FornecedoresRepository : IFornecedorRepository
    {

        private readonly DataContext dtx;


        public FornecedoresRepository(DataContext dataContext)
        {
            dtx = dataContext;
        }

        public List<FornecedorModel> FindAll()
        {
            var fornecedor = dtx.Fornecedores.ToList();
            return fornecedor;
        }

        public FornecedorModel FindById(int id)
        {
            var fornecedor = dtx.Fornecedores.Find(id);


            return fornecedor;


        }

        public FornecedorModel FindByName(FornecedorModel fornecedorModel)
        {

            var lista = FindAll();
            int id = 0;

            lista.ForEach(value =>
            {
                if (value.FornecedorId.Equals(fornecedorModel.FornecedorNome))
                {
                    id = Convert.ToInt32(value.FornecedorId);
                    /*Devo colocar um Break ou Return aqui?*/
                }

            });

            return FindById(id);


        }

        /*Find By Name*/


        public void Insert(FornecedorModel fornecedorModel)
        {
            dtx.Fornecedores.Add(fornecedorModel);
            dtx.SaveChanges();
        }

        public void Update(FornecedorModel fornecedorModel)
        {
            var fornecedor = FindById(fornecedorModel.FornecedorId);
            dtx.Fornecedores.Update(fornecedor);
            dtx.SaveChanges();
        }

        public void Delete(int id)
        {
            var fornecedor = new FornecedorModel();
            fornecedor.FornecedorId = id;
            Delete(fornecedor);

        }

        public void Delete(FornecedorModel fornecedorModel)
        {
            dtx.Fornecedores.Remove(fornecedorModel);
            dtx.SaveChanges();

        }
    }
}
