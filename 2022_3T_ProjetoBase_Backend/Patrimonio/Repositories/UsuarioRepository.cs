using Patrimonio.Contexts;
using Patrimonio.Domains;
using Patrimonio.Interfaces;
using Patrimonio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patrimonio.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly PatrimonioContext ctx;

        public UsuarioRepository(PatrimonioContext appContext)
        {
            ctx = appContext;
        }

        public Usuario Login(string email, string senha)
        {
            var usuario = ctx.Usuarios.FirstOrDefault(u => u.Email == email);

            if (usuario != null)
            {
                //Comparação para ver se a senha é criptografada ou não
                if (usuario.Senha.Length < 32)
                {
                    usuario.Senha = Cripto.Gerar_Hash(usuario.Senha);
                    ctx.Usuarios.Update(usuario);
                    ctx.SaveChanges();
                }

                bool comparado = Cripto.Comparar(senha, usuario.Senha);

                if (comparado == true)
                {
                    return usuario;
                }
            }

            return null;
        }
    }
}
