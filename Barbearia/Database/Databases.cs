using Barbearia.Interface;
using Barbearia.Log;
using Barbearia.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Barbearia.Database
{
    public class Databases : IAutenticacao
    {
        private readonly BarbersoftContext barbersoftContext;
        private readonly Logging log;
        public Databases()
        {
            barbersoftContext = new BarbersoftContext();
            log = new Logging();
        }

        public bool Autenticacao(string login, string senha)
        {
            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(senha))
            {
                try
                {
                    var usuario = barbersoftContext.Usuario.FirstOrDefault(u => u.Login == login && u.Senha == senha);

                    if (usuario == null)
                    {
                        MessageBox.Show("Login ou Senha incorreto, tente novamente");
                        return false;
                    }

                    Usuario.UsuarioAtivo = usuario;
                    return true;
                } catch (Exception ex)
                {
                    log.Log(ex);
                    return false;
                }
            } else
            {
                MessageBox.Show("Preencha todos os campos");
                return false;
            }
        }

        public bool ExisteConexao()
        {
            try
            {
                bool conectado = barbersoftContext.Database.CanConnect();

                if (conectado)
                {
                    return true;
                } else
                {
                    return false;
                }
            } catch (Exception ex)
            {
                return false;
                log.Log(ex);
            }
        }        
    }
}