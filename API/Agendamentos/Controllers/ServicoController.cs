using Agendamentos.Contexts;
using Agendamentos.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

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

		[HttpGet]
		public ActionResult<IEnumerable<DtoServico>> ExibirServicos()
		{
			var servicos = db.Servico.ToList();
			var dtos = servicos.Select(agenda => DtoServico.FromModel(agenda)).ToList();
			return Ok(dtos);
		}

		[HttpPut("{id}")]
		public ActionResult<DtoServico> Alterar(int id, [FromBody]DtoServico service)
		{
			var servico = db.Servico.FirstOrDefault(a => a.Id == id);
			if(servico == null)
			{
				return BadRequest("Servico não encontrado");
			}

			servico = service.ToModel(db);
			db.SaveChanges();
			return Ok("Alteração realizada com sucesso");
		}
	}
}
