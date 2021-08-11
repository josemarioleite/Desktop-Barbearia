using Barbearia.Database;
using Barbersoft.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Barbersoft.Views.FormCrud;
using Barbersoft.Utils;
using Barbersoft.Models;
using System.Collections.Generic;

namespace Barbersoft.Views
{
    public partial class ClienteView : Form
    {
        private Cliente _cliente;
        private readonly bool _modoSelecao;
        public Cliente Cliente
        {
            get
            {
                return _cliente;
            }
        }
        private readonly ObterDadosGenericos dados;
        public ClienteView()
        {
            InitializeComponent();

            dados = new();
        }
        public ClienteView(bool modoSelecao)
        {
            InitializeComponent();

            dados = new();
            _modoSelecao = modoSelecao;
        }
        private List<ClienteDTO> RetornaCliente()
        {
            return dados.ObterDados<Cliente>().Select(p => new ClienteDTO()
            {
                Id = p.Id,
                Nome = p.Nome,
                Celular = p.Celular
            }).OrderByDescending(c => c.Id).ToList();
        }
        private void RecebeDadosBanco()
        {
            dgCliente.DataSource = RetornaCliente();
        }
        public void ConfiguraDataGrid()
        {
            dgCliente.Columns[0].Width = 52;
            dgCliente.Columns[1].Width = 360;
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
        private void ClienteLoad(object sender, EventArgs e)
        {
            ConfiguraForm();
        }
        private void ConfiguraForm()
        {
            RecebeDadosBanco();
            ConfiguraDataGrid();
        }
        private void BtnExcluir(object sender, EventArgs e)
        {
            if (dgCliente.Rows.Count > 0)
            {
                int id = (int)dgCliente.SelectedRows[0].Cells[0].Value;
                Cliente cliente = dados.ObterDados<Cliente>().FirstOrDefault(c => c.Id == id);
                dados.RemoveDados(cliente);
                RecebeDadosBanco();
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
                var cliente = dados.ObterDados<Cliente>().FirstOrDefault(c => c.Id == id);
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
        private void EscolheFornecedor()
        {
            int id = (int)dgCliente.SelectedRows[0].Cells[0].Value;
            _cliente = dados.ObterDados<Cliente>().FirstOrDefault(f => f.Id == id);
            this.Close();
        }
        private void Cliente_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (_modoSelecao)
            {
                EscolheFornecedor();
            }
        }
        private void BtnPesquisar(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbClienteNome.Text))
            {
                var filtroNomeCliente = tbClienteNome.Text.ToUpper().Trim();
                dgCliente.DataSource = RetornaCliente().Where(c => c.Nome.Contains(filtroNomeCliente)).ToList();
            }
        }
        private void BtnLimparDados(object sender, EventArgs e)
        {
            tbClienteNome.Text = "";
            ConfiguraForm();
        }
    }
}
