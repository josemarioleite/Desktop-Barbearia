using Barbearia.Database;
using Barbearia.Log;
using Barbearia.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Barbersoft.Views.FormCrud
{
    public partial class FormEntradaProduto : Form
    {
        private readonly BarbersoftContext database;
        private readonly bool modoInclusao;
        public FormEntradaProduto(bool inclusao)
        {
            InitializeComponent();

            database = new();
            modoInclusao = inclusao;
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
            dtDataCompra.MaxDate = DateTime.Now;
            DadosComboBox();
        }
        private void BtnSalvar(object sender, EventArgs e)
        {
            BarbersoftContext database = new();
            Logging log = new();
            Barbearia.Models.EntradaProduto entradaProduto = new()
            {
                Id_Produto = (int)cbProduto.SelectedValue,
                Quantidade = Decimal.Parse(txtQuantidade.Text),
                Data = dtDataCompra.Value
            };

            if (modoInclusao == true)
            {
                entradaProduto.CriadoPor = Usuario.UsuarioAtivo.Id;
                entradaProduto.CriadoEm = DateTime.Now;
                entradaProduto.Ativo = "S";
                try
                {
                    if (entradaProduto.Quantidade > 0)
                    {
                        database.EntradaProduto.Add(entradaProduto);
                        database.SaveChanges();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("o Campo Quantidade está incorreto");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível fazer a inclusão, tente novamente mais tarde");
                    log.Log(ex);
                }
            }
        }
        private void EntradaProdutoKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                    (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
