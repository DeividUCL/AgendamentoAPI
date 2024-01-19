using System.ComponentModel.DataAnnotations;

namespace Agendamentos.Dtos;
public class DtoConvidado
{
	public int Id { get; set; }
	[Required(ErrorMessage = "O campo 'Nome' é obrigatório")]
	public string Nome { get; set; }
	public string? Email { get; set; }
	public string? Telefone { get; set; }
}
