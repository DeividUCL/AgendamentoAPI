using Agendamentos.Enums;

namespace Agendamentos.Dtos
{
	public class DtoLogin
	{
		public string Username { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public TTipoUsuario Tipo { get; set; }
    }
}
