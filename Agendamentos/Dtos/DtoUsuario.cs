namespace Agendamentos.Dtos;

public class DtoUsuario
{
	public int Id { get; set; }	
	public string Username { get; set; }
	public string Senha { get; set; }
	public string Tipo { get; set; }
	public string Nome { get; set; }
	public string Email { get; set; }
	public string Telefone { get; set; }
	public DateTime DataNascimento { get; set; }
}
