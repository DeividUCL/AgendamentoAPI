using Agendamentos.Classes;
using Microsoft.AspNetCore.Mvc;

namespace Agendamentos.Controllers
{
	[Controller]
	[Route("[controller]")]
	public class ServicoController : ControllerBase
	{
		public static List<Servico> Servicos = new List<Servico>();

		[HttpPost]
		public void CadastrarServico([FromBody] Servico servico) {
			Servicos.Add(servico);
            Console.WriteLine(servico.Nome);
            Console.WriteLine(servico.Descricao);
            Console.WriteLine(servico.Duracao);
            Console.WriteLine(servico.Preco);
        }
	}
}
