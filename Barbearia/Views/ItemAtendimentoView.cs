using Barbearia.Database;
using Barbearia.Log;
using Barbersoft.Enum;
using Barbersoft.Models;
using Barbersoft.Models.DTO;
using Barbersoft.Views.FormCrud;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Barbersoft.Views
{
    public partial class ItemAtendimentoView : Form
    {
        private readonly Atendimento _atendimento;
        private readonly BarbersoftContext _database;
        public ItemAtendimentoView(Atendimento atendimento)
        {
            InitializeComponent();

            _atendimento = atendimento;
            _database = new();
        }
        private void RecebeDadosBanco()
        {
            List<ItemAtendimentoDTO> itemAtendimento = _database.ItemAtendimento.Where(i => i.AtendimentoId == _atendimento.Id).Select(i => new ItemAtendimentoDTO()
            {
                IdInteiro = i.Id,
                Id = i.Id,
                ProdutoServicoId = i.ProdutoServicoId,
                Quantidade = (String.Format(new CultureInfo("pt-BR"), "{0:C}", i.Quantidade)).Replace("R$", ""),
                TipoItem = (i.TipoItem == "P" ? "Produto" : "Serviço"),
                ValorUnitario = (String.Format(new CultureInfo("pt-BR"), "{0:C}", i.ValorUnitario)).Replace("R$", "R$ "),
                ValorTotal = (String.Format(new CultureInfo("pt-BR"), "{0:C}", i.ValorTotal)).Replace("R$", "R$ "),
                Descricao = ""
            }).OrderByDescending(i => i.Id).ToList();

            foreach (var item in itemAtendimento)
            {
                if (item.TipoItem == "Produto")
                {
                    Produto produto = _database.Produto.FirstOrDefault(p => p.Id == item.ProdutoServicoId);
                    item.Descricao = produto.Nome;
                } else
                {
                    Servico servico = _database.Servico.FirstOrDefault(p => p.Id == item.ProdutoServicoId);
                    item.Descricao = servico.Nome;
                }
            }
            dgItem.DataSource = itemAtendimento;
            decimal valorTotal = _database.ItemAtendimento.Where(i => i.AtendimentoId == _atendimento.Id).GroupBy(i => i.ValorTotal).Sum(i => i.Key);
            txtTotal.Text = valorTotal.ToString("N2", CultureInfo.CurrentCulture).Replace("R$", "");
        }
        private void ItemAtendimento_Load(object sender, EventArgs e)
        {
            RecebeDadosBanco();
            ConfiguraDataGrid();
            BarbersoftContext database = new();
            Atendimento atend = database.Atendimento.FirstOrDefault(a => a.Id == _atendimento.Id);
            Cliente cliente = database.Cliente.FirstOrDefault(c => c.Id == atend.ClienteId);
            Profissional profissional = database.Profissional.FirstOrDefault(p => p.Id == atend.ProfissionalId);
            Situacao situacao = database.Situacao.FirstOrDefault(s => s.Id == atend.SituacaoId);
            txtIDAtendimento.Text = _atendimento.Id.ToString("D4");
            txtCliente.Text = cliente.Nome;
            txtProfissional.Text = profissional.Nome;
            txtSituacao.Text = situacao.Descricao;
        }
        public void ConfiguraDataGrid()
        {
            dgItem.Columns[0].Width = 50;
            dgItem.Columns[1].Width = 122;
            dgItem.Columns[2].Width = 65;
            dgItem.Columns[3].Width = 300;
            dgItem.Columns[4].Width = 100;
            dgItem.Columns[5].Width = 100;
            dgItem.Columns[6].Width = 100;
            dgItem.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgItem.Columns[7].Visible = false;
            dgItem.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

            dgItem.Columns[0].HeaderText = "ID";
            dgItem.Columns[1].HeaderText = "Tipo";
            dgItem.Columns[2].HeaderText = "ID Item";
            dgItem.Columns[3].HeaderText = "Descrição/Nome";
            dgItem.Columns[4].HeaderText = "Quantidade";
            dgItem.Columns[5].HeaderText = "Valor Unitário";
            dgItem.Columns[6].HeaderText = "Valor Total";
            dgItem.Columns[7].HeaderText = "";

            dgItem.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgItem.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgItem.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgItem.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgItem.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgItem.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgItem.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgItem.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgItem.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgItem.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgItem.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243);
            dgItem.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgItem.EnableHeadersVisualStyles = false;
        }
        private void BtnSair(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnAdicionar(object sender, EventArgs e)
        {
            BarbersoftContext database = new();
            Atendimento atend = database.Atendimento.FirstOrDefault(a => a.Id == _atendimento.Id);
            if (atend.SituacaoId == (int)SituacaoEnum.Fechado)
            {
                MessageBox.Show("Não será possível adicionar novos itens, este atendimento está fechado");
            } else if (atend.SituacaoId == (int)SituacaoEnum.Cancelado)
            {
                MessageBox.Show("Não será possível adicionar novos itens, este atendimento está cancelado");
            } else
            {
                ItemAtendimentoForm item = new(atend);
                item.ShowDialog();
                RecebeDadosBanco();
            }            
        }
        private ItemAtendimento ObtemDadosItemPorID(int id)
        {
            return _database.ItemAtendimento.FirstOrDefault(p => p.Id == id);
        }
        private void BtnExcluir(object sender, EventArgs e)
        {
            if (dgItem.Rows.Count > 0)
            {
                Logging log = new();
                var id = dgItem.SelectedRows[0].Cells[7].Value;
                ItemAtendimento itemAtendimento = ObtemDadosItemPorID((int)id);
                DialogResult dialogResult = MessageBox.Show($"Deseja excluir o Item N°: {itemAtendimento.Id} ?", "Atenção", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        _database.ItemAtendimento.Remove(itemAtendimento);
                        _database.SaveChanges();
                        RecebeDadosBanco();
                    }
                    catch (Exception ex)
                    {
                        log.Log(ex);
                    }
                }
            } else
            {
                MessageBox.Show("Sem dados para serem excluídos");
            }            
        }
    }
}
