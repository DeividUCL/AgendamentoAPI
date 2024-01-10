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
		public IActionResult Agendar([FromBody] DtoAgenda dtoAgenda) 
		{
			if(!ModelState.IsValid)
			{
				return BadRequest("Dados inválidos");
			}

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
			return Ok("Agendamento realizado com sucesso!");
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> AlterarAgenda(int id, DtoAgenda dtoAgenda)
		{
			if(id != dtoAgenda.Id)
			{
				return BadRequest("A agenda não existe");
			}

			db.Entry(dtoAgenda).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			
			try
			{
				await db.SaveChangesAsync();
			}
			catch(DbUpdateConcurrencyException) 
			{

				if (!AgendaExists(id)) 
				{
					return NotFound("A agenda não existe");
				}
				else
				{
					return StatusCode(500, "Erro de concorrência ao atualizar a agenda");
				}
			}
			return NoContent();
		}
		private bool AgendaExists(int id)
		{
			// Verifique se a agenda com o ID fornecido existe no banco de dados.
			// Implemente a lógica de verificação de existência conforme necessário.
			return db.Agenda.Any(e => e.Id == id);
		}
	}
}
