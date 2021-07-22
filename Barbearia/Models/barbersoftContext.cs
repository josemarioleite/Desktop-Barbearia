using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Barbersoft.Models
{
    public partial class barbersoftContext : DbContext
    {
        public barbersoftContext()
        {
        }

        public barbersoftContext(DbContextOptions<barbersoftContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Atendimento> Atendimentos { get; set; }
        public virtual DbSet<Caixa> Caixas { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<EntradaProduto> EntradaProdutos { get; set; }
        public virtual DbSet<EstoqueProduto> EstoqueProdutos { get; set; }
        public virtual DbSet<FormaPagamento> FormaPagamentos { get; set; }
        public virtual DbSet<ItemAtendimento> ItemAtendimentos { get; set; }
        public virtual DbSet<ItemFormaPagamento> ItemFormaPagamentos { get; set; }
        public virtual DbSet<PeriodoCaixa> PeriodoCaixas { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Profissional> Profissionals { get; set; }
        public virtual DbSet<Servico> Servicos { get; set; }
        public virtual DbSet<Situacao> Situacaos { get; set; }
        public virtual DbSet<SituacaoAtendimento> SituacaoAtendimentos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;database=barbersoft;user=empresa;pwd=BARBERsoft2020", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.23-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<Atendimento>(entity =>
            {
                entity.ToTable("atendimento");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.AlteradoEm).HasColumnType("timestamp");

                entity.Property(e => e.Ativo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'S'");

                entity.Property(e => e.CriadoEm)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DeletadoEm).HasColumnType("timestamp");
            });

            modelBuilder.Entity<Caixa>(entity =>
            {
                entity.ToTable("caixa");

                entity.Property(e => e.Ativo)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.AtualizadoEm).HasColumnType("datetime");

                entity.Property(e => e.CaixaAberto)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.CriadoEm).HasColumnType("datetime");

                entity.Property(e => e.DeletadoEm).HasColumnType("datetime");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("cliente");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.AlteradoEm).HasColumnType("timestamp");

                entity.Property(e => e.Ativo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'S'");

                entity.Property(e => e.Celular)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.CriadoEm)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DeletadoEm).HasColumnType("timestamp");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.ToTable("empresa");

                entity.Property(e => e.Ativo)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.AtualizadoEm).HasColumnType("datetime");

                entity.Property(e => e.CnpjCpf)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("CNPJ_CPF");

                entity.Property(e => e.CriadoEm).HasColumnType("datetime");

                entity.Property(e => e.DeletadoEm).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.TelefoneCelular)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<EntradaProduto>(entity =>
            {
                entity.ToTable("entrada_produto");

                entity.HasIndex(e => e.IdProduto, "Produto_idx");

                entity.Property(e => e.AlteradoEm).HasColumnType("datetime");

                entity.Property(e => e.Ativo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'S'");

                entity.Property(e => e.CanceladoEm).HasColumnType("datetime");

                entity.Property(e => e.CriadoEm)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Data)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.IdProduto).HasColumnName("Id_Produto");

                entity.Property(e => e.Quantidade).HasPrecision(10, 2);

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.EntradaProdutos)
                    .HasForeignKey(d => d.IdProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Produto");
            });

            modelBuilder.Entity<EstoqueProduto>(entity =>
            {
                entity.ToTable("estoque_produto");

                entity.Property(e => e.DataAtualizacao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.IdProduto).HasColumnName("Id_Produto");

                entity.Property(e => e.Quantidade).HasPrecision(10, 2);
            });

            modelBuilder.Entity<FormaPagamento>(entity =>
            {
                entity.ToTable("forma_pagamento");

                entity.Property(e => e.AtualizadoEm).HasColumnType("datetime");

                entity.Property(e => e.CriadoEm).HasColumnType("datetime");

                entity.Property(e => e.DeletadoEm).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(5);
            });

            modelBuilder.Entity<ItemAtendimento>(entity =>
            {
                entity.ToTable("item_atendimento");

                entity.Property(e => e.AtualizadoEm).HasColumnType("datetime");

                entity.Property(e => e.CriadoEm).HasColumnType("datetime");

                entity.Property(e => e.DeletadoEm).HasColumnType("datetime");

                entity.Property(e => e.Quantidade).HasPrecision(10);

                entity.Property(e => e.TipoItem)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.ValorTotal).HasPrecision(10);

                entity.Property(e => e.ValorUnitario).HasPrecision(10);
            });

            modelBuilder.Entity<ItemFormaPagamento>(entity =>
            {
                entity.ToTable("item_forma_pagamento");

                entity.Property(e => e.AtualizadoEm).HasColumnType("datetime");

                entity.Property(e => e.CriadoEm).HasColumnType("datetime");

                entity.Property(e => e.DeletadoEm).HasColumnType("datetime");

                entity.Property(e => e.Valor).HasPrecision(10);
            });

            modelBuilder.Entity<PeriodoCaixa>(entity =>
            {
                entity.ToTable("periodo_caixa");

                entity.Property(e => e.AtualizadoEm).HasColumnType("datetime");

                entity.Property(e => e.CriadoEm).HasColumnType("datetime");

                entity.Property(e => e.DataAbertura).HasColumnType("datetime");

                entity.Property(e => e.DataFechamento).HasColumnType("datetime");

                entity.Property(e => e.DeletadoEm).HasColumnType("datetime");

                entity.Property(e => e.Observacao).HasMaxLength(50);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.ValorPeriodo).HasPrecision(10);

                entity.Property(e => e.ValorSaldo).HasPrecision(10);

                entity.Property(e => e.ValorSangria).HasPrecision(10);

                entity.Property(e => e.ValorTroco).HasPrecision(10);
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.ToTable("produto");

                entity.HasIndex(e => e.Nome, "Nome_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Ativo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'S'");

                entity.Property(e => e.AtualizadoEm).HasColumnType("datetime");

                entity.Property(e => e.ComissaoPorcentagem)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'C'");

                entity.Property(e => e.CriadoEm)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DeletadoEm).HasColumnType("datetime");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Valor).HasPrecision(10, 2);

                entity.Property(e => e.ValorComissaoPorcentagem).HasPrecision(10, 2);
            });

            modelBuilder.Entity<Profissional>(entity =>
            {
                entity.ToTable("profissional");

                entity.Property(e => e.AlteradoEm).HasColumnType("timestamp");

                entity.Property(e => e.Celular)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("CPF");

                entity.Property(e => e.CriadoEm)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DeletadoEm).HasColumnType("timestamp");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Porcentagem).HasPrecision(10, 2);
            });

            modelBuilder.Entity<Servico>(entity =>
            {
                entity.ToTable("servico");

                entity.Property(e => e.Ativo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'S'");

                entity.Property(e => e.AtualizadoEm).HasColumnType("datetime");

                entity.Property(e => e.CriadoEm)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DeletadoEm).HasColumnType("datetime");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Valor).HasPrecision(10, 2);
            });

            modelBuilder.Entity<Situacao>(entity =>
            {
                entity.ToTable("situacao");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.AlteradoEm).HasColumnType("timestamp");

                entity.Property(e => e.CriadoEm).HasColumnType("timestamp");

                entity.Property(e => e.DeletadoEm).HasColumnType("timestamp");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<SituacaoAtendimento>(entity =>
            {
                entity.ToTable("situacao_atendimento");

                entity.Property(e => e.AtualizadoEm).HasColumnType("datetime");

                entity.Property(e => e.CriadoEm).HasColumnType("datetime");

                entity.Property(e => e.DeletadoEm).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario");

                entity.HasIndex(e => e.Login, "Login_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Administrador)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'S'");

                entity.Property(e => e.Ativo)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'S'");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.PrimeiroAcesso)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'S'");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.SuperUser)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'S'");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
