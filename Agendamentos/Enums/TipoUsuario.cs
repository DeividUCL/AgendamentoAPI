using System.ComponentModel;

namespace Agendamentos.Enums;

public enum TTipoUsuario
{
	[Description("Gestor")]
	Gestor,
	[Description("Cliente")]
	Cliente,
	[Description("Funcionario")]
	Funcionario,
	[Description("Convidado")]
	Convidado
}
