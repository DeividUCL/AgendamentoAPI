using System.ComponentModel;

namespace Agendamentos.Enums;

public enum TTipoUsuario
{
	[Description("Gestor")]
	Gestor = 1,
	[Description("Cliente")]
	Cliente = 2,
	[Description("Funcionario")]
	Funcionario = 3,
	[Description("Convidado")]
	Convidado = 4
}
