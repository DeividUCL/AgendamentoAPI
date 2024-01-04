using Agendamentos.Classes;
using Agendamentos.Data;
using Agendamentos.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agendamentos.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AgendaController : ControllerBase
	{
		private AgendamentoContext db;
		

		public AgendaController(AgendamentoContext db)
		{
			this.db = db;

		}

		[HttpPost]
		public IActionResult Agendar([FromBody] DtoAgenda dtoAgenda) {
			if(ModelState.IsValid)
			{
				var agenda = new Agenda
				{
					Data = dtoAgenda.Data,
					Hora = dtoAgenda.Hora,
					UsuarioId = dtoAgenda.UsuarioId,
					ConvidadoId = dtoAgenda.ConvidadoId,
					ServicoId = dtoAgenda.ServicoId,
				};
				db.Agenda.Add(agenda);
				db.SaveChanges();
				return Ok();
			}
			return BadRequest("Dados inválidos");
        }
	}
}
