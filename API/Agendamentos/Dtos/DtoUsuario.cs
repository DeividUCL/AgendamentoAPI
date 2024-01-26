using Agendamentos.Contexts;
using Agendamentos.Data;
using Agendamentos.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Agendamentos.Dtos;

public class DtoUsuario
{
	public int Id { get; set; }
	[Required(ErrorMessage = "O campo 'Username' é obrigatório")]
	public string Username { get; set; }
	[Required(ErrorMessage = "O campo 'Senha' é obrigatório")]
	public string Senha { get; set; }
	[Required(ErrorMessage = "O campo 'Tipo' é obrigatório")]
	[Range(1,4, ErrorMessage = "Tipo de usuário não existe na nossa base de dados")]
	public TTipoUsuario Tipo { get; set; }
	[Required(ErrorMessage = "O campo 'Nome' é obrigatório")]
	public string Nome { get; set; }
	[Required(ErrorMessage = "O campo 'Email' é obrigatório")]
	public string Email { get; set; }
	[Required(ErrorMessage = "O campo 'Telefone' é obrigatório")]

	public string Telefone { get; set; }
	[Required]
	public DateTime DataNascimento { get; set; }

	public Usuario ToModel(AgendamentoContext db)
	{
		var user = db.Usuario.Find(this.Id);

		if (user == null)
			user = new Usuario();

		user.Username = this.Username;
		user. Senha = this.Senha;
		user.Tipo = this.Tipo;
		user.Nome = this.Nome;
		user.Email = this.Email;
		user.Telefone = this.Telefone;
		user.DataNascimento = this.DataNascimento;

		return user;
	}

	public static DtoUsuario FromModel(Usuario model)
	{
		return new DtoUsuario
		{
			Id = model.Id,
			Username = model.Username,
			Senha = model.Senha,
			Tipo = model.Tipo,
			Nome = model.Nome,
			Email = model.Email,
			Telefone = model.Telefone,
			DataNascimento = model.DataNascimento
		};
	}

}
