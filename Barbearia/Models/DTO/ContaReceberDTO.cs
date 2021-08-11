namespace Barbersoft.Models.DTO
{
    public class ContaReceberDTO
    {
        public byte[] imageSituacao { get; set; }
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string DataLancamento { get; set; }
        public string DataVencimento { get; set; }
        public string Cliente { get; set; }
        public string Situacao { get; set; }
        public decimal Valor { get; set; }
    }
}
