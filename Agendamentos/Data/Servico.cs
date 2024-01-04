﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Runtime.Serialization.DataContracts;

namespace Agendamentos.Classes
{
	public class Servico
	{
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nome { get; set; }
		[DataMember]
		public string? Descricao { get; set; }
		[DataMember]
		public decimal Preco { get; set; }
		[DataMember]
		public int Duracao { get; set; }
    }
}
