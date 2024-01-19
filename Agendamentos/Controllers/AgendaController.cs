using Agendamentos.Contexts;
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
		public IActionResult Agendar([FromBody] DtoAgenda a) 
		{
			var agenda = a.ToModel(db);
			if (!ModelState.IsValid)
			{
				return BadRequest("Dados inválidos");
			}
			bool existeAgenda = db.Agenda.Any(e =>
			e.Data == a.Data &&
			e.Data.TimeOfDay == a.Data.TimeOfDay);

			if (existeAgenda)
			{
				return BadRequest("O Horário já está agendado");
			}
			db.Agenda.Add(agenda);
			db.SaveChanges();
			return Ok("Agendamento realizado com sucesso!");
		}

		[HttpGet]
		public ActionResult<IEnumerable<DtoAgenda>> Listar()
		{
			var agendas = db.Agenda.ToList();
			var dtos = agendas.Select(agenda => DtoAgenda.FromModel(agenda)).ToList();
			return Ok(dtos);
		}

		[HttpPut("{id}")]
		public ActionResult<DtoAgenda> Editar(int id, [FromBody] DtoAgenda alteraAgenda)
		{
			var agenda = db.Agenda.FirstOrDefault(a => a.Id == id);
			if (agenda == null)
			{
				BadRequest("Agenda não encontrada");
			}
			agenda = alteraAgenda.ToModel(db);
			db.SaveChanges();
			return Ok("Alteração realizada com sucesso!");
		}

		[HttpDelete("{id}")]
		public ActionResult<DtoAgenda> Delete(int id) 
		{
			var agenda = db.Agenda.FirstOrDefault(a => a.Id == id);
			if (agenda == null)
			{
				return BadRequest("Agenda não encontrada");
			}

			db.Agenda.Remove(agenda); 
			db.SaveChanges();

			return Ok("Agenda deletada!");
		}
	}
}
