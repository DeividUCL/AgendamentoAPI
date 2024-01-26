using Agendamentos.Enums;

namespace Agendamentos.Dtos
{
	public class DtoLogin
	{
		public string Username { get; set; }
        public string Senha { get; set; }
        public TTipoUsuario Tipo { get; set; }
    }
}
