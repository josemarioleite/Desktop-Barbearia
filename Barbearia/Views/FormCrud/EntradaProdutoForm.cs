using Barbearia.Database;
using Barbearia.Log;
using Barbearia.Views;
using Barbersoft.Models;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Barbersoft.Views.FormCrud
{
    public partial class EntradaProdutoForm : Form
    {
        private readonly BarbersoftContext database;
        private readonly bool modoInclusao;
        public EntradaProdutoForm(bool inclusao)
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
            this.KeyPreview = true;
            txtQuantidade.Text = "0,00";
            dtDataCompra.MinDate = new DateTime(2021, 1, 1);
            dtDataCompra.MaxDate = DateTime.Today;
            dtDataCompra.Value = DateTime.Today;
            DadosComboBox();
        }
        private void BtnSalvar(object sender, EventArgs e)
        {
            BarbersoftContext database = new();
            Logging log = new();
            EntradaProduto entradaProduto = new()
            {
                IdProduto = (int)cbProduto.SelectedValue,
                Quantidade = decimal.Parse(txtQuantidade.Text),
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
            if (char.IsDigit(e.KeyChar) || e.KeyChar.Equals((char)Keys.Back))
            {
                TextBox txt = (TextBox)sender;
                string w = Regex.Replace(txt.Text, "[^0-9]", string.Empty);
                if (w == string.Empty) w = "00";
                if (e.KeyChar.Equals((char)Keys.Back))
                {
                    w = w.Substring(0, w.Length - 1);
                }
                else
                {
                    w += e.KeyChar;
                }
                txt.Text = string.Format("{0:#,##0.00}", Double.Parse(w) / 100);
                txt.Select(txt.Text.Length, 0);
            }
            e.Handled = true;
        }
        private void TxtKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                TextBox t = (TextBox)sender;
                t.Text = string.Format("{0:#.##0.00}", 0d);
                t.Select(t.Text.Length, 0);
                e.Handled = true;
            }
        }
        private void EntradaProduto_KeyProduto(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.Shift == true && e.KeyCode == Keys.P)
            {
                ProdutoView produto = new();
                produto.ShowDialog();
            }
            DadosComboBox();
        }
    }
}
