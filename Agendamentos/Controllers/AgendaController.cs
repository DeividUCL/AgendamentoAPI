using Agendamentos.Classes;
using Agendamentos.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agendamentos.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AgendaController : ControllerBase
	{
		private AgendaContext _context;
		private UsuarioContext _usuarioContext;
		private ServicoContext _servicoContext;

		public AgendaController(AgendaContext context, UsuarioContext usuarioContext, ServicoContext servicoContext)
		{
			_context = context;
			_servicoContext = servicoContext;
			_usuarioContext = usuarioContext;

		}

		[HttpPost]
		public IActionResult Agenda([FromBody] Agenda agenda) {

			agenda.Usuario = _usuarioContext.Usuario.FirstOrDefault(a => a.Id == agenda.UsuarioId);
			agenda.Servico = _servicoContext.Servico.FirstOrDefault(a => a.Id == agenda.ServicoId);

			if (agenda.Usuario == null || agenda.Servico == null)
			{
				return BadRequest("Usuario ou Servico não encontrado");
			}

			_context.Agenda.Add(agenda);
			_context.SaveChanges();
            return Ok();
        }
	}
}
