using Barbersoft.Models;
using Barbersoft.Utils;
using Barbersoft.Views.FormCrud;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Barbersoft.Views
{
    public partial class ContaReceberView : Form
    {
        private readonly ObterDadosGenericos dados;
        public ContaReceberView()
        {
            InitializeComponent();

            dados = new();
        }
        private void RecebeDadosBanco()
        {
            dgContaReceber.DataSource = dados.RetornaContaReceberFiltrado();
        }
        public void ConfiguraDataGrid()
        {
            dgContaReceber.Columns[0].Width = 20;
            dgContaReceber.Columns[1].Width = 50;
            dgContaReceber.Columns[2].Width = 250;
            dgContaReceber.Columns[3].Width = 125;
            dgContaReceber.Columns[4].Width = 125;
            dgContaReceber.Columns[5].Width = 200;
            dgContaReceber.Columns[6].Width = 100;
            dgContaReceber.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgContaReceber.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

            dgContaReceber.Columns[0].HeaderText = "";
            dgContaReceber.Columns[1].HeaderText = "ID";
            dgContaReceber.Columns[2].HeaderText = "Descrição";
            dgContaReceber.Columns[3].HeaderText = "Data de Lançamento";
            dgContaReceber.Columns[4].HeaderText = "Data de Vencimento";
            dgContaReceber.Columns[5].HeaderText = "Cliente";
            dgContaReceber.Columns[6].HeaderText = "Situação";
            dgContaReceber.Columns[7].HeaderText = "Valor";

            dgContaReceber.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgContaReceber.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgContaReceber.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgContaReceber.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgContaReceber.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgContaReceber.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgContaReceber.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgContaReceber.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgContaReceber.Columns[2].Resizable = DataGridViewTriState.True;
            dgContaReceber.Columns[5].Resizable = DataGridViewTriState.True;

            dgContaReceber.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243);
            dgContaReceber.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgContaReceber.EnableHeadersVisualStyles = false;
        }
        private void Load_ContaReceber(object sender, EventArgs e)
        {
            RecebeDadosBanco();
            ConfiguraDataGrid();
        }
        private void BtnExcluir(object sender, EventArgs e)
        {
            if (dgContaReceber.Rows.Count > 0)
            {
                int id = (int)dgContaReceber.SelectedRows[0].Cells[1].Value;
                ContaReceber contaReceber = dados.ObterDados<ContaReceber>().FirstOrDefault(p => p.Id == id);
                DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja excluir este lançamento ?", "Atenção", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    dados.RemoveDados(contaReceber);
                    RecebeDadosBanco();
                }
            } else
            {
                MessageBox.Show("Sem dados para serem excluídos", "Aviso");
            }
        }
        private void BtnAdicionar(object sender, EventArgs e)
        {
            new ContaReceberForm(true).ShowDialog();
            RecebeDadosBanco();
        }
    }
}
