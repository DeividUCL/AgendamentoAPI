using System.ComponentModel;

namespace Agendamentos.Enums;

public enum TTipoUsuario
{
	[Description("Gestor")]
	Gestor = 'G',
	[Description("Cliente")]
	Cliente = 'C',
	[Description("Funcionario")]
	Funcionario = 'F',
	[Description("Convidado")]
	Convidado = 'I'
}
