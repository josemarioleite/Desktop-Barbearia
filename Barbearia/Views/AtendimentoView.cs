using Barbearia.Database;
using Barbearia.Log;
using Barbersoft.Models;
using Barbersoft.Models.DTO;
using Barbersoft.Views.FormCrud;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Barbersoft.Views
{
    public partial class AtendimentoView : Form
    {
        private readonly BarbersoftContext barbersoftContext;
        public AtendimentoView()
        {
            InitializeComponent();

            barbersoftContext = new();
        }
        private Atendimento ObtemDadosAtendimentoPorID(int id)
        {
            return barbersoftContext.Atendimento.FirstOrDefault(p => p.Id == id);
        }
        private List<AtendimentoDTO> RetornaImagemSituacao(List<AtendimentoDTO> atendimento)
        {
            ImageConverter converter = new();
            List<AtendimentoDTO> filtro = atendimento;
            foreach (AtendimentoDTO dto in filtro)
            {
                if (dto.Situacao.ToLower().Equals("aberto"))
                {
                    dto.imageSituacao = (byte[])converter.ConvertTo(Properties.Resources.Aberto, typeof(byte[]));
                }
                else if (dto.Situacao.ToLower().Equals("financeiro"))
                {
                    dto.imageSituacao = (byte[])converter.ConvertTo(Properties.Resources.financeiro, typeof(byte[]));
                }
                else if (dto.Situacao.ToLower().Equals("fechado"))
                {
                    dto.imageSituacao = (byte[])converter.ConvertTo(Properties.Resources.Fechado, typeof(byte[]));
                }
                else if (dto.Situacao.ToLower().Equals("cancelado"))
                {
                    dto.imageSituacao = (byte[])converter.ConvertTo(Properties.Resources.cancelado, typeof(byte[]));
                }

                decimal valorTotal = barbersoftContext.ItemAtendimento.Where(i => i.AtendimentoId == dto.Id).GroupBy(i => i.ValorTotal).Sum(i => i.Key);
                dto.Total += valorTotal.ToString("N2", CultureInfo.CurrentCulture).Replace("R$", "");
            }
            return filtro;
        }
        private void RecebeDadosBanco()
        {
            ImageConverter converter = new();
            List<AtendimentoDTO> atendimento = (from a in barbersoftContext.Atendimento
                                                      join b in barbersoftContext.Cliente on a.ClienteId equals b.Id
                                                      join c in barbersoftContext.Profissional on a.ProfissionalId equals c.Id
                                                      join d in barbersoftContext.Situacao on a.SituacaoId equals d.Id
                                                      select new AtendimentoDTO()
                                                      {
                                                          Id = a.Id,
                                                          Situacao = d.Descricao.ToUpper(),
                                                          Cliente = b.Nome.ToUpper(),
                                                          Profissional = c.Nome.ToUpper(),
                                                          Data = DateTime.Parse(a.CriadoEm.ToString("dd/MM/yyyy"))
                                                      }).OrderByDescending(a => a.Id).ToList();

            foreach (AtendimentoDTO dto in atendimento)
            {
                if (dto.Situacao.ToLower().Equals("aberto"))
                {
                    dto.imageSituacao = (byte[])converter.ConvertTo(Properties.Resources.Aberto, typeof(byte[]));
                }
                else if (dto.Situacao.ToLower().Equals("financeiro"))
                {
                    dto.imageSituacao = (byte[])converter.ConvertTo(Properties.Resources.financeiro, typeof(byte[]));
                }
                else if (dto.Situacao.ToLower().Equals("fechado"))
                {
                    dto.imageSituacao = (byte[])converter.ConvertTo(Properties.Resources.Fechado, typeof(byte[]));
                }
                else if (dto.Situacao.ToLower().Equals("cancelado"))
                {
                    dto.imageSituacao = (byte[])converter.ConvertTo(Properties.Resources.cancelado, typeof(byte[]));
                }

                decimal valorTotal = barbersoftContext.ItemAtendimento.Where(i => i.AtendimentoId == dto.Id).GroupBy(i => i.ValorTotal).Sum(i => i.Key);
                dto.Total += valorTotal.ToString("N2", CultureInfo.CurrentCulture).Replace("R$", "");
            }

            dgAtendimento.DataSource = atendimento;
        }
        private void ConfiguraDataGrid()
        {
            dgAtendimento.Columns[0].Width = 15;
            dgAtendimento.Columns[1].Width = 46;
            dgAtendimento.Columns[2].Width = 100;
            dgAtendimento.Columns[3].Width = 205;
            dgAtendimento.Columns[4].Width = 205;
            dgAtendimento.Columns[5].Width = 100;
            //dgAtendimento.Columns[6].Width = 75;
            dgAtendimento.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgAtendimento.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

            dgAtendimento.Columns[0].HeaderText = "";
            dgAtendimento.Columns[1].HeaderText = "ID";
            dgAtendimento.Columns[2].HeaderText = "Data do Atend.:";
            dgAtendimento.Columns[3].HeaderText = "Cliente";
            dgAtendimento.Columns[4].HeaderText = "Profissional";
            dgAtendimento.Columns[5].HeaderText = "Situação";
            dgAtendimento.Columns[6].HeaderText = "Total";

            dgAtendimento.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgAtendimento.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgAtendimento.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgAtendimento.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgAtendimento.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgAtendimento.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgAtendimento.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            dgAtendimento.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgAtendimento.EnableHeadersVisualStyles = false;
        }
        private void SetaDataDefault()
        {
            dtInicial.MaxDate = DateTime.Today;
            dtInicial.MinDate = new DateTime(DateTime.Today.Year, 1, 1);

            dtFinal.MaxDate = DateTime.Today;
            dtFinal.MinDate = new DateTime(DateTime.Today.Year, 1, 1);
        }
        private void BtnAdicionar(object sender, EventArgs e)
        {
            formAtendimento atendimento = new(true);
            atendimento.ShowDialog();
            RecebeDadosBanco();
        }
        private void BtnExcluir(object sender, EventArgs e)
        {
            if (dgAtendimento.Rows.Count > 0)
            {
                Logging log = new();
                int id = (int)dgAtendimento.SelectedRows[0].Cells[1].Value;
                Atendimento atendimento = ObtemDadosAtendimentoPorID(id);
                DialogResult dialogResult = MessageBox.Show($"Deseja excluir o Atendimento: {atendimento.Id} ?", "Atenção", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        barbersoftContext.Atendimento.Remove(atendimento);
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
        private void AtendimentoLoad(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            cbDados.SelectedItem = null;
            cbDados.SelectedText = "Selecione";

            cbPesquisa.SelectedItem = null;
            cbPesquisa.SelectedText = "Selecione";

            RecebeDadosBanco();
            ConfiguraDataGrid();
            SetaDataDefault();
        }
        private void BtnVisualizar(object sender, EventArgs e)
        {
            if (dgAtendimento.Rows.Count > 0)
            {
                int id = (int)dgAtendimento.SelectedRows[0].Cells[1].Value;
                Atendimento atendimento = ObtemDadosAtendimentoPorID(id);
                ItemAtendimentoView itemAtendimento = new(atendimento);
                itemAtendimento.ShowDialog();
            } else
            {
                MessageBox.Show("Sem Atendimentos para visualizar");
            }
            RecebeDadosBanco();
        }
        private void BtnPesquisar(object sender, EventArgs e)
        {
            List<AtendimentoDTO> dados = (from a in barbersoftContext.Atendimento
                                          join b in barbersoftContext.Cliente on a.ClienteId equals b.Id
                                          join c in barbersoftContext.Profissional on a.ProfissionalId equals c.Id
                                          join d in barbersoftContext.Situacao on a.SituacaoId equals d.Id
                                          select new AtendimentoDTO()
                                          {
                                              Id = a.Id,
                                              Situacao = d.Descricao.ToUpper(),
                                              Cliente = b.Nome.ToUpper(),
                                              Profissional = c.Nome.ToUpper(),
                                              Data = DateTime.Parse(a.CriadoEm.ToString("dd/MM/yyyy"))
                                          }).OrderByDescending(a => a.Id).ToList();

            var atendimento = RetornaImagemSituacao(dados);

            if (cbDados.SelectedValue != null)
            {
                var valor = cbDados.SelectedValue.ToString().ToLower();
                if (cbPesquisa.SelectedItem.ToString().ToLower() == "cliente")
                {
                    dgAtendimento.DataSource = atendimento.Where(a => a.Cliente.ToLower().Equals(valor)).ToList();
                }
                else if (cbPesquisa.SelectedItem.ToString().ToLower() == "profissional")
                {
                    dgAtendimento.DataSource = atendimento.Where(a => a.Profissional.ToLower().Equals(valor)).ToList();
                }
                else if (cbPesquisa.SelectedItem.ToString().ToLower() == "situação")
                {
                    dgAtendimento.DataSource = atendimento.Where(a => a.Situacao.ToLower().Equals(valor)).ToList();
                }
            } else if (cbPesquisa.SelectedItem != null)
            {
                if (cbPesquisa.SelectedItem.ToString().ToLower() == "data" && !string.IsNullOrEmpty(dtInicial.Value.ToString("dd/MM/yyyy")))
                {
                    var data = atendimento.Where(a => a.Data >= dtInicial.Value && a.Data <= dtFinal.Value).ToList();
                    dgAtendimento.DataSource = data;
                }
            }
            else
            {
                MessageBox.Show("Para fazer a pesquisa é necessário escolher uma coluna e um valor", "Atenção");
            }
        }
        private void Atendimento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                RecebeDadosBanco();
            }
        }
        private void ValorSelecionado(object sender, EventArgs e)
        {
            if (cbPesquisa.SelectedItem != null)
            {
                if (cbPesquisa.SelectedItem.ToString().ToLower() == "cliente")
                {
                    cbDados.Visible = true;
                    lblDataInicial.Visible = false;
                    lblDataFinal.Visible = false;

                    dtInicial.Visible = false;
                    dtFinal.Visible = false;

                    cbDados.DataSource = barbersoftContext.Cliente.OrderBy(c => c.Nome).ToList();
                    cbDados.DisplayMember = "Nome";
                    cbDados.ValueMember = "Nome";
                }
                else if (cbPesquisa.SelectedItem.ToString().ToLower() == "data")
                {
                    cbDados.Visible = false;
                    lblDataInicial.Visible = true;
                    lblDataFinal.Visible = true;

                    dtInicial.Visible = true;
                    dtFinal.Visible = true;
                }
                else if (cbPesquisa.SelectedItem.ToString().ToLower() == "profissional")
                {
                    cbDados.Visible = true;
                    lblDataInicial.Visible = false;
                    lblDataFinal.Visible = false;

                    dtInicial.Visible = false;
                    dtFinal.Visible = false;

                    cbDados.DataSource = barbersoftContext.Profissional.OrderBy(p => p.Nome).ToList();
                    cbDados.DisplayMember = "Nome";
                    cbDados.ValueMember = "Nome";
                }
                else if (cbPesquisa.SelectedItem.ToString().ToLower() == "situação")
                {
                    cbDados.Visible = true;
                    lblDataInicial.Visible = false;
                    lblDataFinal.Visible = false;

                    dtInicial.Visible = false;
                    dtFinal.Visible = false;

                    cbDados.DataSource = barbersoftContext.Situacao.OrderBy(s => s.Descricao).ToList();
                    cbDados.DisplayMember = "Descricao";
                    cbDados.ValueMember = "Descricao";
                }
            }
        }
        private void BtnLimpar(object sender, EventArgs e)
        {
            RecebeDadosBanco();

            cbDados.SelectedItem = null;
            cbDados.SelectedText = "Selecione";

            cbPesquisa.SelectedItem = null;
            cbPesquisa.SelectedText = "Selecione";

            cbDados.Visible = true;
            lblDataInicial.Visible = false;
            lblDataFinal.Visible = false;

            dtInicial.Value = DateTime.Today;
            dtFinal.Value = DateTime.Today;

            dtInicial.Visible = false;
            dtFinal.Visible = false;
        }
        private void BtnFechar(object sender, EventArgs e)
        {
            if (dgAtendimento.Rows.Count > 0)
            {
                int id = (int)dgAtendimento.SelectedRows[0].Cells[1].Value;
                string situacao = dgAtendimento.SelectedRows[0].Cells[5].Value.ToString().ToLower().Trim();
                if (situacao.Equals("fechado"))
                {
                    MessageBox.Show("Atendimento já está fechado", "Atenção");
                }
                else if (situacao.Equals("cancelado"))
                {
                    MessageBox.Show("Este atendimento foi cancelado", "Atenção");
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show($"Deseja Finalizar o atendimento N° {id}", "Atenção", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Atendimento_FormaPagamentoForm formaPagamento = new(id);
                        formaPagamento.ShowDialog();
                        RecebeDadosBanco();
                    }
                }
            }
            else
            {
                MessageBox.Show("Não há atendimento para ser finalizado");
            }
        }
        private void BtnCancelar(object sender, EventArgs e)
        {
            if (dgAtendimento.Rows.Count > 0)
            {
                string situacao = (string)dgAtendimento.SelectedRows[0].Cells[5].Value;
                int id = (int)dgAtendimento.SelectedRows[0].Cells[1].Value;
                var query = barbersoftContext.ItemAtendimento.Where(i => i.AtendimentoId == id).ToList();
                if (situacao.ToLower().Equals("cancelado"))
                {
                    MessageBox.Show("Este atendimento já está cancelado", "Atenção");
                }
                else if (situacao.ToLower().Equals("fechado"))
                {
                    MessageBox.Show("Este atendimento está fechado, não é possível cancelar", "Atenção");
                }
                else
                {
                    Logging log = new();
                    if (query.Count > 0)
                    {
                        DialogResult dialog = MessageBox.Show("Este atendimento contém itens adicionados, deseja continuar com o cancelamento ?", "Atenção", MessageBoxButtons.YesNo);
                        if (dialog == DialogResult.Yes)
                        {
                            try
                            {
                                barbersoftContext.Atendimento.FromSqlRaw($"Update Atendimento set SituacaoId = 5 Where Id = {id}");
                                RecebeDadosBanco();
                            }
                            catch (Exception ex)
                            {
                                log.Log(ex);
                                MessageBox.Show("Não foi possível fazer o cancelamento", "Atenção");
                            }
                        }
                    }
                    else
                    {
                        DialogResult dialog = MessageBox.Show("Deseja realmente cancelar este atendimento ?", "Atenção", MessageBoxButtons.YesNo);
                        if (dialog == DialogResult.Yes)
                        {
                            try
                            {
                                barbersoftContext.Atendimento.FromSqlRaw($"Update Atendimento set SituacaoId = 5 Where Id = {id}");
                                RecebeDadosBanco();
                            }
                            catch (Exception ex)
                            {
                                log.Log(ex);
                                MessageBox.Show("Não foi possível fazer o cancelamento", "Atenção");
                            }
                        }
                    }
                }
            } else
            {
                MessageBox.Show("Não há atendimentos para serem cancelados", "Atenção");
            }
        }
    }
}