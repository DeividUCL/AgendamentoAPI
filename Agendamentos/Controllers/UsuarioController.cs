using Agendamentos.Classes;
using Agendamentos.Data;
using Microsoft.AspNetCore.Mvc;

namespace Agendamentos.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
	private UsuarioContext _context;

    public UsuarioController(UsuarioContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult CadastraUsuario([FromBody] Usuario usuario)
    {
        _context.Usuario.Add(usuario);
        _context.SaveChanges();
		return Ok("Cadastro realizado com sucesso!");
	}
}
