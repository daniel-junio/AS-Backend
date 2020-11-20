using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DTOs
{
    public class AgendamentoDTO
    {
        public Guid Id { get; set; }
        public int SalaNumero { get; set; }
        public string Titulo { get; set; }
        public DateTime Data { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFim { get; set; }
    }
}
