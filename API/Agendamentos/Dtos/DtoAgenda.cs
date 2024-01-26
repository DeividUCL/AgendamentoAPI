using Agendamentos.Contexts;
using Agendamentos.Data;
namespace Agendamentos.Dtos;
public class DtoAgenda
{
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public DateTime Hora { get; set; }
    public int UsuarioId { get; set; }
    public int ConvidadoId { get; set; }
    public int ServicoId { get; set; }

    public Agenda ToModel(AgendamentoContext model)
    {
        var agenda = model.Agenda.Find(this.Id);

        if (agenda == null)
            agenda = new Agenda();

        agenda.Id = this.Id;
        agenda.Data = this.Data;
        agenda.Hora = this.Hora;
        agenda.UsuarioId = this.UsuarioId;
        agenda.ConvidadoId = this.ConvidadoId;
        agenda.ServicoId = this.ServicoId;

        return agenda;
    }

    public static DtoAgenda FromModel(Agenda agenda)
    {
        return new DtoAgenda
        {
            Id = agenda.Id,
            Data = agenda.Data,
            Hora = agenda.Hora,
            UsuarioId = agenda.UsuarioId,
            ConvidadoId = agenda.ConvidadoId,
            ServicoId = agenda.ServicoId
        };
    }
}
