using Barbearia.Database;
using Barbersoft.Models.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Barbersoft.Views
{
    public partial class EstoqueProdutoView : Form
    {
        private readonly BarbersoftContext barbersoftContext;
        public EstoqueProdutoView()
        {
            InitializeComponent();

            barbersoftContext = new();
        }

        private void BtnSair(object sender, EventArgs e)
        {
            this.Close();
        }
        private void RecebeDadosBanco()
        {
            //dgEstoqueProduto.DataSource = barbersoftContext.EstoqueProduto.AsNoTracking().ToList();
            List<EstoqueProdutoDTO> estoqueProduto = (from a in barbersoftContext.EstoqueProduto
                                                                      join b in barbersoftContext.Produto on a.IdProduto equals b.Id
                                                                      select new EstoqueProdutoDTO()
                                                                      {
                                                                          Id = a.Id,
                                                                          IdProduto = b.Id,
                                                                          Produto = b.Nome,
                                                                          Quantidade = a.Quantidade,
                                                                          DataAtualizacao = a.DataAtualizacao
                                                                      }).ToList();
            dgEstoqueProduto.DataSource = estoqueProduto;
        }
        public void ConfiguraDataGrid()
        {
            dgEstoqueProduto.Columns[0].Width = 45;
            dgEstoqueProduto.Columns[1].Width = 70;
            dgEstoqueProduto.Columns[2].Width = 270;
            dgEstoqueProduto.Columns[3].Width = 90;
            //dgEstoqueProduto.Columns[4].Width = 120;
            dgEstoqueProduto.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgEstoqueProduto.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

            dgEstoqueProduto.Columns[0].HeaderText = "ID";
            dgEstoqueProduto.Columns[1].HeaderText = "ID Produto";
            dgEstoqueProduto.Columns[2].HeaderText = "Produto";
            dgEstoqueProduto.Columns[3].HeaderText = "Quantidade";
            dgEstoqueProduto.Columns[4].HeaderText = "Data de Atualização";

            dgEstoqueProduto.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgEstoqueProduto.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgEstoqueProduto.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgEstoqueProduto.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgEstoqueProduto.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgEstoqueProduto.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgEstoqueProduto.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgEstoqueProduto.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgEstoqueProduto.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243);
            dgEstoqueProduto.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgEstoqueProduto.EnableHeadersVisualStyles = false;
        }
        private void EstoqueLoad(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            RecebeDadosBanco();
            ConfiguraDataGrid();
        }
    }
}
