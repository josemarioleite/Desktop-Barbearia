namespace Barbersoft.Models.DTO
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Ativo { get; set; }
        public string PrimeiroAcesso { get; set; }
        public string Administrador { get; set; }
    }
}
