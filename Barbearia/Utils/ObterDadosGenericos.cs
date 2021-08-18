using Barbearia.Database;
using Barbearia.Log;
using Barbersoft.Models;
using Barbersoft.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Barbersoft.Utils
{
    public class ObterDadosGenericos
    {
        private readonly Logging log;
        public ObterDadosGenericos()
        {
            log = new();
        }
        public List<ContaPagarDTO> RetornaContaPagarFiltrado()
        {
            BarbersoftContext database = new();
            ImageConverter converter = new();
            List<ContaPagarDTO> contaPagar =
                (from a in ObterDados<ContaPagar>()
                 join b in ObterDados<Fornecedor>() on a.FornecedorId equals b.Id
                 join c in ObterDados<Situacao>() on a.SituacaoId equals c.Id
                 select new ContaPagarDTO()
                 {
                     Id = a.Id,
                     Descricao = a.Descricao.ToUpper(),
                     DataLancamento = a.DataLancamento.ToShortDateString(),
                     DataVencimento = a.DataVencimento.ToShortDateString(),
                     Fornecedor = b.Nome.ToUpper(),
                     Situacao = c.Descricao.ToUpper(),
                     Valor = a.Valor
                 }).OrderByDescending(a => a.Id).ToList();
            foreach (ContaPagarDTO dto in contaPagar)
            {
                if (dto.Situacao.ToLower().Equals("aberto"))
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
            }
            return contaPagar;
        }
        public List<ContaReceberDTO> RetornaContaReceberFiltrado()
        {
            BarbersoftContext database = new();
            ImageConverter converter = new();
            List<ContaReceberDTO> contaReceber =
                (from a in ObterDados<ContaReceber>()
                join b in ObterDados<Cliente>() on a.ClienteId equals b.Id
                join c in ObterDados<Situacao>() on a.SituacaoId equals c.Id
                select new ContaReceberDTO()
                {
                    Id = a.Id,
                    Descricao = a.Descricao.ToUpper(),
                    DataLancamento = a.DataLancamento.ToShortDateString(),
                    DataVencimento = a.DataVencimento.ToShortDateString(),
                    Cliente = b.Nome.ToUpper(),
                    Situacao = c.Descricao.ToUpper(),
                    Valor = a.Valor,
                    AtendimentoId = a.AtendimentoId == null ? "S/ Atend.:" : a.AtendimentoId.ToString()
                }).OrderByDescending(a => a.Id).ToList();
            foreach (ContaReceberDTO dto in contaReceber)
            {
                if (dto.Situacao.ToLower().Equals("aberto"))
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
            }
            return contaReceber;
        }
        public List<AtendimentoDTO> ObterDadosAtendimento()
        {
            BarbersoftContext database = new();
            ImageConverter converter = new();
            List<AtendimentoDTO> atendimento =
                (from a in ObterDados<Atendimento>()
                 join b in ObterDados<Cliente>() on a.ClienteId equals b.Id
                 join c in ObterDados<Profissional>() on a.ProfissionalId equals c.Id
                 join d in ObterDados<Situacao>() on a.SituacaoId equals d.Id
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
                decimal valorTotal = ObterDados<ItemAtendimento>().Where(i => i.AtendimentoId == dto.Id).GroupBy(i => i.ValorTotal).Sum(i => i.Key);
                dto.Total += valorTotal.ToString("N2", CultureInfo.CurrentCulture).Replace("R$", "");
            }
            return atendimento;
        }
        public List<AtendimentoFiltro> RetornaAtendimentoFiltros(DateTime dataInicial, DateTime dataFinal)
        {
            List<AtendimentoFiltro> atendimentoFiltro = new();
            try
            {
                atendimentoFiltro = (from a in ObterDados<Atendimento>()
                                     join b in ObterDados<Cliente>() on a.ClienteId equals b.Id
                                     join c in ObterDados<Profissional>() on a.ProfissionalId equals c.Id
                                     join d in ObterDados<Situacao>() on a.SituacaoId equals d.Id
                                     where a.CriadoEm >= dataInicial && a.CriadoEm <= dataFinal.AddDays(1)
                                     select new AtendimentoFiltro()
                                     {
                                         Id = a.Id,
                                         Situacao = d.Descricao.ToUpper(),
                                         Cliente = b.Nome.ToUpper(),
                                         Profissional = c.Nome.ToUpper(),
                                         Data = DateTime.Parse(a.CriadoEm.ToString("dd/MM/yyyy"))
                                     }).OrderByDescending(a => a.Id).ToList();
            }
            catch (Exception ex)
            {
                log.Log(ex);
                MessageBox.Show("Não foi possível obter atendimentos", "Atenção");
            }
            return atendimentoFiltro;
        }
        public List<TEntity> ObterDados<TEntity>() where TEntity : class
        {
            List<TEntity> dados = new();
            BarbersoftContext database = new();
            try
            {
                dados = database.Set<TEntity>().ToList();
            } catch (Exception ex)
            {
                log.Log(ex);
                MessageBox.Show("Não foi possível obter os dados", "Erro");
            }
            return dados;
        }
        public void AdicionaDados<TEntity>(TEntity entidade) where TEntity : class
        {
            BarbersoftContext database = new();
            bool adicionado;
            try
            {
                database.Set<TEntity>().Add(entidade);
                database.SaveChanges();
                adicionado = true;
            }
            catch (Exception ex)
            {
                log.Log(ex);
                adicionado = false;
            }

            if (adicionado == false)
            {
                MessageBox.Show("Não foi possível adicionar Dados", "Aviso");
            }
        }
        public void AtualizaDados<TEntity>(TEntity entidade) where TEntity : class
        {
            bool atualizado;
            BarbersoftContext database = new();
            try
            {
                database.Entry(entidade).State = EntityState.Modified;
                database.Set<TEntity>().Update(entidade);
                database.SaveChanges();
                atualizado = true;
            }
            catch (Exception ex)
            {
                log.Log(ex);
                atualizado = false;
            }

            if (atualizado == false)
            {
                MessageBox.Show("Não foi possível adicionar Dados", "Aviso");
            }
        }
        public void RemoveDados<TEntity>(TEntity entidade) where TEntity : class
        {
            BarbersoftContext database = new();
            bool excluido;
            try
            {
                database.Set<TEntity>().Remove(entidade);
                database.SaveChanges();
                excluido = true;
            }
            catch (Exception ex)
            {
                log.Log(ex);
                excluido = false;
            }
            if (excluido == false)
            {
                MessageBox.Show("Não foi possível adicionar Dados", "Aviso");
            }
        }
    }
}
