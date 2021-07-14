using Barbearia.Database;
using Barbearia.Log;
using Barbersoft.Models.DTO;
using Barbersoft.Views.FormCrud;
using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Barbearia.Views
{
    public partial class Servico : Form
    {
        private readonly BarbersoftContext barbersoftContext;
        public Servico()
        {
            InitializeComponent();

            barbersoftContext = new BarbersoftContext();
        }

        private void RecebeDadosBanco()
        {
            dgServico.DataSource = barbersoftContext.Servico.AsNoTracking().Select(p => new ServicoDTO()
            {
                Id = p.Id,
                Nome = p.Nome,
                Valor = p.Valor,
            }).ToList();
        }
        public void ConfiguraDataGrid()
        {
            dgServico.Columns[0].Width = 52;
            dgServico.Columns[1].Width = 395;
            dgServico.Columns[2].Width = 100;
            dgServico.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

            dgServico.Columns[0].HeaderText = "ID";
            dgServico.Columns[1].HeaderText = "Nome";
            dgServico.Columns[2].HeaderText = "Valor R$";

            dgServico.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgServico.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgServico.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgServico.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgServico.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243);
            dgServico.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgServico.EnableHeadersVisualStyles = false;
        }
        private void ServicoLoad(object sender, System.EventArgs e)
        {
            RecebeDadosBanco();
            ConfiguraDataGrid();
        }
        private Models.Servico ObtemDadosServicoPorID(int id)
        {
            return barbersoftContext.Servico.FirstOrDefault(p => p.Id == id);
        }
        private void BtnExcluir(object sender, System.EventArgs e)
        {
            Logging log = new();

            int id = (int)dgServico.SelectedRows[0].Cells[0].Value;
            Models.Servico servico = ObtemDadosServicoPorID(id);
            DialogResult dialogResult = MessageBox.Show($"Deseja excluir o Serviço: {servico.Nome} ?", "Atenção", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    barbersoftContext.Servico.Remove(servico);
                    barbersoftContext.SaveChanges();
                    RecebeDadosBanco();
                }
                catch (Exception ex)
                {
                    log.Log(ex);
                }
            }
        }
        private void BtnAlterar(object sender, EventArgs e)
        {
            int id = (int)dgServico.SelectedRows[0].Cells[0].Value;
            Models.Servico servico = ObtemDadosServicoPorID(id);
            ServicoForm formServico = new(false, servico);
            formServico.ShowDialog();
            RecebeDadosBanco();
        }
        private void BtnAdicionar(object sender, EventArgs e)
        {
            ServicoForm servico = new(true);
            servico.ShowDialog();
            RecebeDadosBanco();
        }
    }
}
