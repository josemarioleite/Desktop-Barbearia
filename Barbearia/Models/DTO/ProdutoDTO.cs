﻿namespace Barbearia.Models.DTO
{
    public class ProdutoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public string ComissaoPorcentagem { get; set; }
        public decimal ValorComissaoPorcentagem { get; set; }
    }
}
