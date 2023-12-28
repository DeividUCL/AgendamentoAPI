using System.ComponentModel.DataAnnotations;

namespace Agendamentos.Classes
{
	public class Usuario
	{
		[Key]
		[Required]
        public int Id { get; set; }
		[Required(ErrorMessage = "O cammpo 'Username' Precisa ser preenchido")]
        public string? Username { get; set; }
		[Required(ErrorMessage = "O campo 'Senha' precisa ser preenchido")]
        public string? Senha { get; set; }
		[Required(ErrorMessage = "O campo 'Tipo' precisa ser preenchido")]
        public string? Tipo { get; set; }
		[Required(ErrorMessage = "O campo 'Nome' precisa ser preenchido")]
		public string? Nome { get; set; }
		[Required(ErrorMessage = "O campo 'Email' precisa ser preenchido")]
		public string? Email { get; set; }
		[Required(ErrorMessage = "O campo 'Telefone' precisa ser preenchido")]
		public string? Telefone { get; set; }
		public DateTime DataNascimento { get; set; }
	}
}
