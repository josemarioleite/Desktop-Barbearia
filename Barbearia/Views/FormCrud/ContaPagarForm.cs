using Barbersoft.Enum;
using Barbersoft.Models;
using Barbersoft.Utils;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Barbersoft.Views.FormCrud
{
    public partial class ContaPagarForm : Form
    {
        private readonly ObterDadosGenericos dados;
        private readonly bool _modoInclusao;
        private Fornecedor _fornecedor;
        public ContaPagarForm()
        {
            InitializeComponent();

            dados = new();
        }
        public ContaPagarForm(bool modoInclusao)
        {
            InitializeComponent();

            dados = new();
            _modoInclusao = modoInclusao;
        }
        private void RecebeDadosBanco()
        {
            if (_modoInclusao)
            {
                Situacao situacao = dados.ObterDados<Situacao>().FirstOrDefault(s => s.Id == (int)SituacaoEnum.Aberto);
                txtSituacao.Visible = true;
                txtSituacao.Enabled = false;
                txtSituacao.Text = situacao.Descricao;
            } else
            {
                cbSituacao.Visible = true;
                cbSituacao.DataSource = dados.ObterDados<Situacao>().OrderBy(s => s.Descricao).ToList();
                cbSituacao.DisplayMember = "Descricao";
                cbSituacao.ValueMember = "Id";
            }
        }
        private void BtnSair(object sender, EventArgs e)
        {
            this.Close();
        }
        private void TxtKeyPress(object sender, KeyPressEventArgs e)
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
        private void AbrirFornecedor(object sender, EventArgs e)
        {
            FornecedorView fornecedor = new(true);
            fornecedor.ShowDialog();            
            if (fornecedor.fornecedor != null)
            {
                _fornecedor = fornecedor.fornecedor;
                cbFornecedor.Text = _fornecedor.Id.ToString("D4");
                tbFornecedorNome.Text = _fornecedor.Nome;
            }
        }
        private void BtnSalvar(object sender, EventArgs e)
        {
            if (_modoInclusao)
            {
                string descricao = string.IsNullOrEmpty(txtDescricao.Text) ? "Sem Descrição" : txtDescricao.Text;
                ContaPagar contaPagar = new();
                contaPagar.CriadoEm = DateTime.Now;
                contaPagar.CriadoPor = Usuario.UsuarioAtivo.Id;
                contaPagar.Valor = string.IsNullOrEmpty(txtValor.Text) ? 0 : decimal.Parse(txtValor.Text);
                contaPagar.OrigemId = (int)OrigemEnum.ContaPagar;
                contaPagar.SituacaoId = (int)SituacaoEnum.Aberto;
                contaPagar.FornecedorId = _fornecedor.Id;
                contaPagar.Descricao = descricao.ToUpper().Trim();
                contaPagar.DataVencimento = Convert.ToDateTime(dtVencimento.Value);
                contaPagar.DataLancamento = Convert.ToDateTime(dtLancamento.Value);

                try
                {
                    dados.AdicionaDados(contaPagar);
                    this.Close();
                } catch (Exception)
                {
                    MessageBox.Show("Não foi possível adicionar", "Atenção");
                }
            }
        }
        private void Load_ContaPagar(object sender, EventArgs e)
        {
            txtValor.Text = "0,00";
            dtLancamento.MinDate = new DateTime(2021, 1, 1);
            dtLancamento.MaxDate = DateTime.Now;
            dtVencimento.MinDate = new DateTime(2021, 1, 1);
            RecebeDadosBanco();
        }
    }
}
