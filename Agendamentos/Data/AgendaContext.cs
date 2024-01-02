using Agendamentos.Classes;
using Microsoft.EntityFrameworkCore;

namespace Agendamentos.Data
{
	public class AgendaContext : DbContext
	{
        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options)
        {
                        
        }
		public DbSet<Agenda> Agenda { get; set; }
	}
}
