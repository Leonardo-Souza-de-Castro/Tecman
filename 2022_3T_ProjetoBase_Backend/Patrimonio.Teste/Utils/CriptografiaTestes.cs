using Patrimonio.Utils;
using System.Text.RegularExpressions;
using Xunit;

namespace Patrimonio.Teste.Utils
{
    public class CriptografiaTestes
    {
        [Fact]
        public void Deve_Retornar_Hash_Em_BCripty()
        {
            //Pré-Condição
            var senha = Cripto.Gerar_Hash("123456789");
            var regex = new Regex(@"^\$2[ayb]\$.{56}$");


            //Procedimento
            var retorno = regex.IsMatch(senha); //verifica se a senha criptografada ta no padrão da expressão regular

            //Resultado Esperado
            Assert.True(retorno);
        }

        [Fact]
        public void Deve_Retornar_Comparacao_Valida()
        {
            //Pré-Condição
            var senha = "123456789";
            var hash = "$2a$11$eycMJdKymFm.f8m.Q65ePONimHnGEzv0Uu8pN.jhYz/rqy8g7Gp56";
            //Procedimento
            var comparacao = Cripto.Comparar(senha, hash);

            //Resultado Esperado
            Assert.True(comparacao);
        }
    }
}
