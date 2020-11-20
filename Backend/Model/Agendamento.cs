using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model
{
    public class Agendamento
    {
        public Guid Id { get; set; }
        public int SalaNumero { get; set; }
        public string Titulo { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }


        public bool Validar()
        {
            return true;
        }
    }
}
