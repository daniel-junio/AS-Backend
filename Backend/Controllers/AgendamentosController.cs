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

        
        [HttpPost("criar")]
        public  ActionResult CriarAgendamento(AgendamentoDTO agendamento)
        { 
            if ( _agendamentoservice.Inserir(_agendamentoAdapter.Adapt(agendamento)))
            {
                return Ok();
            }
            return BadRequest();
        }

        
    }
}
