using Agendamentos.Data;
namespace Agendamentos.Dtos;
public class DtoAgenda
{
        public DateTime Data { get; set; }
        public DateTime Hora { get; set; }
        public int UsuarioId { get; set; }
        public int ConvidadoId { get; set; }
        public int ServicoId { get; set; }

    }
