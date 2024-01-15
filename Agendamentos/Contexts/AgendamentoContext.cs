using Agendamentos.Data;
using Agendamentos.Dtos;
using Agendamentos.Enums;
using Microsoft.EntityFrameworkCore;

namespace Agendamentos.Contexts;

public class AgendamentoContext : DbContext
{
	public AgendamentoContext(DbContextOptions<AgendamentoContext> options) : base(options)
	{

	}
	public DbSet<Agenda> Agenda { get; set; }
	public DbSet<Servico> Servico { get; set; }
	public DbSet<Usuario> Usuario { get; set; }
	public DbSet<Convidado> Convidado { get; set; }
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder
			.Entity<Usuario>()
			.Property(e => e.Tipo)
			.HasConversion(
							v => v.ToString(),
							v => Enum.Parse<TTipoUsuario>(v)
			);
	}
}
