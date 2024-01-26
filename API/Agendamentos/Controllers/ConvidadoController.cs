using Agendamentos.Contexts;
using Agendamentos.Dtos;
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
	public IActionResult CadastrarConvidado([FromBody]  DtoConvidado cv)
	{
		var convidado = cv.ToModel(db);
		bool emailExiste = db.Convidado.Any(c => c.Email == cv.Email);

		if (!ModelState.IsValid) 
		{
			return BadRequest(ModelState);
		}

		if(emailExiste)
		{
			return BadRequest("O E-mail informado já está cadastrado.");
		}

		db.Convidado.Add(convidado);
		db.SaveChanges();
		return Ok("Convidado cadastrado com sucesso!");
	}

}
