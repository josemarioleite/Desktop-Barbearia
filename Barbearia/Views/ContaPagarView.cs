using Barbersoft.Models;
using Barbersoft.Utils;
using Barbersoft.Views.FormCrud;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Barbersoft.Views
{
    public partial class ContaPagarView : Form
    {
        private readonly ObterDadosGenericos dados;
        public ContaPagarView()
        {
            InitializeComponent();

            dados = new();
        }
        private void RecebeDadosBanco()
        {
            dgContaPagar.DataSource = dados.RetornaContaPagarFiltrado();
        }
        public void ConfiguraDataGrid()
        {
            dgContaPagar.Columns[0].Width = 20;
            dgContaPagar.Columns[1].Width = 50;
            dgContaPagar.Columns[2].Width = 250;
            dgContaPagar.Columns[3].Width = 125;
            dgContaPagar.Columns[4].Width = 125;
            dgContaPagar.Columns[5].Width = 200;
            dgContaPagar.Columns[6].Width = 100;
            dgContaPagar.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgContaPagar.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

            dgContaPagar.Columns[0].HeaderText = "";
            dgContaPagar.Columns[1].HeaderText = "ID";
            dgContaPagar.Columns[2].HeaderText = "Descrição";
            dgContaPagar.Columns[3].HeaderText = "Data de Lançamento";
            dgContaPagar.Columns[4].HeaderText = "Data de Vencimento";
            dgContaPagar.Columns[5].HeaderText = "Fornecedor";
            dgContaPagar.Columns[6].HeaderText = "Situação";
            dgContaPagar.Columns[7].HeaderText = "Valor";

            dgContaPagar.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgContaPagar.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgContaPagar.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgContaPagar.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgContaPagar.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgContaPagar.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgContaPagar.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgContaPagar.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgContaPagar.Columns[2].Resizable = DataGridViewTriState.True;
            dgContaPagar.Columns[5].Resizable = DataGridViewTriState.True;

            dgContaPagar.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243);
            dgContaPagar.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgContaPagar.EnableHeadersVisualStyles = false;
        }
        private void Load_ContaPagar(object sender, EventArgs e)
        {
            RecebeDadosBanco();
            ConfiguraDataGrid();
        }
        private void BtnAdicionar(object sender, EventArgs e)
        {
            new ContaPagarForm(true).ShowDialog();
            RecebeDadosBanco();
        }
        private void BtnExcluir(object sender, EventArgs e)
        {
            if (dgContaPagar.Rows.Count > 0)
            {
                int id = (int)dgContaPagar.SelectedRows[0].Cells[1].Value;
                ContaPagar contaPagar = dados.ObterDados<ContaPagar>().FirstOrDefault(c => c.Id == id);
                DialogResult dialogResult = MessageBox.Show($"Tem certeza que deseja excluir este lançamento ?", "Atenção", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    dados.RemoveDados(contaPagar);
                    RecebeDadosBanco();
                }
            }
            else
            {
                MessageBox.Show("Sem Dados para serem excluídos");
            }
        }
    }
}
