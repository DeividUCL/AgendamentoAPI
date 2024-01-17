using Agendamentos.Contexts;
using Agendamentos.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using Agendamentos.Data;

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
		public IActionResult Cadastrar([FromBody] DtoUsuario user)
		{
			var usuario = user.ToModel(db);
			bool validaUser = db.Usuario.Any(u => u.Username == usuario.Username);
			if(validaUser)
			{
				return BadRequest("O usuário ja existe na nossa base de dados");
			}

			db.Usuario.Add(usuario);
			db.SaveChanges();
			return Ok("Cadastro realidado com sucesso!");
		}

		[HttpGet]
		public ActionResult<IEnumerable<DtoUsuario>> ExibirUsuarios()
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
						Tipo = u.Tipo,
					})
					.ToList();
				return Ok(usuarios);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
			}
		}

		[HttpDelete("{id}")]
		public ActionResult<DtoUsuario> Deletar(int id)
		{
			var usuario = db.Usuario.FirstOrDefault(u => u.Id == id);
			if(usuario == null)
			{
				return NotFound("Usuário não encontrado");
			}
			db.Usuario.Remove(usuario);
			db.SaveChanges();
			return Ok("Usuário excluído com sucesso");
		}

		[HttpPut("{id}")]
		public  ActionResult<DtoUsuario> AlterarDadosCompleto(int id, [FromBody] DtoUsuario novoUsuario)
		{
			var usuario = db.Usuario.FirstOrDefault(u => u.Id == id);
			
			if (usuario == null)
			{
				return NotFound("Usuário não encontrado");
			}

			usuario.Nome = novoUsuario.Nome;
			usuario.Senha = novoUsuario.Senha;
			usuario.Username = novoUsuario.Username;
			usuario.Tipo = novoUsuario.Tipo;
			usuario.Email = novoUsuario.Email;
			usuario.Telefone = novoUsuario.Telefone;

			db.SaveChanges();
			return Ok("Usuário alterado com sucesso");
		}

		[HttpPatch("{id}")]// não está funcionando -- VERIFICAR
		public IActionResult AlterarDado(int id, [FromBody] JsonPatchDocument<Usuario> alterarDado)
		{
			var usuarioExistente = db.Usuario.FirstOrDefault(u => u.Id == id);

			if(usuarioExistente == null)
			{
				return NotFound("Usuário não encontrado");
			}

			alterarDado.ApplyTo(usuarioExistente);

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			db.SaveChanges();

			return Ok("Campo alterado com sucesso");

		}
	}
}
