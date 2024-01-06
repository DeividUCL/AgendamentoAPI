using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Agendamentos.Data;

[DataContract]
public partial class Convidado
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
