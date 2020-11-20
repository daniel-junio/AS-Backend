using Backend.DTOs;
using Backend.Interfaces.Adapters;
using Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Adapters
{
    public class AgendamentoAdapter : IAgendamentoAdapter
    {
        public Agendamento Adapt(AgendamentoDTO agendamentoDTO)
        {
            if (agendamentoDTO == null)
                return null;

            var horainicioArray = agendamentoDTO.HoraInicio.Split(':');
            var horafimArray = agendamentoDTO.HoraFim.Split(':');
            return new Agendamento 
            {
                HoraInicio = new TimeSpan(Convert.ToInt32(horainicioArray[0]), Convert.ToInt32(horainicioArray[1]), 0),
                HoraFim = new TimeSpan(Convert.ToInt32(horafimArray[0]), Convert.ToInt32(horafimArray[1]), 0),
                Data = agendamentoDTO.Data.Date,
                SalaNumero = agendamentoDTO.SalaNumero,
                Titulo = agendamentoDTO.Titulo
            };
        }
    }
}
