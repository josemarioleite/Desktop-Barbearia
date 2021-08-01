using Barbearia.Database;
using Barbearia.Log;
using Barbearia.Views;
using Barbersoft.Enum;
using Barbersoft.Models;
using Barbersoft.Utils;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Barbersoft.Views.FormCrud
{
    public partial class formAtendimento : Form
    {
        private readonly bool modoInclusao;
        private readonly ObterDadosGenericos dados;
        public formAtendimento(bool inclusao)
        {
            InitializeComponent();

            modoInclusao = inclusao;
            dados = new();
        }
        private void CamposPreenchidos()
        {
            BarbersoftContext database = new();
            if (modoInclusao == true)
            {
                cbCliente.DataSource = database.Cliente.ToList();
                cbProfissional.DataSource = database.Profissional.ToList();
                dtData.Text = DateTime.Now.ToString();

                cbProfissional.ValueMember = "Id";
                cbCliente.ValueMember = "Id";

                cbCliente.DisplayMember = "Nome";
                cbProfissional.DisplayMember = "Nome";
            }
        }
        private void BtnSalvar(object sender, EventArgs e)
        {
            Logging log = new();
            if (modoInclusao == true)
            {
                Atendimento atendimento = new()
                {
                    ClienteId = (int)cbCliente.SelectedValue,
                    ProfissionalId = (int)cbProfissional.SelectedValue
                };
                atendimento.CriadoEm = DateTime.Now;
                atendimento.CriadoPor = Usuario.UsuarioAtivo.Id;
                atendimento.Ativo = "S";
                atendimento.SituacaoId = (int)SituacaoEnum.Aberto;
                try
                {
                    if (atendimento.ClienteId > 0 && atendimento.ProfissionalId > 0)
                    {
                        dados.AdicionaDados(atendimento);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("o Campo Cliente e Profissional devem estar preenchidos");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível fazer a inclusão, tente novamente mais tarde");
                    log.Log(ex);
                }
            }
        }
        private void BtnSair(object sender, EventArgs e)
        {
            this.Close();
        }
        private void AtendimentoLoad(object sender, EventArgs e)
        {
            CamposPreenchidos();
            if (modoInclusao == true)
            {
                cbSituacao.Visible = false;
                linhaSituacao.Visible = false;
                lblSituacao.Visible = false;

                lblData.Visible = false;
                linhaData.Visible = false;
                dtData.Visible = false;
            }
            this.KeyPreview = true;
        }
        private void Atendimento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.Shift == true && e.KeyCode == Keys.C)
            {
                ClienteView cliente = new();
                cliente.ShowDialog();
            }

            if (e.Control == true && e.Shift == true && e.KeyCode == Keys.P)
            {
                ProfissionalView profissional = new();
                profissional.ShowDialog();
            }
            CamposPreenchidos();
        }
    }
}
