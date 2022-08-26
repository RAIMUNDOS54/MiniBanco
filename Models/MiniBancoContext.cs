using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MiniBanco.Models
{
    public partial class MiniBancoContext : DbContext
    {
        public MiniBancoContext()
        {
        }

        public MiniBancoContext(DbContextOptions<MiniBancoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ContasApagar> ContasApagars { get; set; } = null!;
        public virtual DbSet<ContasPaga> ContasPagas { get; set; } = null!;
        public virtual DbSet<Pessoa> Pessoas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=MiniBanco;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContasApagar>(entity =>
            {
                entity.HasKey(e => e.Numero);

                entity.ToTable("ContasAPagar");

                entity.Property(e => e.Acrescimo).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.DataProrrogacao).HasColumnType("date");

                entity.Property(e => e.DataVencimento).HasColumnType("date");

                entity.Property(e => e.Desconto).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Valor).HasColumnType("numeric(18, 6)");

                entity.HasOne(d => d.CodigoFornecedorNavigation)
                    .WithMany(p => p.ContasAPagar)
                    .HasForeignKey(d => d.CodigoFornecedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContasAPagar_ContasAPagar");
            });

            modelBuilder.Entity<ContasPaga>(entity =>
            {
                entity.HasKey(e => e.Numero);

                entity.Property(e => e.Acrescimo).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.DataPagamento).HasColumnType("date");

                entity.Property(e => e.DataVencimento).HasColumnType("date");

                entity.Property(e => e.Desconto).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Valor).HasColumnType("numeric(18, 6)");

                entity.HasOne(d => d.CodigoFornecedorNavigation)
                    .WithMany(p => p.ContasPagas)
                    .HasForeignKey(d => d.CodigoFornecedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContasPagas_Pessoas");
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.Property(e => e.Cpfcnpj)
                    .HasMaxLength(16)
                    .HasColumnName("CPFCNPJ");

                entity.Property(e => e.DataNascimento).HasColumnType("date");

                entity.Property(e => e.Nome).HasMaxLength(255);

                entity.Property(e => e.Uf)
                    .HasMaxLength(2)
                    .HasColumnName("UF");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
