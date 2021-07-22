using Barbearia.Database;
using System;
using System.Windows.Forms;

namespace Barbersoft.Gestor
{
    public partial class LoginGestor : Form
    {
        private readonly Databases database;
        public LoginGestor()
        {
            InitializeComponent();

            database = new();
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
            }
            else
            {
                databaseDisabled.Visible = true;
                return false;
            }
        }
        private void BtnSair(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void BtnEntrar(object sender, EventArgs e)
        {
            bool bancoConectado = this.VerificaConexao();
            if (bancoConectado)
            {
                bool logado = database.AutenticacaoGestor(txtLogin.Text.ToLower(), txtSenha.Text);
                if (logado)
                {
                    this.Close();
                    InicioGestor inicio = new();
                    inicio.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Banco de Dados não conectado, por favor, tente mais tarde...");
            }
        }
    }
}
