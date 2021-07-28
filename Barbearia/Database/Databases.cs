using Barbearia.Interface;
using Barbearia.Log;
using Barbersoft.Models;
using Barbersoft.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            barbersoftContext = new();
            log = new();
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
        public bool AutenticacaoGestor(string login, string senha)
        {
            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(senha))
            {
                try
                {
                    var usuario = barbersoftContext.Usuario.FirstOrDefault(u => u.Login == login && u.Senha == senha && u.SuperUser == "S");

                    if (usuario == null)
                    {
                        MessageBox.Show("Usuário inexistente");
                        return false;
                    }
                    else if (usuario.Login == login && usuario.Senha != senha)
                    {
                        MessageBox.Show("Senha incorreta");
                        return false;
                    }
                    else if (usuario.Login != login && usuario.Senha == senha)
                    {
                        MessageBox.Show("Senha incorreta");
                        return false;
                    }
                    Usuario.UsuarioGestorAtivo = usuario;
                    return true;
                }
                catch (Exception ex)
                {
                    log.Log(ex);
                    return false;
                }
            }
            else
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
                log.Log(ex);
                return false;
            }
        }        
        public bool MudaSituacaoAtendimento(Atendimento atendimento)
        {
            try
            {
                if (atendimento != null)
                {
                    barbersoftContext.Entry(atendimento).State = EntityState.Modified;
                    barbersoftContext.Atendimento.Update(atendimento);
                    barbersoftContext.SaveChanges();
                    return true;
                } else
                {
                    return false;
                }
            } catch (Exception ex)
            {
                log.Log(ex);
                return false;
            }
        }
        public List<AtendimentoFiltro> RetornaAtendimentoFiltros()
        {
            List<AtendimentoFiltro> atendimentoFiltro = new();
            try
            {
                atendimentoFiltro = (from a in barbersoftContext.Atendimento
                        join b in barbersoftContext.Cliente on a.ClienteId equals b.Id
                        join c in barbersoftContext.Profissional on a.ProfissionalId equals c.Id
                        join d in barbersoftContext.Situacao on a.SituacaoId equals d.Id
                        select new AtendimentoFiltro()
                        {
                            Id = a.Id,
                            Situacao = d.Descricao.ToUpper(),
                            Cliente = b.Nome.ToUpper(),
                            Profissional = c.Nome.ToUpper(),
                            Data = DateTime.Parse(a.CriadoEm.ToString("dd/MM/yyyy"))
                        }).OrderByDescending(a => a.Id).ToList();
            } catch (Exception ex)
            {
                log.Log(ex);
                MessageBox.Show("Não foi possível obter atendimentos", "Atenção");
            }
            return atendimentoFiltro;
        }
    }
}