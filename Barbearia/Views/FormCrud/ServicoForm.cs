using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Barbearia.Database;
using Barbearia.Log;
using Barbearia.Models;
using Microsoft.EntityFrameworkCore;

namespace Barbersoft.Views.FormCrud
{
    public partial class ServicoForm : Form
    {
        private readonly bool modoInclusao = false;
        private readonly Servico _servico;
        public ServicoForm(bool inclusao)
        {
            InitializeComponent();

            modoInclusao = inclusao;
            IniciaCampoDefault();
        }
        public ServicoForm(bool inclusao, Servico servico)
        {
            InitializeComponent();

            modoInclusao = inclusao;
            _servico = servico;

            IniciaCamposPreenchidos();
        }

        private void TxtKeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar.Equals((char)Keys.Back))
            {
                TextBox txt = (TextBox)sender;
                string w = Regex.Replace(txt.Text, "[^0-9]", string.Empty);
                if (w == string.Empty) w = "00";
                if (e.KeyChar.Equals((char)Keys.Back))
                {
                    w = w.Substring(0, w.Length - 1);
                }
                else
                {
                    w += e.KeyChar;
                }
                txt.Text = string.Format("{0:#,##0.00}", Double.Parse(w) / 100);
                txt.Select(txt.Text.Length, 0);
            }
            e.Handled = true;
        }
        private void TxtKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                TextBox t = (TextBox)sender;
                t.Text = string.Format("{0:#.##0.00}", 0d);
                t.Select(t.Text.Length, 0);
                e.Handled = true;
            }
        }

        // Serve para o dialog de inclusão
        private void IniciaCampoDefault()
        {
            string valorPadrao = "0,00";
            txtValorServico.Text = valorPadrao;
        }
        // Serve para o dialog de alteração
        private void IniciaCamposPreenchidos()
        {
            if (modoInclusao != true)
            {
                txtNome.Text = _servico.Nome;
                txtValorServico.Text = string.Format("{0:#,##0.00}", _servico.Valor);
            }
        }
        private void BtnSalvar(object sender, System.EventArgs e)
        {
            BarbersoftContext database = new();
            Logging log = new();
            Servico servico = new()
            {
                Nome = txtNome.Text.ToUpper(),
                Valor = decimal.Parse(txtValorServico.Text),
            };
            if (modoInclusao == true)
            {
                servico.CriadoPor = Usuario.UsuarioAtivo.Id;
                servico.CriadoEm = DateTime.Now;
                servico.Ativo = "S";
                try
                {
                    if (!string.IsNullOrEmpty(servico.Nome))
                    {
                        database.Servico.Add(servico);
                        database.SaveChanges();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("o Campo Nome não pode estar vazio");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível fazer a inclusão, tente novamente mais tarde");
                    log.Log(ex);
                }
            }
            else
            {
                servico.Id = _servico.Id;
                servico.Ativo = _servico.Ativo;
                servico.AtualizadoPor = Usuario.UsuarioAtivo.Id;
                servico.AtualizadoEm = DateTime.Now;
                database.Entry(servico).State = EntityState.Modified;
                database.Entry(servico).Property(p => p.Id).IsModified = false;
                database.Entry(servico).Property(p => p.CriadoPor).IsModified = false;
                database.Entry(servico).Property(p => p.CriadoEm).IsModified = false;
                database.Entry(servico).Property(p => p.DeletadoEm).IsModified = false;
                database.Entry(servico).Property(p => p.DeletadoPor).IsModified = false;
                try
                {
                    if (!string.IsNullOrEmpty(servico.Nome))
                    {
                        database.Servico.Update(servico);
                        database.SaveChanges();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("o Campo Nome não pode estar vazio");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível fazer a alteração, tente novamente mais tarde");
                    log.Log(ex);
                }
            }
        }
        private void BtnSair(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
