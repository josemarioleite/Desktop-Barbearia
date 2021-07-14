using Barbearia.Database;
using Barbearia.Log;
using Barbearia.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Barbearia.Views.FormProduto
{
    public partial class Produto : Form
    {
        private readonly bool modoInclusao = false;
        private readonly Models.Produto _produto;
        public Produto(bool inclusao)
        {
            InitializeComponent();

            modoInclusao = inclusao;
            IniciaCampoDefault();
        }
        public Produto(bool inclusao, Models.Produto produto)
        {
            InitializeComponent();

            modoInclusao = inclusao;
            _produto = produto;

            IniciaCamposPreenchidos();
        }

        private void BtnSair(object sender, System.EventArgs e)
        {
            this.Close();
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
            txtValorPorcentagemComissao.Text = valorPadrao;
            txtValorProduto.Text = valorPadrao;
        }


        // Serve para o dialog de alteração
        private void IniciaCamposPreenchidos()
        {
            if (modoInclusao != true)
            {
                txtNome.Text = _produto.Nome;
                txtValorProduto.Text = string.Format("{0:#,##0.00}", _produto.Valor);
                txtValorPorcentagemComissao.Text = string.Format("{0:#,##0.00}", _produto.ValorComissaoPorcentagem);
                if (_produto.ComissaoPorcentagem == "C")
                {
                    rdComissao.Checked = true;
                } else
                {
                    rdPorcentagem.Checked = true;
                }
            }
        }
        private void BtnSalvar(object sender, EventArgs e)
        {
            BarbersoftContext database = new();
            Logging log = new();
            string comissaoPorcentagem = "";

            if (rdComissao.Checked == true)
            {
                comissaoPorcentagem = "C";
            }
            else if (rdPorcentagem.Checked == true)
            {
                comissaoPorcentagem = "P";
            }

            Models.Produto produto = new()
            {
                Nome = txtNome.Text.ToUpper(),
                ComissaoPorcentagem = comissaoPorcentagem,
                Valor = decimal.Parse(txtValorProduto.Text),
                ValorComissaoPorcentagem = decimal.Parse(txtValorPorcentagemComissao.Text),
            };

            if (modoInclusao == true)
            {
                produto.CriadoPor = Usuario.UsuarioAtivo.Id;
                produto.CriadoEm = DateTime.Now;
                produto.Ativo = "S";
                try
                {
                    if (!string.IsNullOrEmpty(produto.Nome))
                    {
                        database.Produto.Add(produto);
                        database.SaveChanges();
                        this.Close();
                    } else
                    {
                        MessageBox.Show("o Campo Nome não pode estar vazio");
                    }
                } catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível fazer a inclusão, tente novamente mais tarde");
                    log.Log(ex);
                }
            } else
            {
                produto.Id = _produto.Id;
                produto.AtualizadoPor = Usuario.UsuarioAtivo.Id;
                produto.AtualizadoEm = DateTime.Now;
                produto.Ativo = _produto.Ativo;
                database.Entry(produto).State = EntityState.Modified;
                database.Entry(produto).Property(p => p.Id).IsModified = false;
                database.Entry(produto).Property(p => p.CriadoEm).IsModified = false;
                database.Entry(produto).Property(p => p.CriadoPor).IsModified = false;
                database.Entry(produto).Property(p => p.DeletadoEm).IsModified = false;
                database.Entry(produto).Property(p => p.DeletadoPor).IsModified = false;
                database.Entry(produto).Property(p => p.Ativo).IsModified = false;
                try
                {
                    if (!string.IsNullOrEmpty(produto.Nome))
                    {
                        database.Produto.Update(produto);
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
