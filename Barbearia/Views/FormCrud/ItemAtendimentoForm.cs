using Barbearia.Database;
using Barbearia.Log;
using Barbersoft.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Barbersoft.Views.FormCrud
{
    public partial class ItemAtendimentoForm : Form
    {
        private readonly Atendimento _atendimento;
        private readonly BarbersoftContext _database;
        private readonly List<Item> _itens;
        public ItemAtendimentoForm(Atendimento atendimento)
        {
            InitializeComponent();

            _atendimento = atendimento;
            _database = new();
            _itens = new();
        }
        private void ObtemProduto()
        {
            cbProduto.DataSource = _database.Produto.ToList();
            cbProduto.DisplayMember = "Nome".ToUpper();
            cbProduto.ValueMember = "Id";
        }
        private void ObtemServico()
        {
            cbServico.DataSource = _database.Servico.ToList();
            cbServico.DisplayMember = "Nome".ToUpper();
            cbServico.ValueMember = "Id";
        }
        private void Item_Load(object sender, EventArgs e)
        {
            ConfiguraDataGrid();
            lblTitulo.Text = "Itens do Atendimento N°: " + _atendimento.Id.ToString("D4");
            ObtemProduto();
            ObtemServico();
        }
        private void BtnSair(object sender, EventArgs e)
        {
            this.Close();
        }
        public void ConfiguraDataGrid()
        {
            dgItemAtendimento.ColumnCount = 7;
            dgItemAtendimento.Columns[0].Name = "atendimentoId";
            dgItemAtendimento.Columns[1].Name = "tipo";
            dgItemAtendimento.Columns[2].Name = "tipoId";
            dgItemAtendimento.Columns[3].Name = "descricao";
            dgItemAtendimento.Columns[4].Name = "quantidade";
            dgItemAtendimento.Columns[5].Name = "valorUnitario";
            dgItemAtendimento.Columns[6].Name = "valorTotal";

            dgItemAtendimento.Columns[0].Width = 75;
            dgItemAtendimento.Columns[1].Width = 95;
            dgItemAtendimento.Columns[2].Width = 50;
            dgItemAtendimento.Columns[3].Width = 287;
            dgItemAtendimento.Columns[4].Width = 85;
            dgItemAtendimento.Columns[5].Width = 85;
            dgItemAtendimento.Columns[6].Width = 85;
            dgItemAtendimento.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

            dgItemAtendimento.Columns[0].HeaderText = "N° Atend.:";
            dgItemAtendimento.Columns[1].HeaderText = "Tipo";
            dgItemAtendimento.Columns[2].HeaderText = "ID Tipo";
            dgItemAtendimento.Columns[3].HeaderText = "Descrição";
            dgItemAtendimento.Columns[4].HeaderText = "Quantidade";
            dgItemAtendimento.Columns[5].HeaderText = "Valor Unitário";
            dgItemAtendimento.Columns[6].HeaderText = "Valor Total";

            dgItemAtendimento.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgItemAtendimento.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgItemAtendimento.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgItemAtendimento.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgItemAtendimento.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgItemAtendimento.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgItemAtendimento.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgItemAtendimento.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgItemAtendimento.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgItemAtendimento.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgItemAtendimento.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243);
            dgItemAtendimento.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgItemAtendimento.EnableHeadersVisualStyles = false;
        }
        private void BtnServico(object sender, EventArgs e)
        {
            decimal quantidade = decimal.Parse(txtQuantidadeServico.Text);
            decimal valorServico = decimal.Parse(txtValorServico.Text);
            if (string.IsNullOrEmpty(txtQuantidadeServico.Text))
            {
                MessageBox.Show("Para inserir um item é necessário informar a quantidade correta", "Atenção");
            }
            else if (quantidade < 1)
            {
                MessageBox.Show("Para inserir um item a quantidade não pode ser zero", "Atenção");
            }
            else if (valorServico < 1)
            {
                MessageBox.Show("Para inserir um item o valor não pode ser zero", "Atenção");
            }
            else
            {
                Servico servico = (Servico)cbServico.SelectedItem;
                if (_itens.Count > 0)
                {
                    foreach (var dados in _itens)
                    {
                        if (dados.Descricao.Equals(servico.Nome))
                        {
                            MessageBox.Show("Este item já foi adicionado", "Atenção");
                            return;
                        }
                    }
                }
                Item item = new()
                {
                    AtendimentoId = _atendimento.Id,
                    Descricao = servico.Nome,
                    ProdutoServicoId = (int)servico.Id,
                    Quantidade = quantidade,
                    TipoItem = "Serviço",
                    ValorUnitario = valorServico,
                    ValorTotal = valorServico * quantidade
                };
                dgItemAtendimento.Rows.Add(
                    item.AtendimentoId,
                    item.TipoItem,
                    item.ProdutoServicoId,
                    item.Descricao,
                    decimal.Round(item.Quantidade, 2, MidpointRounding.AwayFromZero),
                    decimal.Round(item.ValorUnitario, 2, MidpointRounding.AwayFromZero),
                    decimal.Round(item.ValorTotal, 2, MidpointRounding.AwayFromZero)
                );
                _itens.Add(item);
            }
        }
        private void BtnProduto(object sender, EventArgs e)
        {
            decimal quantidade = decimal.Parse(txtQuantidadeProduto.Text);
            decimal valorProduto = decimal.Parse(txtValorProduto.Text);
            if (string.IsNullOrEmpty(txtQuantidadeServico.Text))
            {
                MessageBox.Show("Para inserir um item é necessário informar a quantidade correta");
            }
            else if (quantidade < 1)
            {
                MessageBox.Show("Para inserir um item a quantidade não pode ser zero");
            }
            else if (valorProduto < 1)
            {
                MessageBox.Show("Para inserir um item o valor não pode ser zero");
            }
            else
            {
                Produto produto = (Produto)cbProduto.SelectedItem;
                if (_itens.Count > 0)
                {
                    foreach (var dados in _itens)
                    {
                        if (dados.Descricao.Equals(produto.Nome))
                        {
                            MessageBox.Show("Este item já foi adicionado", "Atenção");
                            return;
                        }
                    }
                }
                Item item = new()
                {
                    AtendimentoId = _atendimento.Id,
                    Descricao = produto.Nome,
                    ProdutoServicoId = (int)produto.Id,
                    Quantidade = quantidade,
                    TipoItem = "Produto",
                    ValorUnitario = valorProduto,
                    ValorTotal = valorProduto * quantidade
                };
                dgItemAtendimento.Rows.Add(
                    item.AtendimentoId,
                    item.TipoItem,
                    item.ProdutoServicoId,
                    item.Descricao,
                    decimal.Round(item.Quantidade, 2, MidpointRounding.AwayFromZero),
                    decimal.Round(item.ValorUnitario, 2, MidpointRounding.AwayFromZero),
                    decimal.Round(item.ValorTotal, 2, MidpointRounding.AwayFromZero)
                );
                _itens.Add(item);
            }
        }
        private void BtnSalvar(object sender, EventArgs e)
        {
            Logging log = new();
            if (_itens.Count > 0)
            {
                try
                {
                    foreach (var item in _itens)
                    {
                        ItemAtendimento dados = new();
                        dados.CriadoEm = DateTime.Now;
                        dados.CriadoPor = Usuario.UsuarioAtivo.Id;
                        dados.ProdutoServicoId = item.ProdutoServicoId;
                        dados.Quantidade = item.Quantidade;
                        dados.TipoItem = item.TipoItem.Substring(0, 1);
                        dados.AtendimentoId = item.AtendimentoId;
                        dados.ValorUnitario = item.ValorUnitario;
                        dados.ValorTotal = item.ValorTotal;

                        _database.ItemAtendimento.Add(dados);
                        _database.SaveChanges();
                    }                    
                    this.Close();
                } catch (Exception ex)
                {
                    log.Log(ex);
                    MessageBox.Show("Não foi possível salvar os itens, tente novamente mais tarde");
                }
            } else
            {
                MessageBox.Show("Para salvar é necessário ter pelo menos um item alocado");
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
        private void ComboboxServicoSelecionado(object sender, EventArgs e)
        {
            if (cbServico.SelectedItem != null)
            {
                Servico servico = (Servico)cbServico.SelectedItem;
                txtValorServico.Text = servico.Valor.ToString();
                txtQuantidadeServico.Text = "0,00";
            }            
        }
        private void ComboboxProdutoSelecionado(object sender, EventArgs e)
        {
            if (cbProduto.SelectedItem != null)
            {
                Produto produto = (Produto)cbProduto.SelectedItem;
                txtValorProduto.Text = produto.Valor.ToString();
                txtQuantidadeProduto.Text = "0,00";
            }
        }
        private void DataGridKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                if (dgItemAtendimento.Rows.Count > 0)
                {
                    Logging log = new();
                    try
                    {
                        if (dgItemAtendimento.Rows[0].Cells[0].Value != null)
                        {
                            int id = (int)dgItemAtendimento.CurrentRow.Index;
                            dgItemAtendimento.Rows.RemoveAt(id);
                        } else
                        {
                            MessageBox.Show("Não há nenhum item", "Aviso");
                        }
                    } catch (Exception ex)
                    {
                        log.Log(ex);
                        MessageBox.Show("Não foi possível deletar linha", "Atenção");
                    }
                }
            }
        }
    }
    public class Item
    {
        public int AtendimentoId { get; set; }
        public string TipoItem { get; set; }
        public int ProdutoServicoId { get; set; }
        public string Descricao { get; set; }
        public decimal Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
