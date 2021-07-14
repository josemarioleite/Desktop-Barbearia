using System;

namespace Barbersoft.Models.DTO
{
    public class EstoqueProdutoDTO
    {
        public int Id { get; set; }
        public int IdProduto { get; set; }
        public string Produto { get; set; }
        public decimal Quantidade { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
