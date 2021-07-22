using Barbearia.Database;
using Barbearia.Log;
using Barbersoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Windows.Forms;

namespace Barbersoft.Views.FormCrud
{
    public partial class ClienteForm : Form
    {
        private readonly bool modoInclusao;
        private readonly dynamic _cliente;
        public ClienteForm(bool inclusao)
        {
            InitializeComponent();

            modoInclusao = inclusao;
        }
        public ClienteForm(bool inclusao, dynamic cliente)
        {
            InitializeComponent();

            modoInclusao = inclusao;
            _cliente = cliente;
            IniciaCamposPreenchidos();
        }
        private void IniciaCamposPreenchidos()
        {
            if (modoInclusao != true)
            {
                txtNome.Text = _cliente.Nome;
                txtCelular.Text = _cliente.Celular;
            }
        }
        private void BtnSair(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnSalvar(object sender, EventArgs e)
        {
            BarbersoftContext database = new();
            Logging log = new();
            Cliente cliente = new()
            {
                Nome = txtNome.Text.ToUpper(),
                Celular = txtCelular.Text
            };
            if (modoInclusao)
            {
                cliente.CriadoEm = DateTime.Now;
                cliente.CriadoPor = Usuario.UsuarioAtivo.Id;
                cliente.Ativo = "S";

                try
                {
                    if (!string.IsNullOrEmpty(cliente.Nome) && !string.IsNullOrEmpty(cliente.Celular))
                    {
                        database.Cliente.Add(cliente);
                        database.SaveChanges();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("o Campo Nome e Celular devem estar preenchidos");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível fazer a inclusão, tente novamente mais tarde");
                    log.Log(ex);
                }
            } else
            {
                cliente.Id = _cliente.Id;
                cliente.Ativo = _cliente.Ativo;
                cliente.AlteradoPor = Usuario.UsuarioAtivo.Id;
                cliente.AlteradoEm = DateTime.Now;
                database.Entry(cliente).State = EntityState.Modified;
                database.Entry(cliente).Property(p => p.Id).IsModified = false;
                database.Entry(cliente).Property(p => p.CriadoPor).IsModified = false;
                database.Entry(cliente).Property(p => p.CriadoEm).IsModified = false;
                database.Entry(cliente).Property(p => p.DeletadoEm).IsModified = false;
                database.Entry(cliente).Property(p => p.DeletadoPor).IsModified = false;
                try
                {
                    if (!string.IsNullOrEmpty(cliente.Nome) && !string.IsNullOrEmpty(cliente.Celular))
                    {
                        database.Cliente.Update(cliente);
                        database.SaveChanges();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("o Campo Nome e Celular devem estar preenchidos");
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
