using Barbearia.Database;
using Barbearia.Log;
using Barbearia.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Barbearia.Views.FormCrud
{
    public partial class ProfissionalForm : Form
    {
        private readonly bool modoInclusao = false;
        private readonly Models.Profissional _profissional;
        public ProfissionalForm(bool inclusao)
        {
            InitializeComponent();

            modoInclusao = inclusao;
            IniciaCampoDefault();
        }

        public ProfissionalForm(bool inclusao, Models.Profissional profissional)
        {
            InitializeComponent();

            _profissional = ObtemDadosProfissionalPorID(profissional.Id);
            modoInclusao = inclusao;

            IniciaCamposPreenchidos();
        }

        private Models.Profissional ObtemDadosProfissionalPorID(int id)
        {
            BarbersoftContext database = new();
            return database.Profissional.FirstOrDefault(p => p.Id == id);
        }
        private void TxtKeyPressPercent(object sender, KeyPressEventArgs e)
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
        private void TxtKeyDownPercent(object sender, KeyEventArgs e)
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
            if (modoInclusao == true)
            {
                string valorPadrao = "0,00";
                txtPorcentagem.Text = valorPadrao;
            }
        }
        // Serve para o dialog de alteração
        private void IniciaCamposPreenchidos()
        {
            if (modoInclusao != true)
            {
                txtNome.Text = _profissional.Nome;
                txtPorcentagem.Text = string.Format("{0:#,##0.00}", _profissional.Porcentagem);
                txtCPF.Text = Convert.ToUInt64(_profissional.Cpf).ToString(@"000\.000\.000\-00");
                txtCelularTelefone.Text = AplicarMascaraTelefone(_profissional.Celular);
            }
        }
        private string AplicarMascaraTelefone(string strNumero)
        {
            // por omissão tem 10 ou menos dígitos
            string strMascara = "{0:(00)0000-0000}";
            // converter o texto em número
            long lngNumero = Convert.ToInt64(strNumero);

            if (strNumero.Length == 11)
                strMascara = "{0:(00)00000-0000}";

            return string.Format(strMascara, lngNumero);
        }
        private void BtnSair(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnSalvar(object sender, EventArgs e)
        {
            BarbersoftContext database = new();
            Logging log = new();

            Models.Profissional profissional = new()
            {
                Nome = txtNome.Text.ToUpper(),
                Celular = txtCelularTelefone.Text,
                Porcentagem = decimal.Parse(txtPorcentagem.Text),
                Cpf = txtCPF.Text
            };

            if (modoInclusao == true)
            {
                profissional.CriadoPor = Usuario.UsuarioAtivo.Id;
                profissional.CriadoEm = DateTime.Now;
                try
                {
                    if (!string.IsNullOrEmpty(profissional.Nome))
                    {
                        database.Profissional.Add(profissional);
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
                var telefoneCelular = profissional.Celular.Replace("(", "").Replace(")", "").Replace("-", "").Trim();
                var cpf = profissional.Cpf.Replace(".", "").Replace("-", "").Trim();

                profissional.Id = _profissional.Id;
                profissional.CriadoPor = _profissional.CriadoPor;
                profissional.CriadoEm = _profissional.CriadoEm;
                profissional.AlteradoPor = Usuario.UsuarioAtivo.Id;
                profissional.AlteradoEm = DateTime.Now;
                profissional.Celular = telefoneCelular;
                profissional.Cpf = cpf;
                database.Entry(profissional).State = EntityState.Modified;
                database.Entry(profissional).Property(p => p.Id).IsModified = false;
                database.Entry(profissional).Property(p => p.CriadoEm).IsModified = false;
                database.Entry(profissional).Property(p => p.CriadoPor).IsModified = false;
                database.Entry(profissional).Property(p => p.DeletadoEm).IsModified = false;
                database.Entry(profissional).Property(p => p.DeletadoPor).IsModified = false;

                try
                {
                    if (!string.IsNullOrEmpty(profissional.Nome))
                    {
                        database.Profissional.Update(profissional);
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
    }
}
