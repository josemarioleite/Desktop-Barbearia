using Barbearia.Models;
using System;

namespace Barbersoft.Models.DTO
{
    public class EntradaProdutoDTO
    {
        public int Id { get; set; }
        public int IdProduto { get; set; }
        public string Produto { get; set; }
        public decimal Quantidade { get; set; }
        public DateTime Data { get; set; }
    }
}
