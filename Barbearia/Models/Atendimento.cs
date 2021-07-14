using System;
using System.Collections.Generic;

#nullable disable

namespace Barbearia.Models
{
    public partial class Atendimento
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int ProfissionalId { get; set; }
        public int SituacaoId { get; set; }
        public string Ativo { get; set; }
        public DateTime CriadoEm { get; set; }
        public int? CriadoPor { get; set; }
        public DateTime? AlteradoEm { get; set; }
        public int? AlteradoPor { get; set; }
        public DateTime? DeletadoEm { get; set; }
        public int? DeletadoPor { get; set; }
    }
}
