using Barbersoft.Models;
using Barbersoft.Utils;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Barbersoft.Views
{
    public partial class FornecedorView : Form
    {
        private Fornecedor _fornecedor;
        public Fornecedor fornecedor
        {
            get
            {
                return _fornecedor;
            }
        }
        private readonly ObterDadosGenericos dados;
        private bool _modoSelecao;
        public FornecedorView()
        {
            InitializeComponent();

            dados = new();
        }
        public FornecedorView(bool modoSelecao)
        {
            InitializeComponent();

            dados = new();
            _modoSelecao = modoSelecao;
        }
        private void ConfiguraForm()
        {
            if (!_modoSelecao)
            {
                pbLogo.Visible = true;
            } else
            {
                lblEscolher.Visible = true;
                btnEscolher.Visible = true;
            }
        }
        private void RecebeDadosBanco()
        {
            dgFornecedor.DataSource = dados.ObterDados<Fornecedor>();
        }
        private void ConfiguraGridView()
        {
            dgFornecedor.Columns[0].Width = 52;
            dgFornecedor.Columns[1].Width = 350;
            dgFornecedor.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgFornecedor.Columns[3].Visible = false;
            dgFornecedor.Columns[4].Visible = false;
            dgFornecedor.Columns[5].Visible = false;
            dgFornecedor.Columns[6].Visible = false;
            dgFornecedor.Columns[7].Visible = false;
            dgFornecedor.Columns[8].Visible = false;
            dgFornecedor.Columns[9].Visible = false;
            dgFornecedor.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

            dgFornecedor.Columns[0].HeaderText = "ID";
            dgFornecedor.Columns[1].HeaderText = "Nome";
            dgFornecedor.Columns[2].HeaderText = "Celular";

            dgFornecedor.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgFornecedor.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgFornecedor.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243);
            dgFornecedor.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgFornecedor.EnableHeadersVisualStyles = false;
        }
        private void Fornecedor_Load(object sender, EventArgs e)
        {
            ConfiguraForm();
            RecebeDadosBanco();
            ConfiguraGridView();
        }
        private void BtnEscolher(object sender, EventArgs e)
        {
            EscolheFornecedor();
        }
        private void Fornecedor_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (_modoSelecao == true)
            {
                EscolheFornecedor();
            }
        }
        private void EscolheFornecedor()
        {
            int id = (int)dgFornecedor.SelectedRows[0].Cells[0].Value;
            _fornecedor = dados.ObterDados<Fornecedor>().FirstOrDefault(f => f.Id == id);
            this.Close();
        }
        private void roundedButton3_Click(object sender, EventArgs e)
        {            
            if (dgFornecedor.Rows.Count > 0)
            {
                int id = (int)dgFornecedor.SelectedRows[0].Cells[0].Value;
                Fornecedor fornecedor = dados.ObterDados<Fornecedor>().FirstOrDefault(f => f.Id == id);
                DialogResult dialogResult = MessageBox.Show($"Deseja excluir o Fornecedor: {fornecedor.Nome} ?", "Atenção", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    dados.RemoveDados(fornecedor);
                    RecebeDadosBanco();
                }
            }
            else
            {
                MessageBox.Show("Sem Dados para serem excluídos");
            }
        }
    }
}
