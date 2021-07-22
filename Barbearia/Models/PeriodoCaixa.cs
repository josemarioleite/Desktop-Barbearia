using System;
using System.Collections.Generic;

#nullable disable

namespace Barbersoft.Models
{
    public partial class PeriodoCaixa
    {
        public int Id { get; set; }
        public int CaixaId { get; set; }
        public string Status { get; set; }
        public DateTime DataAbertura { get; set; }
        public int? UsuarioAberturaId { get; set; }
        public DateTime? DataFechamento { get; set; }
        public int? UsuarioFechamentoId { get; set; }
        public decimal? ValorTroco { get; set; }
        public decimal? ValorSangria { get; set; }
        public decimal? ValorSaldo { get; set; }
        public decimal? ValorPeriodo { get; set; }
        public string Observacao { get; set; }
        public DateTime CriadoEm { get; set; }
        public int CriadoPor { get; set; }
        public DateTime? AtualizadoEm { get; set; }
        public int? AtualizadoPor { get; set; }
        public DateTime? DeletadoEm { get; set; }
        public int? DeletadoPor { get; set; }
    }
}
