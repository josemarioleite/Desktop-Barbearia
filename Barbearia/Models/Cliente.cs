using System;
using System.Collections.Generic;

#nullable disable

namespace Barbearia.Models
{
    public partial class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Celular { get; set; }
        public string Ativo { get; set; }
        public DateTime? CriadoEm { get; set; }
        public int? CriadoPor { get; set; }
        public DateTime? AlteradoEm { get; set; }
        public int? AlteradoPor { get; set; }
        public DateTime? DeletadoEm { get; set; }
        public int? DeletadoPor { get; set; }
    }
}
