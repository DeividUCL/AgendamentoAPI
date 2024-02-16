using Agendamentos.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agendamentos.Data;

[Table("Usuario")]
public class Usuario
{
	public int Id { get; set; }
	[Required]
	[StringLength(50)]
	public string Username { get; set; } = string.Empty;
	[Required]
	[StringLength(50)]
	public string Senha { get; set; } = string.Empty;
	[Required]
	public TTipoUsuario Tipo { get; set; }
	[Required]
	[StringLength(100)]
	public string Nome { get; set; } = string.Empty;
	[Required]
	[StringLength(100)]
	public string Email { get; set; } = string.Empty;
	public string Telefone { get; set; } = string.Empty;
	[Required]
	public DateTime DataNascimento { get; set; }
}
