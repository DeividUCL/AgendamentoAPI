using System.ComponentModel.DataAnnotations;

namespace Agendamentos.Classes
{
	public class Servico
	{
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo 'Nome' é obrigatório")]
        public string Nome { get; set; }
        public string? Descricao { get; set; }
		[Required(ErrorMessage = "O campo 'Preco' é obrigatório")]
		public decimal Preco { get; set; }
        [Required(ErrorMessage = "O campo 'Duracao' é obrigatório")]
        public int Duracao { get; set; }
    }
}
