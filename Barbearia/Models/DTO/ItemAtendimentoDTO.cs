namespace Barbersoft.Models.DTO
{
    public class ItemAtendimentoDTO
    {
        public string Id { get; set; }
        public string TipoItem { get; set; }
        public int ProdutoServicoId { get; set; }
        public string Descricao { get; set; }
        public string Quantidade { get; set; }
        public string ValorUnitario { get; set; }
        public string ValorTotal { get; set; }
        public int IdInteiro { get; set; }
    }
}
