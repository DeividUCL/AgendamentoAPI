using Agendamentos.Contexts;
using Agendamentos.Dtos;
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
		public IActionResult Cadastrar([FromBody] DtoServico service)
		{
			var servico = service.ToModel(db);

			db.Servico.Add(servico);
			db.SaveChanges();
			return Ok();
		}
	}
}
