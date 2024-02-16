using Agendamentos.Contexts;
using Agendamentos.Dtos;
using Agendamentos.Servicos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agendamentos.Controllers;

[ApiController]
[Route("v1/account")]
public class LoginController : ControllerBase
{
	private AgendamentoContext db;
    public LoginController(AgendamentoContext db)
    {
        this.db = db;
    }
    [HttpPost]
	[Route("login")]
	[AllowAnonymous]
	public async Task<ActionResult<dynamic>> Autenticacao([FromBody] DtoLogin usuario)
	{
		var user =  db.Usuario.FirstOrDefault(u => u.Username == usuario.Username && u.Senha == usuario.Senha);
		if (user == null)
		{
			return NotFound(new { message = "Usuário ou senha inválidos" });
		}

		var token = TokenService.GerarToken(usuario);
		user.Senha = "ADSJADLIAHJSDOASHIUhaiuhdisuahDY8ASD08E9asd";
		return new
		{
			login = $"Bem-vindo {user.Nome}",
			token = token,
		};
	}
}
