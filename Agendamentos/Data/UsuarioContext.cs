using Agendamentos.Classes;
using Microsoft.EntityFrameworkCore;

namespace Agendamentos.Data
{
	public class UsuarioContext : DbContext
	{
		public UsuarioContext(DbContextOptions<UsuarioContext> options) : base(options)
		{

		}

		public DbSet<Usuario> Usuario { get; set; }
	}
}
