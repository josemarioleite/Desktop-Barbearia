﻿using Barbearia.Database;
using Barbearia.Log;
using Barbearia.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Barbearia.Views
{
    public partial class Profissional : Form
    {
        private readonly BarbersoftContext database;
        public Profissional()
        {
            InitializeComponent();

            database = new();
        }
        private void RecebeDadosBanco()
        {
            try
            {
                dgProfissional.DataSource = database.Profissional.AsNoTracking().Select(p => new ProfissionalDTO()
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Cpf = Convert.ToUInt64(p.Cpf).ToString(@"000\.000\.000\-00"),
                    Celular = p.Celular,
                    Porcentagem = p.Porcentagem
                }).ToList();
            } catch (Exception ex)
            {
                MessageBox.Show("Erro ao Obter Profissionais, tente novamente depois");
                Logging log = new();
                log.Log(ex);
            }
        }
        private void ConfiguraDataGrid()
        {
            RecebeDadosBanco();
            dgProfissional.Columns[0].Width = 35;
            dgProfissional.Columns[1].Width = 360;
            dgProfissional.Columns[2].Width = 165;
            dgProfissional.Columns[3].Width = 160;
            dgProfissional.Columns[4].Width = 100;
            dgProfissional.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

            dgProfissional.Columns[0].HeaderText = "ID";
            dgProfissional.Columns[1].HeaderText = "Nome";
            dgProfissional.Columns[2].HeaderText = "CPF";
            dgProfissional.Columns[3].HeaderText = "Celular/Telefone";
            dgProfissional.Columns[4].HeaderText = "Porcentagem %";

            dgProfissional.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgProfissional.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgProfissional.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgProfissional.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgProfissional.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243);
            dgProfissional.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgProfissional.EnableHeadersVisualStyles = false;
        }
        private void FormProfissionalLoad(object sender, EventArgs e)
        {
            ConfiguraDataGrid();
        }
        private Models.Profissional ObtemDadosProfissionalPorID(int id)
        {
            return database.Profissional.FirstOrDefault(p => p.Id == id);
        }
        private void BtnExcluir(object sender, EventArgs e)
        {
            Logging log = new();

            int id = (int)dgProfissional.SelectedRows[0].Cells[0].Value;
            Models.Profissional profissional = ObtemDadosProfissionalPorID(id);
            DialogResult dialogResult = MessageBox.Show($"Deseja excluir o Profissional: {profissional.Nome} ?", "Atenção", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    database.Profissional.Remove(profissional);
                    database.SaveChanges();
                    RecebeDadosBanco();
                }
                catch (Exception ex)
                {
                    log.Log(ex);
                    MessageBox.Show("Não foi possível fazer a exclusão, tente novamente mais tarde");
                }
            }
        }
        private void BtnAlterar(object sender, EventArgs e)
        {
            int id = (int)dgProfissional.SelectedRows[0].Cells[0].Value;
            Models.Profissional profissional = ObtemDadosProfissionalPorID(id);
            FormCrud.ProfissionalForm formProfissional = new(false, profissional);
            formProfissional.ShowDialog();
            RecebeDadosBanco();
        }
        private void BtnAdicionar(object sender, EventArgs e)
        {
            FormCrud.ProfissionalForm formProfissional = new(true);
            formProfissional.ShowDialog();
            RecebeDadosBanco();
        }
    }
}