using Agendamentos.Classes;
using Microsoft.EntityFrameworkCore;

namespace Agendamentos.Data;

public class ServicoContext : DbContext
{
    public ServicoContext(DbContextOptions<ServicoContext> options) : base(options)
    {
        
    }

    public DbSet<Servico> Servicos { get; set; }
}
