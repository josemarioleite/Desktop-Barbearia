using Barbearia.Database;
using Barbearia.Log;
using Barbersoft.Enum;
using Barbersoft.Models;
using Barbersoft.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Barbersoft.Views.FormCrud
{
    public partial class Atendimento_FormaPagamentoForm : Form
    {
        private readonly ObterDadosGenericos dados;
        private readonly Atendimento _atendimento;
        private readonly List<PagamentoItem> _pagamentoItem;
        private decimal valorTotalGrid;
        private decimal valorTotalAtendimentoGrade;
        public Atendimento_FormaPagamentoForm(int id)
        {
            InitializeComponent();

            dados = new();
            _pagamentoItem = new();
            _atendimento = dados.ObterDados<Atendimento>().FirstOrDefault(a => a.Id == id);
        }
        private void CarregaDados()
        {
            txtValor.Text = "0";

            valorTotalAtendimentoGrade = dados.ObterDados<ItemAtendimento>().Where(i => i.AtendimentoId == _atendimento.Id).GroupBy(i => i.ValorTotal).Sum(i => i.Key);
            lblTotalAtendimento.Text = valorTotalAtendimentoGrade.ToString("F2");

            txtAtendimento.Text = _atendimento.Id.ToString("D4");
            cbFormaPagamento.DataSource = dados.ObterDados<FormaPagamento>();
            cbFormaPagamento.DisplayMember = "Descricao";
            cbFormaPagamento.ValueMember = "Id";
        }
        public void ConfiguraDataGrid()
        {
            dgFormaPagamento.ColumnCount = 5;
            dgFormaPagamento.Columns[0].Name = "descricao";
            dgFormaPagamento.Columns[1].Name = "titulo";
            dgFormaPagamento.Columns[2].Name = "valor";
            dgFormaPagamento.Columns[3].Name = "atendimentoId";
            dgFormaPagamento.Columns[4].Name = "formaPagamentoId";

            dgFormaPagamento.Columns[0].Width = 450;
            dgFormaPagamento.Columns[1].Width = 75;
            dgFormaPagamento.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgFormaPagamento.Columns[3].Visible = false;
            dgFormaPagamento.Columns[4].Visible = false;
            dgFormaPagamento.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

            dgFormaPagamento.Columns[0].HeaderText = "Descrição";
            dgFormaPagamento.Columns[1].HeaderText = "Título";
            dgFormaPagamento.Columns[2].HeaderText = "Valor";

            dgFormaPagamento.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgFormaPagamento.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgFormaPagamento.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243);
            dgFormaPagamento.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgFormaPagamento.EnableHeadersVisualStyles = false;
        }
        private void BtnSair(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnSalvar(object sender, EventArgs e)
        {
            if (valorTotalGrid.Equals(valorTotalAtendimentoGrade))
            {
                if (_pagamentoItem.Count > 0)
                {
                    foreach (var item in _pagamentoItem)
                    {
                        ItemFormaPagamento itemFormaPagamento = new()
                        {
                            AtendimentoId = _atendimento.Id,
                            FormaPagamentoId = item.FormaPagamentoId,
                            Valor = item.Valor,
                            CriadoEm = DateTime.Now,
                            CriadoPor = Usuario.UsuarioAtivo.Id
                        };
                        dados.AdicionaDados(itemFormaPagamento);
                    }
                    Atendimento atendimento = new()
                    {
                        Id = _atendimento.Id,
                        ClienteId = _atendimento.ClienteId,
                        ProfissionalId = _atendimento.ProfissionalId,
                        CriadoEm = _atendimento.CriadoEm,
                        CriadoPor = _atendimento.CriadoPor,
                        Ativo = _atendimento.Ativo,
                        SituacaoId = (int)SituacaoEnum.Fechado,
                        AlteradoEm = DateTime.Now,
                        AlteradoPor = Usuario.UsuarioAtivo.Id
                    };
                    dados.AtualizaDados(atendimento);
                    MessageBox.Show("Atendimento Fechado com sucesso!", "Aviso");
                    this.Close();
                } else
                {
                    MessageBox.Show("Para salvar é necessário ter pelo menos um item alocado");
                }                
            } else
            {
                MessageBox.Show("O Valor Total dos Itens Não pode ser MENOR ou MAIOR que o Total do Atendimento", "Atenção");
            }
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
        private void Finalizar_OnLoad(object sender, EventArgs e)
        {
            CarregaDados();
            ConfiguraDataGrid();
        }
        private void Produto_Changed(object sender, EventArgs e)
        {
            if (cbFormaPagamento.SelectedItem != null)
            {
                FormaPagamento formaPagamento = (FormaPagamento)cbFormaPagamento.SelectedItem;
                txtTitulo.Text = formaPagamento.Titulo.ToUpper().Trim();
            }
        }
        private void BtnAdicionar(object sender, EventArgs e)
        {
            decimal valor = decimal.Parse(txtValor.Text);
            if (valor <= 0)
            {
                MessageBox.Show("Valor Não pode estar zerado", "Atenção");
            }
            else if (cbFormaPagamento.SelectedItem == null)
            {
                MessageBox.Show("Escolha uma forma de pagamento", "Atenção");
            }
            else if (valor > valorTotalAtendimentoGrade)
            {
                MessageBox.Show("O Valor da forma de pagamento não pode ser maior que o Total do Atendimento", "Atenção");
            }
            else if ((valorTotalGrid+valor) > valorTotalAtendimentoGrade)
            {
                MessageBox.Show("O Valor Total das formas de pagamento não pode ser maior que o Total do Atendimento", "Atenção");
            }
            else
            {
                FormaPagamento formaPagamento = (FormaPagamento)cbFormaPagamento.SelectedItem;
                if (_pagamentoItem.Count > 0)
                {
                    foreach (var dados in _pagamentoItem)
                    {
                        if (dados.Descricao.Equals(formaPagamento.Descricao))
                        {
                            MessageBox.Show("Esta forma de pagamento já foi adicionado", "Atenção");
                            return;
                        }
                    }
                }
                PagamentoItem item = new()
                {
                    AtendimentoId = _atendimento.Id,
                    Descricao = formaPagamento.Descricao.ToUpper().Trim(),
                    FormaPagamentoId = formaPagamento.Id,
                    Titulo = formaPagamento.Titulo,
                    Valor = decimal.Parse(txtValor.Text)
                };
                dgFormaPagamento.Rows.Add
                (
                    item.Descricao,
                    item.Titulo,
                    decimal.Round(item.Valor, 2, MidpointRounding.AwayFromZero)
                );
                valorTotalGrid += decimal.Round(item.Valor, 2, MidpointRounding.AwayFromZero);
                lblTotal.Text = "Total: R$ " + valorTotalGrid.ToString();
                _pagamentoItem.Add(item);
                CarregaDados();
            }
        }
        private void DataGridKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                if (dgFormaPagamento.Rows.Count > 0)
                {
                    Logging log = new();
                    try
                    {
                        if (dgFormaPagamento.Rows[0].Cells[0].Value != null)
                        {
                            int id = dgFormaPagamento.CurrentRow.Index;
                            dgFormaPagamento.Rows.RemoveAt(id);
                        }
                        else
                        {
                            MessageBox.Show("Não há nenhum item", "Aviso");
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Log(ex);
                        MessageBox.Show("Não foi possível deletar linha", "Atenção");
                    }
                }
            }
        }
    }
    public class PagamentoItem
    {
        public string Descricao { get; set; }
        public string Titulo { get; set; }
        public decimal Valor { get; set; }
        public int AtendimentoId { get; set; }
        public int FormaPagamentoId { get; set; }
    }
}
