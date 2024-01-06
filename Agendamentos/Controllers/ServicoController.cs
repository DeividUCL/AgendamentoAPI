using Agendamentos.Contexts;
using Agendamentos.Data;
using Microsoft.AspNetCore.Mvc;

namespace Agendamentos.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ServicoController : ControllerBase
	{
		private AgendamentoContext db;


		public ServicoController(AgendamentoContext db)
		{
			this.db = db;

		}

		[HttpPost]
		public IActionResult Agenda([FromBody] Servico servico)
		{

			db.Servico.Add(servico);
			db.SaveChanges();
			return Ok();
		}
	}
}
