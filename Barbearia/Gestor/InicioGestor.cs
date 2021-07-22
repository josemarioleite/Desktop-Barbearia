using Barbersoft.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barbersoft.Gestor
{
    public partial class InicioGestor : Form
    {
        public InicioGestor()
        {
            InitializeComponent();
        }
        private void BtnUsuario(object sender, EventArgs e)
        {
            UsuarioGestor usuario = new();
            usuario.ShowDialog();
        }
        private void BtnSair(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Gestor_Closing(object sender, FormClosingEventArgs e)
        {
            Usuario.UsuarioGestorAtivo = null;
        }
    }
}
