using System.Runtime.Serialization;

namespace Agendamentos.Dtos
{
	public class DtoServico
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string? Descricao { get; set; }
		public decimal Preco { get; set; }
		public int Duracao { get; set; }
	}
}
