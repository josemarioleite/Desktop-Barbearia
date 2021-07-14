using Barbearia.Database;
using Barbearia.Models;
using Barbersoft.Models.DTO;
using Barbersoft.Views.FormCrud;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Barbersoft.Views
{
    public partial class EntradaProduto : Form
    {
        private readonly BarbersoftContext barbersoftContext;
        public EntradaProduto()
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
            dgEntradaProduto.Columns[4].Width = 100;
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
            FormEntradaProduto entradaProduto = new();
            entradaProduto.ShowDialog();
            //RecebeDadosBanco();
        }
    }
}
