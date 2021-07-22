using System;

namespace Barbersoft.Models.DTO
{
    public class AtendimentoDTO
    {
        public byte[] imageSituacao { get; set; }
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Cliente { get; set; }
        public string Profissional { get; set; }
        public string Situacao { get; set; }
        public string Total { get; set; }
    }
}
