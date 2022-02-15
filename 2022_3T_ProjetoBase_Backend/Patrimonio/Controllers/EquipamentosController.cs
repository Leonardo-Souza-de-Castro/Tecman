using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Patrimonio.Contexts;
using Patrimonio.Domains;
using Patrimonio.Interfaces;
using Patrimonio.Utils;

namespace Patrimonio.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EquipamentosController : ControllerBase
    {
        private readonly IEquipamentoRepository _equipamentoRepository;

        public EquipamentosController(IEquipamentoRepository context)
        {
            _equipamentoRepository = context;
        }

        // GET: api/Equipamentos
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_equipamentoRepository.Listar());
        }

        // GET: api/Equipamentos/5
        [HttpGet("{id}")]
        public IActionResult BuscarporId(int id)
        {
            return Ok(_equipamentoRepository.BuscarPorId(id));
        }

        // PUT: api/Equipamentos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        //public async Task<IActionResult> PutEquipamento(int id, Equipamento equipamento)
        //{
        //    if (id != equipamento.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(equipamento).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EquipamentoExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}
        public IActionResult Atualizar(int id, Equipamento equipamento)
        {
            _equipamentoRepository.Alterar(id, equipamento);

            return StatusCode(204);
        }

        // POST: api/Equipamentos
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Equipamento>> PostEquipamento([FromForm] Equipamento equipamento, IFormFile arquivo)
        {

            #region Upload da Imagem com extensões permitidas apenas
            string[] extensoesPermitidas = { "jpg", "png", "jpeg", "gif" };
            string uploadResultado = Upload.UploadFile(arquivo, extensoesPermitidas);

            if (uploadResultado == "")
            {
                return BadRequest("Arquivo não encontrado");
            }

            if (uploadResultado == "Extensão não permitida")
            {
                return BadRequest("Extensão de arquivo não permitida");
            }

            equipamento.Imagem = uploadResultado;
            #endregion

            // Pegando o horário do sistema
            equipamento.DataCadastro = DateTime.Now;

            _equipamentoRepository.Cadastrar(equipamento);
            return Created("Equipamento", equipamento);
        }

        //// DELETE: api/Equipamentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipamento(int id)
        {
            var equipamento = _equipamentoRepository.BuscarPorId(id);
            if (equipamento == null)
            {
                return NotFound();
            }

            _equipamentoRepository.Excluir(equipamento);

            // Removendo Arquivo do servidor
            Upload.RemoverArquivo(equipamento.Imagem);

            return NoContent();
        }

        //private bool EquipamentoExists(int id)
        //{
        //    return ctx.Equipamentos.Any(e => e.Id == id);
        //}
    }
}
