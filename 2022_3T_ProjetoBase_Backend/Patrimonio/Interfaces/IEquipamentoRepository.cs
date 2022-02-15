using Patrimonio.Domains;
using System.Collections;
using System.Collections.Generic;

namespace Patrimonio.Interfaces
{
    public interface IEquipamentoRepository
    {
        Equipamento Cadastrar(Equipamento equipamento);
        Equipamento Alterar(int id, Equipamento equipamento);
        void Excluir(Equipamento equipamento);
        IEnumerable<Equipamento> Listar();
        Equipamento BuscarPorId(int id);
    }
}
