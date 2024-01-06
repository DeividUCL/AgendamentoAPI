using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Agendamentos.Data;

[DataContract]
public partial class Usuario
{
	[DataMember]
	public int Id { get; set; }
	[DataMember]
	public string Username { get; set; }
	[DataMember]
	public string Senha { get; set; }
	[DataMember]
	public string Tipo { get; set; }
	[DataMember]
	public string Nome { get; set; }
	[DataMember]
	public string Email { get; set; }
	[DataMember]
	public string Telefone { get; set; }
	[DataMember]
	public DateTime DataNascimento { get; set; }
}
