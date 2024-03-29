﻿using Barbearia.Database;
using Barbearia.Log;
using Barbearia.Models.DTO;
using Barbearia.Views.FormCrud;
using Barbersoft.Models;
using Barbersoft.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Barbearia.Views
{
    public partial class ProfissionalView : Form
    {
        private readonly ObterDadosGenericos dados;
        public ProfissionalView()
        {
            InitializeComponent();

            dados = new();
        }
        private void RecebeDadosBanco()
        {
            dgProfissional.DataSource = dados.ObterDados<Profissional>().Select(p => new ProfissionalDTO()
            {
                Id = p.Id,
                Nome = p.Nome,
                Cpf = FormataCampo(p.Cpf, false),
                Celular = FormataCampo(p.Celular, true),
                Porcentagem = p.Porcentagem
            }).OrderByDescending(p => p.Id).ToList();
        }
        private void ConfiguraDataGrid()
        {
            RecebeDadosBanco();
            dgProfissional.Columns[0].Width = 35;
            dgProfissional.Columns[1].Width = 360;
            dgProfissional.Columns[2].Width = 165;
            dgProfissional.Columns[3].Width = 160;
            dgProfissional.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgProfissional.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

            dgProfissional.Columns[0].HeaderText = "ID";
            dgProfissional.Columns[1].HeaderText = "Nome";

            dgProfissional.Columns[2].HeaderText = "CPF";
            dgProfissional.Columns[2].DefaultCellStyle.Format = "###.###.###-##";

            dgProfissional.Columns[3].HeaderText = "Celular/Telefone";
            dgProfissional.Columns[3].DefaultCellStyle.Format = "(##)# ####-####";

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
            RecebeDadosBanco();
            ConfiguraDataGrid();
        }
        private void BtnExcluir(object sender, EventArgs e)
        {
            if (dgProfissional.Rows.Count > 0)
            {
                int id = (int)dgProfissional.SelectedRows[0].Cells[0].Value;
                Profissional profissional = dados.ObterDados<Profissional>().FirstOrDefault(p => p.Id == id);
                DialogResult dialogResult = MessageBox.Show($"Deseja excluir o Profissional: {profissional.Nome} ?", "Atenção", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    dados.RemoveDados(profissional);
                    RecebeDadosBanco();
                }
            } else
            {
                MessageBox.Show("Sem dados para serem excluídos");
            }
        }
        private void BtnAlterar(object sender, EventArgs e)
        {
            if (dgProfissional.Rows.Count > 0)
            {
                int id = (int)dgProfissional.SelectedRows[0].Cells[0].Value;
                Profissional profissional = dados.ObterDados<Profissional>().FirstOrDefault(p => p.Id == id);
                ProfissionalForm formProfissional = new(false, profissional);
                formProfissional.ShowDialog();
                RecebeDadosBanco();
            } else
            {
                MessageBox.Show("Sem dados para serem alterados");
            }
        }
        private void BtnAdicionar(object sender, EventArgs e)
        {
            FormCrud.ProfissionalForm formProfissional = new(true);
            formProfissional.ShowDialog();
            RecebeDadosBanco();
        }
        private string FormataCampo(string campo, bool telefone)
        {
            string cpf = campo;

            if (cpf.Contains("."))
            {
                cpf = cpf.Replace(".", "");
            }

            if (cpf.Contains("-"))
            {
                cpf = cpf.Replace("-", "");
            }

            if (cpf.Contains(" "))
            {
                cpf = cpf.Replace(" ", "");
            }

            var numeroCPF = Convert.ToInt64(cpf);
            if (!telefone)
            {
                return numeroCPF.ToString(@"000\.000\.000\-00");
            }
            else
            {
                return numeroCPF.ToString(@"(00)0 0000\-0000");
            }
        }
    }
}
