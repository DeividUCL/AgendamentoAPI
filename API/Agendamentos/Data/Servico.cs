using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agendamentos.Data;

[Table("Servico")]
public class Servico
{
    public int Id { get; set; }
	[Required(ErrorMessage = "Informe o 'nome' do serviço")]
	[StringLength(50)]
    public string Nome { get; set; } = string.Empty;
	public string Descricao { get; set; } = string.Empty;
	[Required(ErrorMessage = "Informe o 'preço' do serviço")]
	public decimal Preco { get; set; }
	[MinLength(10)]
	public int Duracao { get; set; }
}
