using Agendamentos.Contexts;
using Agendamentos.Data;
using Microsoft.AspNetCore.Mvc;

namespace Agendamentos.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class UsuarioController : ControllerBase
	{
		private AgendamentoContext db;


		public UsuarioController(AgendamentoContext db)
		{
			this.db = db;

		}

		[HttpPost]
		public IActionResult CadastraUsuario([FromBody] Usuario usuario)
		{

			db.Usuario.Add(usuario);
			db.SaveChanges();
			return Ok();
		}
	}
}
