using Agendamentos.Contexts;
using Agendamentos.Data;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Agendamentos.Dtos
{
	public class DtoServico
	{
		
		public int Id { get; set; }
		[Required(ErrorMessage = "O Campo 'Nome' é obrigatório!")]
		public string Nome { get; set; }
		public string Descricao { get; set; }
		[Required(ErrorMessage = "O Campo 'Preco' é obrigatório!")]
		public decimal Preco { get; set; }
		[Required(ErrorMessage = "O Campo 'Duracao' é obrigatório!")]
		public int Duracao { get; set; }

		public Servico ToModel(AgendamentoContext db)
		{
			var servico = db.Servico.Find(this.Id);

			if (servico == null)
				servico = new Servico();

			servico.Id = this.Id;
			servico.Nome = this.Nome;
			servico.Descricao = this.Descricao;
			servico.Preco = this.Preco;
			servico.Duracao = this.Duracao;

			return servico;
			
		}

		public static DtoServico FromModel(Servico model)
		{
			return new DtoServico
			{
				Id = model.Id,
				Nome = model.Nome,
				Descricao = model.Descricao,
				Preco = model.Preco,
				Duracao = model.Duracao
			};
		}
	}
}
