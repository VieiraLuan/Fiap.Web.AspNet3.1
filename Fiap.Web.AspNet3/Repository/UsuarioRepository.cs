using Fiap.Web.AspNet3.Data;
using Fiap.Web.AspNet3.Models;
using Fiap.Web.AspNet3.Repository.Interface;

namespace Fiap.Web.AspNet3.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext dataContext;

        public UsuarioRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }


         public UsuarioModel Login(UsuarioModel usuarioModel)
         {
            /* var usuario = dataContext.Usuarios.
                 Where(u => u.UsuarioEmail == usuarioModel.UsuarioEmail && u.UsuarioSenha == usuarioModel.UsuarioSenha);*/
            if (usuarioModel.UsuarioEmail.Equals("admin@fiap.com")&& usuarioModel.UsuarioSenha.Equals("12345"))
            {
                return new UsuarioModel()
                {
                    UsuarioId = 1,
                    UsuarioEmail = usuarioModel.UsuarioEmail,
                    UsuarioSenha = usuarioModel.UsuarioSenha,
                    UsuarioNome = "Teste"

                };
            }
            else
            {
                return null;
            }           
              

         }


       /* public UsuarioModel Login(UsuarioModel usuarioModel)
        {
            
            UsuarioModel usuario = dataContext.Usuarios
                            .SingleOrDefault(x => x.UsuarioEmail == usuarioModel.UsuarioEmail &&
                                        x.UsuarioSenha == usuarioModel.UsuarioSenha);
            
            return new UsuarioModel()
            {
                UsuarioNome = "Admin",
                UsuarioId = 1
            };
        }*/
    }
}
