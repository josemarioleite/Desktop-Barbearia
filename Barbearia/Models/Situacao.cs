using System;
using System.Collections.Generic;

#nullable disable

namespace Barbersoft.Models
{
    public partial class Situacao
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime CriadoEm { get; set; }
        public int? CriadoPor { get; set; }
        public DateTime? AlteradoEm { get; set; }
        public int? AlteradoPor { get; set; }
        public DateTime? DeletadoEm { get; set; }
        public int? DeletadoPor { get; set; }
    }
}
