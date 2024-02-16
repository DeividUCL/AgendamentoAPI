using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agendamentos.Data;

[Table("Convidado")]
public class Convidado
{
    public int Id { get; set; }
    [Required(ErrorMessage = "É necessário informar o campo 'nome'")]
	[StringLength(100)]
	public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
	[Required(ErrorMessage = "É necessário informar o campo 'telefone'")]
	[StringLength(12)]
	public string Telefone { get; set; } = string.Empty;
}
