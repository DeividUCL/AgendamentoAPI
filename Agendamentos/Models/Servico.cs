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
        [Required(ErrorMessage = "O campo 'Descricao' é obrigatório")]
        public string Descricao { get; set; }
        public decimal? Preco { get; set; }
        [Required(ErrorMessage = "O campo 'Duracao' é obrigatório")]
        public int Duracao { get; set; }
    }
}
