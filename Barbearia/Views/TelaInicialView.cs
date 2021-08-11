using Barbersoft.Gestor;
using Barbersoft.Models;
using Barbersoft.PdfViewer.AtendimentoViewer;
using Barbersoft.Utils;
using Barbersoft.Views;
using System;
using System.Linq;
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
            timer1.Start();
            this.KeyPreview = true;
            lblNomeUsuario.Text = Usuario.UsuarioAtivo.Nome;
            lblVersao.Text = Sistema.Versao;
        }
        private void BtnRelatorioAtendimento(object sender, EventArgs e)
        {
            new AtendimentoViewerForm().ShowDialog();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            DropDownButton(panelDropDown, timer1);
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            DropDownButton(panelDropDownCadastro, timer2);
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            DropDownButton(panelDropDownFinanceiro, timer3);
        }
        private void BtnCadastro(object sender, EventArgs e)
        {
            timer2.Start();
            DropDownButton(panelDropDownCadastro, timer2);
        }
        private void BtnFinanceiro(object sender, EventArgs e)
        {
            timer3.Start();
            DropDownButton(panelDropDownFinanceiro, timer3);
        }
        private void BtnAtendimentoDropDown(object sender, EventArgs e)
        {
            timer1.Start();
            DropDownButton(panelDropDown, timer1);
        }
        private void DropDownButton(Panel panelDropDown, Timer timer)
        {
            if (isCollapsed)
            {
                panelDropDown.Height += 10;
                if (panelDropDown.Size == panelDropDown.MaximumSize)
                {
                    timer.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                panelDropDown.Height -= 10;
                if (panelDropDown.Size == panelDropDown.MinimumSize)
                {
                    timer.Stop();
                    isCollapsed = true;
                }
            }
        }
        private void BtnContaPagar(object sender, EventArgs e)
        {
            new ContaPagarView().ShowDialog();
        }
        private void BtnFornecedor(object sender, EventArgs e)
        {
            new FornecedorView().ShowDialog();
        }
        private void BtnContaReceber(object sender, EventArgs e)
        {
            new ContaReceberView().ShowDialog();
        }
    }
}
