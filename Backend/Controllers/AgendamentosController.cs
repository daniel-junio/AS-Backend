using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Model;
using Backend.Services;
using Backend.Interfaces;
using Backend.Interfaces.Adapters;
using Backend.DTOs;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentosController : ControllerBase
    {
        private readonly ApiDbContext _context;
        IAgendamentoService _agendamentoservice;
        IAgendamentoAdapter _agendamentoAdapter;

        public AgendamentosController(ApiDbContext context,
                                      IAgendamentoService AgendamentoService,
                                      IAgendamentoAdapter AgendamentoAdapter)
        {
            _context = context;
            _agendamentoservice = AgendamentoService;
            _agendamentoAdapter = AgendamentoAdapter;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agendamento>>> ListarAgendamentos()
        {
            var x = await _agendamentoservice.ObterTodos();
            return x;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Agendamento>> GetAgendamento(Guid id)
        {
            var agendamento = await _context.Agendamentos.FindAsync(id);
            
            if (agendamento == null)
            {
                return NotFound();
            }

            return  agendamento;
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgendamento(Guid id, Agendamento agendamento)
        {
            if (id != agendamento.Id)
            {
                return BadRequest("Erro");
            }

            _context.Entry(agendamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgendamentoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        
        [HttpPost("criar")]
        public  ActionResult CriarAgendamento(AgendamentoDTO agendamento)
        { 
            if ( _agendamentoservice.Inserir(_agendamentoAdapter.Adapt(agendamento)))
            {
                return Ok();
            }
            return BadRequest();

            /*
             
             criar uma classe agendamentoDTO

             criar uma classe agendamentoAdapter

             */

        }

        // DELETE: api/Agendamentos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Agendamento>> DeleteAgendamento(Guid id)
        {
            var agendamento = await _context.Agendamentos.FindAsync(id);
            if (agendamento == null)
            {
                return NotFound();
            }

            _context.Agendamentos.Remove(agendamento);
            await _context.SaveChangesAsync();

            return agendamento;
        }

        private bool AgendamentoExists(Guid id)
        {
            return _context.Agendamentos.Any(e => e.Id == id);
        }
    }
}
