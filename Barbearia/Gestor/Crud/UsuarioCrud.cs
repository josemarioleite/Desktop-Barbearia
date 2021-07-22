using Barbearia.Database;
using Barbearia.Log;
using Barbersoft.Models;
using System;
using System.Windows.Forms;

namespace Barbersoft.Gestor.Crud
{
    public partial class UsuarioCrud : Form
    {
        public UsuarioCrud()
        {
            InitializeComponent();
        }
        private void BtnSair(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnSalvar(object sender, EventArgs e)
        {   
            if (!string.IsNullOrEmpty(txtNome.Text) && !string.IsNullOrEmpty(txtLogin.Text))
            {
                BarbersoftContext database = new();
                Logging log = new();
                string ativo = "";
                string primeiroAcesso = "";
                string admin = "";
                string superUser = "";

                if (rdAcessoSim.Checked == true)
                {
                    primeiroAcesso = "S";
                }
                else if (rdAcessoNao.Checked == true)
                {
                    primeiroAcesso = "N";
                }

                if (rdAdminsim.Checked == true)
                {
                    admin = "S";
                }
                else if (rdAdminNao.Checked == true)
                {
                    admin = "N";
                }

                if (rdAtivoSim.Checked == true)
                {
                    ativo = "S";
                }
                else if (rdAtivoNao.Checked == true)
                {
                    ativo = "N";
                }

                if (rdSuperSim.Checked == true)
                {
                    superUser = "S";
                }
                else if (rdSuperNao.Checked == true)
                {
                    superUser = "N";
                }

                Usuario usuario = new()
                {
                    Nome = txtNome.Text,
                    Login = txtLogin.Text.ToLower(),
                    Senha = txtSenha.Text,
                    Ativo = ativo,
                    PrimeiroAcesso = primeiroAcesso,
                    Administrador = admin,
                    SuperUser = superUser
                };

                try
                {
                    database.Usuario.Add(usuario);
                    database.SaveChanges();
                    this.Close();
                } catch (Exception ex)
                {
                    log.Log(ex);
                    MessageBox.Show("Não foi possível adicionar um novo usuário");
                    this.Close();
                }
            } else
            {
                MessageBox.Show("Preencha todos os campos obrigatórios");
            }
        }
    }
}
