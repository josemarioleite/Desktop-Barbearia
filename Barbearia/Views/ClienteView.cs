using Barbearia.Database;
using Barbersoft.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Barbearia.Log;
using Barbersoft.Views.FormCrud;

namespace Barbersoft.Views
{
    public partial class ClienteView : Form
    {
        private readonly BarbersoftContext barbersoftContext;
        public ClienteView()
        {
            InitializeComponent();

            barbersoftContext = new();
        }
        private void RecebeDadosBanco()
        {
            dgCliente.DataSource = barbersoftContext.Cliente.AsNoTracking().Select(p => new ClienteDTO()
            {
                Id = p.Id,
                Nome = p.Nome,
                Celular = p.Celular
            }).ToList();
        }
        public void ConfiguraDataGrid()
        {
            dgCliente.Columns[0].Width = 52;
            dgCliente.Columns[1].Width = 360;
            //dgCliente.Columns[2].Width = 115;
            dgCliente.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgCliente.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

            dgCliente.Columns[0].HeaderText = "ID";
            dgCliente.Columns[1].HeaderText = "Nome";
            dgCliente.Columns[2].HeaderText = "Celular";

            dgCliente.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgCliente.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgCliente.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243);
            dgCliente.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgCliente.EnableHeadersVisualStyles = false;
        }
        private void ClienteLoad(object sender, System.EventArgs e)
        {
            RecebeDadosBanco();
            ConfiguraDataGrid();
        }
        private dynamic ObtemDadosClientePorID(int id)
        {
            return barbersoftContext.Cliente.FirstOrDefault(p => p.Id == id);
        }
        private void BtnExcluir(object sender, System.EventArgs e)
        {
            if (dgCliente.Rows.Count > 0)
            {
                Logging log = new();
                int id = (int)dgCliente.SelectedRows[0].Cells[0].Value;
                var cliente = ObtemDadosClientePorID(id);
                DialogResult dialogResult = MessageBox.Show($"Deseja excluir o Cliente: {cliente.Nome} ?", "Atenção", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        barbersoftContext.Cliente.Remove(cliente);
                        barbersoftContext.SaveChanges();
                        RecebeDadosBanco();
                    }
                    catch (Exception ex)
                    {
                        log.Log(ex);
                    }
                }
            }
            else
            {
                MessageBox.Show("Sem dados para serem excluídos");
            }
        }
        private void BtnAlterar(object sender, EventArgs e)
        {
            if (dgCliente.Rows.Count > 0)
            {
                int id = (int)dgCliente.SelectedRows[0].Cells[0].Value;
                var cliente = ObtemDadosClientePorID(id);
                ClienteForm clienteForm = new(false, cliente);
                clienteForm.ShowDialog();
                RecebeDadosBanco();
            } else
            {
                MessageBox.Show("Sem dados para serem alterados");
            }
        }
        private void BtnAdicionar(object sender, EventArgs e)
        {
            ClienteForm cliente = new(true);
            cliente.ShowDialog();
            RecebeDadosBanco();
        }
    }
}
