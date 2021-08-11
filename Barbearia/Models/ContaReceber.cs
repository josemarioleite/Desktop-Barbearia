using System;

namespace Barbersoft.Models
{
    public class ContaReceber
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataLancamento { get; set; }
        public DateTime DataVencimento { get; set; }
        public int ClienteId { get; set; }
        public int SituacaoId { get; set; }
        public int OrigemId { get; set; }
        public decimal Valor { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.Now;
        public int CriadoPor { get; set; }
        public DateTime? AlteradoEm { get; set; }
        public int? AlteradoPor { get; set; }
        public DateTime? DeletadoEm { get; set; }
        public int? DeletadoPor { get; set; }
    }
}
