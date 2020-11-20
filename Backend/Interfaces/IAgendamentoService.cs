using Backend.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Backend.Interfaces
{
    public interface IAgendamentoService
    {
        bool Inserir(Agendamento agendamento);
        Task<List<Agendamento>> ObterTodos();
    }
}
