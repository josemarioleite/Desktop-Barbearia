using Barbersoft.Views;
using System;
using System.Windows.Forms;

namespace Barbearia.Views
{
    public partial class TelaInicial : Form
    {
        public TelaInicial()
        {
            InitializeComponent();
        }

        private void BtnProduto(object sender, EventArgs e)
        {
            var produto = new Produto();
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
            Profissional profisional = new();
            profisional.ShowDialog();
        }
        private void BtnServico(object sender, EventArgs e)
        {
            Servico servico = new();
            servico.ShowDialog();
        }
        private void BtnEntradaProduto(object sender, EventArgs e)
        {
            EntradaProduto entradaProduto = new();
            entradaProduto.ShowDialog();
        }
    }
}
