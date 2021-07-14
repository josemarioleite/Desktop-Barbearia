using Barbearia.Database;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Barbersoft.Views.FormCrud
{
    public partial class FormEntradaProduto : Form
    {
        private readonly BarbersoftContext database;
        public FormEntradaProduto()
        {
            InitializeComponent();

            database = new();
        }

        private void DadosComboBox()
        {
            cbProduto.DataSource = database.Produto.ToList();
            cbProduto.ValueMember = "Id";
            cbProduto.DisplayMember = "Nome";
        }

        private void BtnSair(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            DadosComboBox();
        }

        private void BtnSalvar(object sender, EventArgs e)
        {
            var quantidade = int.Parse(txtQuantidade.Text);
            var produto = (int)cbProduto.SelectedValue;
            var data = (DateTime)dtDataCompra.Value;

            var teste = 0;
        }
    }
}
