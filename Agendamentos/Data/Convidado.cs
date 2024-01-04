using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Agendamentos.Models;

public class Convidado
{
    [DataMember]
    public int Id { get; set; }
    [DataMember]
    public string Nome { get; set; }
    [DataMember]
    public string? Email { get; set; }
    [DataMember]
    public string? Telefone { get; set; }
}
