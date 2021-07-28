using Barbersoft.Gestor;
using Barbersoft.Models;
using Barbersoft.PdfViewer;
using Barbersoft.Properties;
using Barbersoft.Views;
using System;
using System.Windows.Forms;

namespace Barbearia.Views
{
    public partial class TelaInicialView : Form
    {
        private bool isCollapsed;
        public TelaInicialView()
        {
            InitializeComponent();
        }
        private void BtnProduto(object sender, EventArgs e)
        {
            var produto = new ProdutoView();
            produto.ShowDialog();
        }
        private void BtnSair(object sender, EventArgs e)
        {
            var mensagem = MessageBox.Show("Deseja mesmo sair ?", "Atenção", MessageBoxButtons.YesNo);

            if (mensagem == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void BtnProfissional(object sender, EventArgs e)
        {
            ProfissionalView profisional = new();
            profisional.ShowDialog();
        }
        private void BtnServico(object sender, EventArgs e)
        {
            ServicoView servico = new();
            servico.ShowDialog();
        }
        private void BtnEntradaProduto(object sender, EventArgs e)
        {
            EntradaProdutoView entradaProduto = new();
            entradaProduto.ShowDialog();
        }
        private void BtnCliente(object sender, EventArgs e)
        {
            ClienteView cliente = new();
            cliente.ShowDialog();
        }
        private void BtnAtendimento(object sender, EventArgs e)
        {
            AtendimentoView atendimento = new();
            atendimento.ShowDialog();
        }
        private void TelaInicial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.Shift == true && e.KeyCode == Keys.E)
            {
                EstoqueProdutoView estoque = new();
                estoque.ShowDialog();
            }
            if (e.Control == true && e.Shift == true && e.KeyCode == Keys.F2)
            {
                LoginGestor login = new();
                login.ShowDialog();
            }
        }
        private void OnLoad(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            lblNomeUsuario.Text = Usuario.UsuarioAtivo.Nome;
            lblVersao.Text = Sistema.Versao;
        }
        private void BtnArquivo(object sender, EventArgs e)
        {
            PDFViewerForm pdf = new();
            pdf.ShowDialog();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                panelDropDown.Height += 10;
                if (panelDropDown.Size == panelDropDown.MaximumSize)
                {
                    timer1.Stop();
                    isCollapsed = false;
                }
            } else
            {
                panelDropDown.Height -= 10;
                if (panelDropDown.Size == panelDropDown.MinimumSize)
                {
                    timer1.Stop();
                    isCollapsed = true;
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
