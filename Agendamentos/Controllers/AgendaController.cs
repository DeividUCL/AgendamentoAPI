using Agendamentos.Classes;
using Microsoft.AspNetCore.Mvc;

namespace Agendamentos.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AgendaController : ControllerBase
	{
		private static List<Agenda> agendas = new List<Agenda>();

		[HttpPost]
		public void Agendar([FromBody] Agenda agenda) {
			agendas.Add(agenda);
            Console.WriteLine(agenda.Id);
            Console.WriteLine(agenda.Data);
            Console.WriteLine(agenda.Hora);
        }
	}
}
