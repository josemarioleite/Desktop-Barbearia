using System;

namespace Barbersoft.Models
{
    public class Recebimento
    {
        public int Id { get; set; }
        public int ContaReceberId { get; set; }
        public DateTime DataRecebimento { get; set; }
        public int SituacaoId { get; set; }
        public decimal Valor { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.Now;
        public int CriadoPor { get; set; } = Usuario.UsuarioAtivo.Id;
        public DateTime? AlteradoEm { get; set; }
        public int? AlteradoPor { get; set; }
        public DateTime? DeletadoEm { get; set; }
        public int? DeletadoPor { get; set; }
    }
}
