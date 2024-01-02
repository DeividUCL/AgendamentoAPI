using Agendamentos.Classes;
using Agendamentos.Data;
using Microsoft.AspNetCore.Mvc;

namespace Agendamentos.Controllers
{
	[Controller]
	[Route("[controller]")]
	public class ServicoController : ControllerBase
	{
		private ServicoContext _context;
        public ServicoController(ServicoContext context)
        {
			_context = context;
        }

		[HttpPost]
		public IActionResult CadastrarServico([FromBody] Servico servico) 
		{
			_context.Servico.Add(servico);
			_context.SaveChanges();
			return Ok("Serviço cadastrado com sucesso");
        }

		[HttpGet("{id}")]
		public ActionResult Get(int id)
		{
			var servico = _context.Servico.FirstOrDefault(servico => servico.Id == id);
			if (servico == null) return NotFound();
			return Ok(servico);
		}
	}
}
