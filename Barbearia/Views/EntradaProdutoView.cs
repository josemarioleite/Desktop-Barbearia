using Barbearia.Database;
using Barbearia.Log;
using Barbearia.Models;
using Barbersoft.Models;
using Barbersoft.Models.DTO;
using Barbersoft.Views.FormCrud;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Barbersoft.Views
{
    public partial class EntradaProdutoView : Form
    {
        private readonly BarbersoftContext barbersoftContext;
        public EntradaProdutoView()
        {
            InitializeComponent();

            barbersoftContext = new();
        }
        private void RecebeDadosBanco()
        {
            List<EntradaProdutoDTO> entradaProduto = (from a in barbersoftContext.EntradaProduto
                                 join b in barbersoftContext.Produto on a.IdProduto equals b.Id
                                 select new EntradaProdutoDTO()
                                 {
                                     Id = a.Id,
                                     IdProduto = b.Id,
                                     Produto = b.Nome,
                                     Quantidade = a.Quantidade,
                                     Data = a.Data
                                 }).ToList();

            dgEntradaProduto.DataSource = entradaProduto;
        }
        private void ConfiguraDataGrid()
        {
            dgEntradaProduto.Columns[0].Width = 45;
            dgEntradaProduto.Columns[1].Width = 75;
            dgEntradaProduto.Columns[2].Width = 265;
            dgEntradaProduto.Columns[3].Width = 75;
            //dgEntradaProduto.Columns[4].Width = 100;
            dgEntradaProduto.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgEntradaProduto.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

            dgEntradaProduto.Columns[0].HeaderText = "ID";
            dgEntradaProduto.Columns[1].HeaderText = "Produto-ID";
            dgEntradaProduto.Columns[2].HeaderText = "Produto";
            dgEntradaProduto.Columns[3].HeaderText = "Quantidade";
            dgEntradaProduto.Columns[4].HeaderText = "Data da Compra";

            dgEntradaProduto.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgEntradaProduto.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgEntradaProduto.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgEntradaProduto.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgEntradaProduto.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgEntradaProduto.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgEntradaProduto.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgEntradaProduto.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgEntradaProduto.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243);
            dgEntradaProduto.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgEntradaProduto.EnableHeadersVisualStyles = false;
        }
        private void EntradaProdutoLoad(object sender, System.EventArgs e)
        {
            RecebeDadosBanco();
            ConfiguraDataGrid();
        }
        private void BtnAdicionar(object sender, System.EventArgs e)
        {
            EntradaProdutoForm entradaProduto = new(true);
            entradaProduto.ShowDialog();
            RecebeDadosBanco();
        }
        private EntradaProduto ObtemDadosEntradaProdutoPorID(int id)
        {
            return barbersoftContext.EntradaProduto.FirstOrDefault(p => p.Id == id);
        }
        private void BtnExcluir(object sender, System.EventArgs e)
        {
            if (dgEntradaProduto.Rows.Count > 0)
            {
                Logging log = new();
                int id = (int)dgEntradaProduto.SelectedRows[0].Cells[0].Value;
                EntradaProduto entradaProduto = ObtemDadosEntradaProdutoPorID(id);
                DialogResult dialogResult = MessageBox.Show($"Tem certeza que gostaria de excluir esta entrada de produto ?", "Atenção", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        barbersoftContext.EntradaProduto.Remove(entradaProduto);
                        barbersoftContext.SaveChanges();
                        RecebeDadosBanco();
                    }
                    catch (Exception ex)
                    {
                        log.Log(ex);
                        MessageBox.Show("Não foi possível excluir esta entrada de produto");
                    }
                }
            } else
            {
                MessageBox.Show("Sem Dados para serem excluídos");
            }
        }
        private void BtnEstoque(object sender, EventArgs e)
        {
            EstoqueProdutoView estoque = new();
            estoque.ShowDialog();
        }
    }
}
