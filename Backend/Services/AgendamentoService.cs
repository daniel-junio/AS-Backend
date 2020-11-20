using Backend.Interfaces;
using Backend.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services
{
    public class AgendamentoService : IAgendamentoService
    {
        

        private readonly ApiDbContext _context;
        public AgendamentoService(ApiDbContext context)
        {
            _context = context;
        }

        public  bool Inserir(Agendamento agendamentoDesejado)
        {
            if (agendamentoDesejado == null || !agendamentoDesejado.Validar())
                return false;

            var agendamentosExistentes = _context.Agendamentos.Where(x => x.SalaNumero == agendamentoDesejado.SalaNumero && x.Data == agendamentoDesejado.Data);

            if(agendamentosExistentes == null)
            {
                 _context.Agendamentos.Add(agendamentoDesejado);
                _context.SaveChanges();
                return true;
            }

            foreach(var agendamentoexistente in agendamentosExistentes)
            {
                if (ExisteConflito(agendamentoDesejado, agendamentoexistente))
                    return false;
            }

            _context.Agendamentos.Add(agendamentoDesejado);
            _context.SaveChanges();
            return true;
        }

        public async Task<List<Agendamento>> ObterTodos()
        {
            return  await _context.Agendamentos.OrderByDescending(x => x.Data).ToListAsync();
        }

        private bool ExisteConflito(Agendamento agendamentoDesejado, Agendamento agendamentoExistente)
        {
            if(agendamentoDesejado.HoraFim < agendamentoExistente.HoraInicio || agendamentoDesejado.HoraInicio > agendamentoExistente.HoraFim)
            {
                return false;
            }
            return true;
        }
    }
}
