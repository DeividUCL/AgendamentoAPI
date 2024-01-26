namespace Agendamentos.Data;

public partial class PermissaoUsuario
{
	public int Id { get; set; }
	public string Nome { get; set; }
	public Permissao Permissao { get; set; }


}

