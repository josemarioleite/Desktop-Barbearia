using Barbearia.Database;
using Barbersoft.Gestor.Crud;
using Barbersoft.Models.DTO;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Barbersoft.Gestor
{
    public partial class UsuarioGestor : Form
    {
        private readonly BarbersoftContext database;
        public UsuarioGestor()
        {
            InitializeComponent();

            database = new();
        }
        private void BtnExcluir(object sender, EventArgs e)
        {

        }
        private void BtnAlterar(object sender, EventArgs e)
        {

        }
        private void BtnAdicionar(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;
            UsuarioCrud usuario = new();
            usuario.ShowDialog();
            RecebeDados();
        }
        private void RecebeDados()
        {
            dgUsuario.DataSource = database.Usuario.Where(u => u.SuperUser != "S").Select(u => new UsuarioDTO()
            {
                Id = u.Id,
                Nome = u.Nome,
                Login = u.Login,
                Administrador = u.Administrador == "S" ? "Sim" : "Não",
                Ativo = u.Ativo == "S" ? "Sim" : "Não",
                PrimeiroAcesso = u.PrimeiroAcesso == "S" ? "Sim" : "Não"
            }).ToList();
        }
        public void ConfiguraDataGrid()
        {
            dgUsuario.Columns[0].Width = 48;
            dgUsuario.Columns[1].Width = 210;
            dgUsuario.Columns[2].Width = 120;
            dgUsuario.Columns[3].Width = 85;
            dgUsuario.Columns[4].Width = 65;
            dgUsuario.Columns[5].Width = 100;
            dgUsuario.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

            dgUsuario.Columns[0].HeaderText = "ID";
            dgUsuario.Columns[1].HeaderText = "Nome";
            dgUsuario.Columns[2].HeaderText = "Login";
            dgUsuario.Columns[3].HeaderText = "Administrador";
            dgUsuario.Columns[4].HeaderText = "Ativo";
            dgUsuario.Columns[5].HeaderText = "Primeiro Acesso";

            dgUsuario.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgUsuario.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgUsuario.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243);
            dgUsuario.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgUsuario.EnableHeadersVisualStyles = false;
        }
        private void Usuario_OnLoad(object sender, EventArgs e)
        {
            RecebeDados();
            ConfiguraDataGrid();
        }
    }
}
