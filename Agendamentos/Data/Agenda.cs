using Agendamentos.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Agendamentos.Classes
{
	[DataContract]
	public partial class Agenda
	{
        [DataMember]
        public int Id { get; set; }
		[DataMember]
		public DateTime Data { get; set; }
		[DataMember]
		public DateTime Hora { get; set; }
		[DataMember]
		public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
		[DataMember]
		public int ConvidadoId { get; set; }
        public virtual Convidado Convidado { get; set; }
		[DataMember]
		public int ServicoId { get; set; }
        public virtual Servico Servico { get; set; }

	}

}

