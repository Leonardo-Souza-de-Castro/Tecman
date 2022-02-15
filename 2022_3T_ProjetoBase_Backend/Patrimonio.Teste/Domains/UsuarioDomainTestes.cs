using Patrimonio.Domains;
using Xunit;

namespace Patrimonio.Teste.Domains
{
    public class UsuarioDomainTestes
    {
        [Fact] //Teste Unitario
        public void DeveRetornarUsuarioPreenchido() // A descrição vira o titulo do método
        {
            //Pré-Condição ou Arrange
            Usuario usuario = new Usuario();
            usuario.Email = "paulo@email.com";
            usuario.Senha = "123456789";

            //Procedimento ou Act
            bool resultado = true;
            if (usuario.Senha == null || usuario.Email == null)
            {
                resultado = false;
            }


            //Resultado esperado ou Assert
            Assert.True(resultado);
        }


    }
}
