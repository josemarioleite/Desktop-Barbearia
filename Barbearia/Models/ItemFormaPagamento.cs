using System;

namespace Barbersoft.Models
{
    public partial class ItemFormaPagamento
    {
        public int Id { get; set; }
        public int AtendimentoId { get; set; }
        public int FormaPagamentoId { get; set; }
        public decimal Valor { get; set; }
        public DateTime CriadoEm { get; set; }
        public int? CriadoPor { get; set; }
        public DateTime? AtualizadoEm { get; set; }
        public int? AtualizadoPor { get; set; }
        public DateTime? DeletadoEm { get; set; }
        public int? DeletadoPor { get; set; }
    }
}
