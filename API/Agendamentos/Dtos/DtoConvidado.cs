using Agendamentos.Contexts;
using Agendamentos.Data;
using System.ComponentModel.DataAnnotations;

namespace Agendamentos.Dtos;
public class DtoConvidado
{
	public int Id { get; set; }
	[Required(ErrorMessage = "O campo 'Nome' é obrigatório")]
	public string Nome { get; set; }
	public string? Email { get; set; }
	public string? Telefone { get; set; }

	public Convidado ToModel(AgendamentoContext db)
	{
		var convidado = db.Convidado.Find(this.Id);

		if (convidado == null)
			convidado = new Convidado();

		convidado.Id = this.Id;
		convidado.Nome = this.Nome;
		convidado.Email = this.Email;
		convidado.Telefone = this.Telefone;

		return convidado;
	}

	public static DtoConvidado FromModel(Usuario model)
	{
		return new DtoConvidado
		{
			Id = model.Id,
			Nome = model.Nome,
			Email = model.Email,
			Telefone = model.Telefone,
		};
	}
}
