using System;
using System.Collections.Generic;

#nullable disable

namespace Barbersoft.Models
{
    public partial class EstoqueProduto
    {
        public int Id { get; set; }
        public int IdProduto { get; set; }
        public decimal Quantidade { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
