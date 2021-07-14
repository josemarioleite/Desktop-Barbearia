namespace Barbearia.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Ativo { get; set; }
        public string PrimeiroAcesso { get; set; }
        public string Administrador { get; set; }
        public string SuperUser { get; set; }

        public static Usuario UsuarioAtivo;
    }
}
