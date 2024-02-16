using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Agendamentos.Data;

[Table("Agenda")]
public partial class Agenda
{
    public int Id { get; set; }
	[Required(ErrorMessage = "É nessário preencher o campo 'Data'")]
	public DateTime Data { get; set; }
	[Required(ErrorMessage = "É necessário informar o 'Usuario'")]
	public int UsuarioId { get; set; }
	public int ConvidadoId { get; set; }
	[Required(ErrorMessage = "É necessário informar o 'Servico'")]
	public int ServicoId { get; set; }

}

