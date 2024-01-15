using Agendamentos.Contexts;
using Agendamentos.Data;
using Agendamentos.Dtos;
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
		public IActionResult CadastraUsuario([FromBody] DtoUsuario user)
		{
			var usuario = user.ToModel(db);
			if (usuario.Username == user.Senha)
			{
				return NotFound("Já existe um usuário cadastrado com esse nome");
			}
			usuario.Nome = user.Nome;
			usuario.Username = user.Username;
			usuario.Senha = user.Senha;
			usuario.Tipo = user.Tipo;
			usuario.Telefone = user.Telefone;
			usuario.Email = user.Email;
			usuario.DataNascimento = user.DataNascimento;

			db.Usuario.Add(usuario);
			db.SaveChanges();
			return Ok("Cadastro realidado com sucesso!");
		}

		[HttpGet]
		public ActionResult<IEnumerable<DtoUsuario>> Get()
		{
			try
			{
				var usuarios = db.Usuario
								.Select(u => new DtoUsuario
								{
									Id = u.Id,
									Nome = u.Nome,
									Username = u.Username,
									Senha = u.Senha,
									DataNascimento = u.DataNascimento,
									Email = u.Email,
									Telefone = u.Telefone,
								})
								.ToList();
				return Ok(usuarios);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
			}
		}
	}
}
