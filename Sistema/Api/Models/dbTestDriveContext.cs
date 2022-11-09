using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Api.Models
{
    public partial class dbTestDriveContext : DbContext
    {
        public dbTestDriveContext()
        {
        }

        public dbTestDriveContext(DbContextOptions<dbTestDriveContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbAvaliacao> TbAvaliacaos { get; set; } = null!;
        public virtual DbSet<TbCambio> TbCambios { get; set; } = null!;
        public virtual DbSet<TbCarro> TbCarros { get; set; } = null!;
        public virtual DbSet<TbCliente> TbClientes { get; set; } = null!;
        public virtual DbSet<TbCombustivel> TbCombustivels { get; set; } = null!;
        public virtual DbSet<TbFabricante> TbFabricantes { get; set; } = null!;
        public virtual DbSet<TbFeedback> TbFeedbacks { get; set; } = null!;
        public virtual DbSet<TbModelo> TbModelos { get; set; } = null!;
        public virtual DbSet<TbNivelAcesso> TbNivelAcessos { get; set; } = null!;
        public virtual DbSet<TbTestDrive> TbTestDrives { get; set; } = null!;
        public virtual DbSet<TbUsuario> TbUsuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("host=localhost;user=root;password=12345;database=dbTestDrive", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.26-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<TbAvaliacao>(entity =>
            {
                entity.HasKey(e => e.IdAvaliacao)
                    .HasName("PRIMARY");

                entity.ToTable("tb_avaliacao");

                entity.Property(e => e.IdAvaliacao).HasColumnName("id_avaliacao");

                entity.Property(e => e.VlFeedback)
                    .HasPrecision(15, 2)
                    .HasColumnName("vl_feedback");
            });

            modelBuilder.Entity<TbCambio>(entity =>
            {
                entity.HasKey(e => e.IdCambio)
                    .HasName("PRIMARY");

                entity.ToTable("tb_cambio");

                entity.Property(e => e.IdCambio).HasColumnName("id_cambio");

                entity.Property(e => e.DsCambio)
                    .HasMaxLength(45)
                    .HasColumnName("ds_cambio");
            });

            modelBuilder.Entity<TbCarro>(entity =>
            {
                entity.HasKey(e => e.IdCarro)
                    .HasName("PRIMARY");

                entity.ToTable("tb_carros");

                entity.HasIndex(e => e.IdCambio, "id_cambio");

                entity.HasIndex(e => e.IdCombustivel, "id_combustivel");

                entity.HasIndex(e => e.IdFabricante, "id_fabricante");

                entity.HasIndex(e => e.IdModelo, "id_modelo");

                entity.Property(e => e.IdCarro).HasColumnName("id_carro");

                entity.Property(e => e.DsPotencia)
                    .HasMaxLength(100)
                    .HasColumnName("ds_potencia");

                entity.Property(e => e.DtAnoFabricacao)
                    .HasColumnType("datetime")
                    .HasColumnName("dt_ano_fabricacao");

                entity.Property(e => e.DtAnoModelo)
                    .HasColumnType("datetime")
                    .HasColumnName("dt_ano_modelo");

                entity.Property(e => e.IdCambio).HasColumnName("id_cambio");

                entity.Property(e => e.IdCombustivel).HasColumnName("id_combustivel");

                entity.Property(e => e.IdFabricante).HasColumnName("id_fabricante");

                entity.Property(e => e.IdModelo).HasColumnName("id_modelo");

                entity.Property(e => e.NmCarro)
                    .HasMaxLength(150)
                    .HasColumnName("nm_carro");

                entity.Property(e => e.VlPreco)
                    .HasPrecision(15, 2)
                    .HasColumnName("vl_preco");

                entity.HasOne(d => d.IdCambioNavigation)
                    .WithMany(p => p.TbCarros)
                    .HasForeignKey(d => d.IdCambio)
                    .HasConstraintName("tb_carros_ibfk_3");

                entity.HasOne(d => d.IdCombustivelNavigation)
                    .WithMany(p => p.TbCarros)
                    .HasForeignKey(d => d.IdCombustivel)
                    .HasConstraintName("tb_carros_ibfk_4");

                entity.HasOne(d => d.IdFabricanteNavigation)
                    .WithMany(p => p.TbCarros)
                    .HasForeignKey(d => d.IdFabricante)
                    .HasConstraintName("tb_carros_ibfk_2");

                entity.HasOne(d => d.IdModeloNavigation)
                    .WithMany(p => p.TbCarros)
                    .HasForeignKey(d => d.IdModelo)
                    .HasConstraintName("tb_carros_ibfk_1");
            });

            modelBuilder.Entity<TbCliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PRIMARY");

                entity.ToTable("tb_clientes");

                entity.HasIndex(e => e.IdUsuario, "id_usuario");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.DsEndereco)
                    .HasMaxLength(100)
                    .HasColumnName("ds_endereco");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.NmCliente)
                    .HasMaxLength(100)
                    .HasColumnName("nm_cliente");

                entity.Property(e => e.NrCelular)
                    .HasMaxLength(20)
                    .HasColumnName("nr_celular");

                entity.Property(e => e.NrCnh)
                    .HasMaxLength(30)
                    .HasColumnName("nr_cnh");

                entity.Property(e => e.NrCpf)
                    .HasMaxLength(20)
                    .HasColumnName("nr_cpf");

                entity.Property(e => e.NrRg)
                    .HasMaxLength(20)
                    .HasColumnName("nr_rg");

                entity.Property(e => e.NrTelefone)
                    .HasMaxLength(20)
                    .HasColumnName("nr_telefone");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.TbClientes)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("tb_clientes_ibfk_1");
            });

            modelBuilder.Entity<TbCombustivel>(entity =>
            {
                entity.HasKey(e => e.IdCombustivel)
                    .HasName("PRIMARY");

                entity.ToTable("tb_combustivel");

                entity.Property(e => e.IdCombustivel).HasColumnName("id_combustivel");

                entity.Property(e => e.DsCombustivel)
                    .HasMaxLength(100)
                    .HasColumnName("ds_combustivel");
            });

            modelBuilder.Entity<TbFabricante>(entity =>
            {
                entity.HasKey(e => e.IdFabricante)
                    .HasName("PRIMARY");

                entity.ToTable("tb_fabricante");

                entity.Property(e => e.IdFabricante).HasColumnName("id_fabricante");

                entity.Property(e => e.DsFabricante)
                    .HasMaxLength(100)
                    .HasColumnName("ds_fabricante");
            });

            modelBuilder.Entity<TbFeedback>(entity =>
            {
                entity.HasKey(e => e.IdFeedback)
                    .HasName("PRIMARY");

                entity.ToTable("tb_feedback");

                entity.HasIndex(e => e.IdAvaliacao, "id_avaliacao");

                entity.HasIndex(e => e.IdUsuario, "id_usuario");

                entity.Property(e => e.IdFeedback).HasColumnName("id_feedback");

                entity.Property(e => e.DsFeedback)
                    .HasMaxLength(500)
                    .HasColumnName("ds_feedback");

                entity.Property(e => e.DtFeedback)
                    .HasColumnType("datetime")
                    .HasColumnName("dt_feedback");

                entity.Property(e => e.DtUltimaAlteracao)
                    .HasColumnType("datetime")
                    .HasColumnName("dt_ultima_alteracao");

                entity.Property(e => e.IdAvaliacao).HasColumnName("id_avaliacao");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.HasOne(d => d.IdAvaliacaoNavigation)
                    .WithMany(p => p.TbFeedbacks)
                    .HasForeignKey(d => d.IdAvaliacao)
                    .HasConstraintName("tb_feedback_ibfk_1");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.TbFeedbacks)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("tb_feedback_ibfk_2");
            });

            modelBuilder.Entity<TbModelo>(entity =>
            {
                entity.HasKey(e => e.IdModelo)
                    .HasName("PRIMARY");

                entity.ToTable("tb_modelo");

                entity.Property(e => e.IdModelo).HasColumnName("id_modelo");

                entity.Property(e => e.DsModelo)
                    .HasMaxLength(100)
                    .HasColumnName("ds_modelo");
            });

            modelBuilder.Entity<TbNivelAcesso>(entity =>
            {
                entity.HasKey(e => e.IdNivelAcesso)
                    .HasName("PRIMARY");

                entity.ToTable("tb_nivel_acesso");

                entity.Property(e => e.IdNivelAcesso).HasColumnName("id_nivel_acesso");

                entity.Property(e => e.DsNivel)
                    .HasMaxLength(100)
                    .HasColumnName("ds_nivel");
            });

            modelBuilder.Entity<TbTestDrive>(entity =>
            {
                entity.HasKey(e => e.IdTestDrive)
                    .HasName("PRIMARY");

                entity.ToTable("tb_test_drive");

                entity.HasIndex(e => e.IdCarro, "id_carro");

                entity.HasIndex(e => e.IdCliente, "id_cliente");

                entity.Property(e => e.IdTestDrive).HasColumnName("id_test_drive");

                entity.Property(e => e.BlDesmarcado).HasColumnName("bl_desmarcado");

                entity.Property(e => e.BlRealizado).HasColumnName("bl_realizado");

                entity.Property(e => e.DtTestDrive)
                    .HasColumnType("datetime")
                    .HasColumnName("dt_test_drive");

                entity.Property(e => e.IdCarro).HasColumnName("id_carro");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.HasOne(d => d.IdCarroNavigation)
                    .WithMany(p => p.TbTestDrives)
                    .HasForeignKey(d => d.IdCarro)
                    .HasConstraintName("tb_test_drive_ibfk_2");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.TbTestDrives)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("tb_test_drive_ibfk_1");
            });

            modelBuilder.Entity<TbUsuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PRIMARY");

                entity.ToTable("tb_usuario");

                entity.HasIndex(e => e.IdNivelAcesso, "id_nivel_acesso");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.DsEmail)
                    .HasMaxLength(100)
                    .HasColumnName("ds_email");

                entity.Property(e => e.DsSenha)
                    .HasMaxLength(30)
                    .HasColumnName("ds_senha");

                entity.Property(e => e.DtContaAtualizada)
                    .HasColumnType("datetime")
                    .HasColumnName("dt_conta_atualizada");

                entity.Property(e => e.DtContaCriada)
                    .HasColumnType("datetime")
                    .HasColumnName("dt_conta_criada");

                entity.Property(e => e.DtNascimento)
                    .HasColumnType("datetime")
                    .HasColumnName("dt_nascimento");

                entity.Property(e => e.DtUltimoLogin)
                    .HasColumnType("datetime")
                    .HasColumnName("dt_ultimo_login");

                entity.Property(e => e.IdNivelAcesso).HasColumnName("id_nivel_acesso");

                entity.Property(e => e.NmUsuario)
                    .HasMaxLength(100)
                    .HasColumnName("nm_usuario");

                entity.HasOne(d => d.IdNivelAcessoNavigation)
                    .WithMany(p => p.TbUsuarios)
                    .HasForeignKey(d => d.IdNivelAcesso)
                    .HasConstraintName("tb_usuario_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
