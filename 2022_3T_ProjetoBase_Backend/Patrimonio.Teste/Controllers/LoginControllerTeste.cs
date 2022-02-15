using Microsoft.AspNetCore.Mvc;
using Moq;
using Patrimonio.Controllers;
using Patrimonio.Domains;
using Patrimonio.Interfaces;
using Patrimonio.ViewModels;
using Xunit;

namespace Patrimonio.Teste.Controllers
{
    public class LoginControllerTeste
    {
        [Fact]
        public void Deve_Retornar_um_Usuario_Invalido()
        {
            // Pré-Condição
            var fakerepository = new Mock<IUsuarioRepository>();
            fakerepository.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns((Usuario)null); //Dessa maneira ele gera duas strings aleatorios para fazer a requisição e depois retorna um Usuario porém vazio.

            LoginViewModel dados = new LoginViewModel();
            dados.Senha = "123456789";
            dados.Email = "paulo@email.com";

            var controller = new LoginController(fakerepository.Object);

            //Procedimento
            var resultado = controller.Login(dados);


            //Resultado Esperado
            Assert.IsType<UnauthorizedObjectResult>(resultado);
        }

        [Fact]
        public void Deve_Retornar_um_Usuario_Valido()
        {
            // Pré-Condição
            var usuarioFake = new Usuario();

            usuarioFake.Email = "paulo@email.com";
            usuarioFake.Senha = "$2a$11$eycMJdKymFm.f8m.Q65ePONimHnGEzv0Uu8pN.jhYz/rqy8g7Gp56";

            var fakerepository = new Mock<IUsuarioRepository>();
            fakerepository.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns(usuarioFake); //Dessa maneira ele gera duas strings aleatorios para fazer a requisição e depois retorna um Usuario porém vazio.

            LoginViewModel dados = new LoginViewModel();
            dados.Senha = "123456789";
            dados.Email = "paulo@email.com";

            var controller = new LoginController(fakerepository.Object);

            //Procedimento
            var resultado = controller.Login(dados);


            //Resultado Esperado
            Assert.IsType<OkObjectResult>(resultado);
        }
    }
}
