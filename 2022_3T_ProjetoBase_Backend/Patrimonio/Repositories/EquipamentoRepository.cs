using Microsoft.EntityFrameworkCore;
using Patrimonio.Contexts;
using Patrimonio.Domains;
using Patrimonio.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Patrimonio.Repositories
{
    public class EquipamentoRepository : IEquipamentoRepository
    {

        private readonly PatrimonioContext ctx;

        public EquipamentoRepository(PatrimonioContext appContext)
        {
            ctx = appContext;
        }

        public Equipamento Alterar(int id, Equipamento equipamento)
        {
            Equipamento equipamentobuscado = BuscarPorId(id);

            if (equipamento.Descricao != null)
            {
                equipamentobuscado.Descricao = equipamento.Descricao;
            }
            if (equipamento.Ativo != null)
            {
                equipamentobuscado.Ativo = equipamento.Ativo;
            }
            if (equipamento.NomePatrimonio != null)
            {
                equipamentobuscado.NomePatrimonio = equipamento.NomePatrimonio;
            }

            ctx.Equipamentos.Update(equipamentobuscado);

            ctx.SaveChanges();

            return equipamentobuscado;
        }

        public Equipamento Cadastrar(Equipamento equipamento)
        {
            ctx.Equipamentos.Add(equipamento);
            ctx.SaveChangesAsync();

            return equipamento;
        }

        public void Excluir(Equipamento equipamento)
        {
            ctx.Equipamentos.Remove(equipamento);
            ctx.SaveChangesAsync();
        }

        public IEnumerable<Equipamento> Listar()
        {
            return ctx.Equipamentos.ToList();
        }

        public Equipamento BuscarPorId(int id)
        {
            return ctx.Equipamentos.FirstOrDefault(E => E.Id == id);
        }

        
    }
}
