using Agendamentos.Classes;
using Agendamentos.Models;

namespace Agendamentos.Dtos;
public class DtoAgenda
{
        public DateTime Data { get; set; }
        public DateTime Hora { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int ConvidadoId { get; set; }
        public Convidado Convidado { get; set; }
        public int ServicoId { get; set; }
        public Servico Servico { get; set; }

    }
