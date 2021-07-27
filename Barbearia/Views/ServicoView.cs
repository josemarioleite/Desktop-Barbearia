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
    public partial class ServicoView : Form
    {
        private readonly BarbersoftContext barbersoftContext;
        public ServicoView()
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
            }).OrderByDescending(s => s.Id).ToList();
        }
        public void ConfiguraDataGrid()
        {
            dgServico.Columns[0].Width = 52;
            dgServico.Columns[1].Width = 395;
            //dgServico.Columns[2].Width = 100;
            dgServico.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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
        private void ServicoLoad(object sender, EventArgs e)
        {
            RecebeDadosBanco();
            ConfiguraDataGrid();
        }
        private dynamic ObtemDadosServicoPorID(int id)
        {
            return barbersoftContext.Servico.FirstOrDefault(p => p.Id == id);
        }
        private void BtnExcluir(object sender, EventArgs e)
        {
            if (dgServico.Rows.Count > 0)
            {
                Logging log = new();
                int id = (int)dgServico.SelectedRows[0].Cells[0].Value;
                var servico = ObtemDadosServicoPorID(id);
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
            } else
            {
                MessageBox.Show("Sem dados para serem excluídos");
            }
        }
        private void BtnAlterar(object sender, EventArgs e)
        {
            if (dgServico.Rows.Count > 0)
            {
                int id = (int)dgServico.SelectedRows[0].Cells[0].Value;
                var servico = ObtemDadosServicoPorID(id);
                ServicoForm formServico = new(false, servico);
                formServico.ShowDialog();
                RecebeDadosBanco();
            } else
            {
                MessageBox.Show("Sem dados para serem alterados");
            }
        }
        private void BtnAdicionar(object sender, EventArgs e)
        {
            ServicoForm servico = new(true);
            servico.ShowDialog();
            RecebeDadosBanco();
        }
    }
}
