using Barbersoft.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Barbearia.Database
{
    public partial class BarbersoftContext : DbContext
    {
        public BarbersoftContext()
        {
        }

        public BarbersoftContext(DbContextOptions<BarbersoftContext> options) : base(options) {}

        public virtual DbSet<Atendimento> Atendimento { get; set; }
        public virtual DbSet<ItemAtendimento> ItemAtendimento { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<EntradaProduto> EntradaProduto { get; set; }
        public virtual DbSet<EstoqueProduto> EstoqueProduto { get; set; }
        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<Profissional> Profissional { get; set; }
        public virtual DbSet<Servico> Servico { get; set; }
        public virtual DbSet<Situacao> Situacao { get; set; }
        public virtual DbSet<FormaPagamento> FormaPagamento { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<ItemFormaPagamento> ItemFormaPagamento { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connString = ConfigurationManager.ConnectionStrings["conexaoBanco"].ConnectionString;
                optionsBuilder.UseMySql(connString, ServerVersion.Parse("8.0.23-mysql"));
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
            modelBuilder.Entity<ItemAtendimento>(entity => 
            {
                entity.ToTable("item_atendimento");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.CriadoEm)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.AtualizadoEm).HasColumnType("timestamp");
                entity.Property(e => e.DeletadoEm).HasColumnType("timestamp");
            });
            modelBuilder.Entity<ItemFormaPagamento>(entity =>
            {
                entity.ToTable("item_forma_pagamento");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.CriadoEm)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.AtualizadoEm).HasColumnType("timestamp");
                entity.Property(e => e.DeletadoEm).HasColumnType("timestamp");
            });
            modelBuilder.Entity<FormaPagamento>(entity =>
            {
                entity.ToTable("forma_pagamento");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.CriadoEm)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.AtualizadoEm).HasColumnType("timestamp");
                entity.Property(e => e.DeletadoEm).HasColumnType("timestamp");
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
