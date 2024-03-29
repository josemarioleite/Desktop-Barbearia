﻿using Barbearia.Log;
using Barbearia.Models.DTO;
using Barbearia.Views.FormProduto;
using Barbersoft.Models;
using Barbersoft.Utils;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Barbearia.Views
{
    public partial class ProdutoView : Form
    {
        private readonly ObterDadosGenericos dados;
        public ProdutoView()
        {
            InitializeComponent();

            dados = new();
        }
        private void RecebeDadosBanco()
        {
            dgProduto.DataSource = dados.ObterDados<Produto>().Select(p => new ProdutoDTO()
            {
                Id = p.Id,
                Nome = p.Nome,
                Valor = p.Valor,
                ComissaoPorcentagem = (p.ComissaoPorcentagem == "C" ? "Comissão" : "Porcentagem"),
                ValorComissaoPorcentagem = p.ValorComissaoPorcentagem
            }).OrderByDescending(p => p.Id).ToList();
        }
        private Produto ObtemDadosProdutoPorID(int id)
        {
            return dados.ObterDados<Produto>().FirstOrDefault(p => p.Id == id);
        }
        public void ConfiguraDataGrid()
        {
            dgProduto.Columns[0].Width = 55;
            dgProduto.Columns[1].Width = 445;
            dgProduto.Columns[2].Width = 60;
            dgProduto.Columns[3].Width = 150;
            dgProduto.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgProduto.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

            dgProduto.Columns[0].HeaderText = "ID";
            dgProduto.Columns[1].HeaderText = "Nome";
            dgProduto.Columns[2].HeaderText = "Valor R$";
            dgProduto.Columns[3].HeaderText = "Comissão/Porcentagem";
            dgProduto.Columns[4].HeaderText = "Valor Cms./Por.";

            dgProduto.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgProduto.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgProduto.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgProduto.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgProduto.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgProduto.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgProduto.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243);
            dgProduto.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgProduto.EnableHeadersVisualStyles = false;
        }
        private void FormProdutoLoad(object sender, EventArgs e)
        {
            RecebeDadosBanco();
            ConfiguraDataGrid();
        }
        private void BtnExcluir(object sender, EventArgs e)
        {
            if (dgProduto.Rows.Count > 0)
            {
                int id = (int)dgProduto.SelectedRows[0].Cells[0].Value;
                Produto produto = ObtemDadosProdutoPorID(id);
                DialogResult dialogResult = MessageBox.Show($"Deseja excluir o Produto: {produto.Nome} ?", "Atenção", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    dados.RemoveDados(produto);
                    RecebeDadosBanco();
                }
            } else
            {
                MessageBox.Show("Sem Dados para serem excluídos");
            }
        }
        private void BtnAdd(object sender, EventArgs e)
        {
            ProdutoForm formProduto = new(true);
            formProduto.ShowDialog();
            RecebeDadosBanco();
        }
        private void BtnAlterar(object sender, EventArgs e)
        {
            if (dgProduto.Rows.Count > 0)
            {
                var id = (int)dgProduto.SelectedRows[0].Cells[0].Value;
                Produto produto = ObtemDadosProdutoPorID(id);
                ProdutoForm formProduto = new(false, produto);
                formProduto.ShowDialog();
                RecebeDadosBanco();
            } else
            {
                MessageBox.Show("Sem Dados para serem alterados");
            }
        }
    }
}
