using Barbearia.Database;
using Barbearia.Log;
using Barbearia.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Barbearia.Views
{
    public partial class Produto : Form
    {
        private readonly BarbersoftContext barbersoftContext;
        public Produto()
        {
            InitializeComponent();

            barbersoftContext = new BarbersoftContext();
        }

        private void RecebeDadosBanco()
        {
            dgProduto.DataSource = barbersoftContext.Produto
                                        .AsNoTracking()
                                        .Where(p => p.Ativo == "S")
                                        .Select(p => new ProdutoDTO()
            {
                Id = p.Id,
                Nome = p.Nome,
                Valor = p.Valor,
                ComissaoPorcentagem = (p.ComissaoPorcentagem == "C" ? "Comissão" : "Porcentagem"),
                ValorComissaoPorcentagem = p.ValorComissaoPorcentagem
            }).ToList();
        }
        private Models.Produto ObtemDadosProdutoPorID(int id)
        {
            return barbersoftContext.Produto.FirstOrDefault(p => p.Id == id);
        }
        public void ConfiguraDataGrid()
        {
            dgProduto.Columns[0].Width = 55;
            dgProduto.Columns[1].Width = 445;
            dgProduto.Columns[2].Width = 60;
            dgProduto.Columns[3].Width = 150;
            dgProduto.Columns[4].Width = 100;
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
        private void FormProdutoLoad(object sender, System.EventArgs e)
        {
            RecebeDadosBanco();
            ConfiguraDataGrid();
        }
        private void BtnExcluir(object sender, System.EventArgs e)
        {
            Logging log = new();

            int id = (int)dgProduto.SelectedRows[0].Cells[0].Value;
            Models.Produto produto = ObtemDadosProdutoPorID(id);
            DialogResult dialogResult = MessageBox.Show($"Deseja excluir o Produto: {produto.Nome} ?", "Atenção", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    barbersoftContext.Produto.Remove(produto);
                    barbersoftContext.SaveChanges();
                    RecebeDadosBanco();
                    Notificacao("Produto Deletado", $"O Produto {produto.Nome} foi deletado");
                } catch (Exception ex)
                {
                    log.Log(ex);
                }                
            }
        }
        private void BtnAdd(object sender, EventArgs e)
        {
            FormProduto.Produto formProduto = new(true);
            formProduto.ShowDialog();
            RecebeDadosBanco();
            Notificacao("Novo Produto", "Grade atualizada");
        }
        private void BtnAlterar(object sender, EventArgs e)
        {
            int id = (int)dgProduto.SelectedRows[0].Cells[0].Value;
            Models.Produto produto = ObtemDadosProdutoPorID(id);
            FormProduto.Produto formProduto = new(false, produto);
            formProduto.ShowDialog();
            RecebeDadosBanco();
            Notificacao("Produto Alterado", $"O Produto {produto.Nome} foi alterado");
        }
        private void Notificacao(string titulo, string textoBalao)
        {
            notificationIcon.BalloonTipTitle = titulo;
            notificationIcon.BalloonTipText = textoBalao;
            notificationIcon.ShowBalloonTip(150);
            notificationIcon.Visible = true;
        }
    }
}
