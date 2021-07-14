using Barbearia.Database;
using Barbearia.Models;
using Barbearia.Views;
using System.Windows.Forms;

namespace Barbearia
{
    public partial class Login : Form
    {
        private readonly Databases database;
        public Login()
        {
            InitializeComponent();
            database = new Databases();
            VerificaConexao();
        }

        public bool VerificaConexao()
        {
            bool conectado = database.ExisteConexao();
            databaseDisabled.Visible = false;
            databaseEnabled.Visible = false;

            if (conectado)
            {
                databaseEnabled.Visible = true;
                return true;
            } else
            {
                databaseDisabled.Visible = true;
                return false;
            }
        }

        private void BtnSair(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void BtnEntrar(object sender, System.EventArgs e)
        {
            
            bool bancoConectado = this.VerificaConexao();
            if (bancoConectado)
            {
                bool logado = database.Autenticacao(txtLogin.Text, txtSenha.Text);
                if (logado)
                {
                    this.Hide();
                    var telaInicial = new TelaInicial();
                    telaInicial.Closed += (s, args) => this.Close();
                    telaInicial.Show();
                }
            } else
            {
                MessageBox.Show("Banco de Dados não conectado, por favor, tente mais tarde...");
            }
        }
    }
}
