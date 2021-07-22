using System;
using System.Collections.Generic;

#nullable disable

namespace Barbersoft.Models
{
    public partial class Produto
    {
        public Produto()
        {
            EntradaProdutos = new HashSet<EntradaProduto>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public string ComissaoPorcentagem { get; set; }
        public decimal ValorComissaoPorcentagem { get; set; }
        public string Ativo { get; set; }
        public DateTime CriadoEm { get; set; }
        public int CriadoPor { get; set; }
        public DateTime? AtualizadoEm { get; set; }
        public int? AtualizadoPor { get; set; }
        public DateTime? DeletadoEm { get; set; }
        public int? DeletadoPor { get; set; }

        public virtual ICollection<EntradaProduto> EntradaProdutos { get; set; }
    }
}
