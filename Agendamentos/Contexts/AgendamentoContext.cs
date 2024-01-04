using Agendamentos.Classes;
using Agendamentos.Models;
using Microsoft.EntityFrameworkCore;

namespace Agendamentos.Data
{
	public class AgendamentoContext : DbContext
	{
        public AgendamentoContext(DbContextOptions<AgendamentoContext> options) : base(options)
        {
                        
        }
		public DbSet<Agenda> Agenda { get; set; }
		public DbSet<Servico> Servico { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Convidado> Convidado { get; set; }
    }
}
