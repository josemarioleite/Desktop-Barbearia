﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Barbersoft.Models
{
    public partial class EntradaProduto
    {
        public int Id { get; set; }
        public int IdProduto { get; set; }
        public decimal Quantidade { get; set; }
        public DateTime Data { get; set; }
        public string Ativo { get; set; }
        public DateTime CriadoEm { get; set; }
        public int CriadoPor { get; set; }
        public DateTime? AlteradoEm { get; set; }
        public int? AlteradoPor { get; set; }
        public DateTime? CanceladoEm { get; set; }
        public int? CanceladoPor { get; set; }

        public virtual Produto IdProdutoNavigation { get; set; }
    }
}
