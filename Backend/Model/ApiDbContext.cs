using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Agendamento> Agendamentos { get; set; }
    }
}
