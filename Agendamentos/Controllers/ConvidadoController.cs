using Agendamentos.Contexts;
using Agendamentos.Data;
using Microsoft.AspNetCore.Mvc;

namespace Agendamentos.Controllers;

[ApiController]
[Route("[controller]")]
public class ConvidadoController : ControllerBase
{
	private AgendamentoContext db;


	public ConvidadoController(AgendamentoContext db)
	{
		this.db = db;

	}

	[HttpPost]
	public IActionResult CadastrarConvidado([FromBody] Convidado convidado)
	{

		db.Convidado.Add(convidado);
		db.SaveChanges();
		return Ok();
	}

}
