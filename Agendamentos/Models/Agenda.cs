using Agendamentos.Models;

namespace Agendamentos.Classes
{
	public class Agenda
	{
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public DateTime Hora { get; set; }
        public Usuario? Usuario { get; set; }
        public Convidado? Convidado { get; set; }
        public Servico Servico { get; set; }

    }
}
