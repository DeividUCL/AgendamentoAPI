using Agendamentos.Models;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Agendamentos.Classes
{
	public class Agenda
	{
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O Campo 'Data' precisa ser preenchido")]
        public DateTime Data { get; set; }
		[Required(ErrorMessage = "O Campo 'Hora' precisa ser preenchido")]
		public DateTime Hora { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int ConvidadoId { get; set; }
        public Convidado? Convidado { get; set; }
        public int ServicoId { get; set; }
        public Servico Servico { get; set; }

    }
}
