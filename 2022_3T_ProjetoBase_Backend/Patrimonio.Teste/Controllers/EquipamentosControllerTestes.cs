using Microsoft.AspNetCore.Mvc;
using Moq;
using Patrimonio.Controllers;
using Patrimonio.Domains;
using Patrimonio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Patrimonio.Teste.Controllers
{
    public class EquipamentosControllerTestes
    {
        [Fact]
        public void Deve_Listar_Os_Equipamentos()
        {
            var lista_equipamentos = new List<Equipamento>();

            //Equipamento equipamento1 = new Equipamento();

            var equip1 = new Equipamento();
            equip1.Id = 1;
            equip1.NomePatrimonio = "Computador";
            equip1.Imagem = "";
            equip1.Descricao = "Duo-core com 7 polegadas";
            equip1.Ativo = true;
            equip1.DataCadastro = DateTime.Now;

            var equip2 = new Equipamento();
            equip2.Id = 2;
            equip2.NomePatrimonio = "Estojo";
            equip2.Imagem = "";
            equip2.Descricao = "Tem ziper";
            equip2.Ativo = false;
            equip2.DataCadastro = DateTime.Now;

            lista_equipamentos.Add(equip1);
            lista_equipamentos.Add(equip2);

            var fakerepository = new Mock<IEquipamentoRepository>();
            fakerepository.Setup(x => x.Listar()).Returns(lista_equipamentos);

            var controller = new EquipamentosController(fakerepository.Object);


            var resultado = controller.Listar();


            Assert.IsType<OkObjectResult>(resultado);
        }

        [Fact]
        public void Deve_Listar_Um_Equipamento_Especifico()
        {
            var equip1 = new Equipamento();
            equip1.Id = 2;
            equip1.NomePatrimonio = "Computador";
            equip1.Imagem = "";
            equip1.Descricao = "Duo-core com 7 polegadas";
            equip1.Ativo = true;
            equip1.DataCadastro = DateTime.Now;

            var fakerepository = new Mock<IEquipamentoRepository>();
            fakerepository.Setup(x => x.BuscarPorId(equip1.Id)).Returns(equip1);

        var controller = new EquipamentosController(fakerepository.Object);


        var resultado = controller.BuscarporId(equip1.Id);


        Assert.IsType<OkObjectResult>(resultado);
        }

        [Fact]
        public void Deve_Atualizar_Um_Equipamento()
        {
            var equip1 = new Equipamento();
            equip1.Id = 2;
            equip1.NomePatrimonio = "Computador";
            equip1.Imagem = "";
            equip1.Descricao = "Duo-core com 7 polegadas";
            equip1.Ativo = true;
            equip1.DataCadastro = DateTime.Now;

            var fakerepository = new Mock<IEquipamentoRepository>();
            fakerepository.Setup(x => x.Alterar(equip1.Id, equip1));

            var controller = new EquipamentosController(fakerepository.Object);

            var resultado = controller.Atualizar(equip1.Id, equip1);

            Assert.IsType<OkObjectResult>(resultado);
        }
    }
}
