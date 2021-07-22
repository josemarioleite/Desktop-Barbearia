using System;
using System.Collections.Generic;

#nullable disable

namespace Barbersoft.Models
{
    public partial class Servico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public string Ativo { get; set; }
        public int CriadoPor { get; set; }
        public DateTime CriadoEm { get; set; }
        public int? AtualizadoPor { get; set; }
        public DateTime? AtualizadoEm { get; set; }
        public int? DeletadoPor { get; set; }
        public DateTime? DeletadoEm { get; set; }
    }
}
