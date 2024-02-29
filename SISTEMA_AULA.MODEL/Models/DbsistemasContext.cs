using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SISTEMA_AULA.MODEL.Models;

public partial class DbsistemasContext : DbContext
{
    public DbsistemasContext()
    {
    }

    public DbsistemasContext(DbContextOptions<DbsistemasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Configuracao> Configuracaos { get; set; }

    public virtual DbSet<Endereco> Enderecos { get; set; }

    public virtual DbSet<EntradaProduto> EntradaProdutos { get; set; }

    public virtual DbSet<Entradum> Entrada { get; set; }

    public virtual DbSet<Parcela> Parcelas { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    public virtual DbSet<TipoPagamento> TipoPagamentos { get; set; }

    public virtual DbSet<TipoProduto> TipoProdutos { get; set; }

    public virtual DbSet<Unidade> Unidades { get; set; }

    public virtual DbSet<Vendum> Venda { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=DBSISTEMAS;Trusted_Connection=True;trustservercertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.CliCodigo);

            entity.ToTable("CLIENTE");

            entity.Property(e => e.CliCpfcnpj)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CliCPFCNPJ");
            entity.Property(e => e.CliDataCadastro).HasColumnType("datetime");
            entity.Property(e => e.CliDataNascimento).HasColumnType("datetime");
            entity.Property(e => e.CliEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CliNome)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CliNomeMae)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CliSexo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CliTelefone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Configuracao>(entity =>
        {
            entity.HasKey(e => e.CfgCodigo);

            entity.ToTable("CONFIGURACAO");

            entity.Property(e => e.CfgCodigo).ValueGeneratedNever();
            entity.Property(e => e.CfgAcrescimoCartao).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CfgDescontoAvista)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("CfgDescontoAVista");
            entity.Property(e => e.CfgMargemLucro).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CfgUsuarioAlteracao)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Endereco>(entity =>
        {
            entity.HasKey(e => e.EndCodigo);

            entity.ToTable("ENDERECO");

            entity.Property(e => e.EndBairro)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.EndCep)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("EndCEP");
            entity.Property(e => e.EndCidade)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.EndComplemento)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.EndEstado)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.EndLogradouro)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.EndNumero)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.EndCodigoClienteNavigation).WithMany(p => p.Enderecos)
                .HasForeignKey(d => d.EndCodigoCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ENDERECO_CLIENTE");
        });

        modelBuilder.Entity<EntradaProduto>(entity =>
        {
            entity.HasKey(e => e.EnpCodigoProduto);

            entity.ToTable("ENTRADA_PRODUTO");

            entity.Property(e => e.EnpCodigoProduto).ValueGeneratedNever();
            entity.Property(e => e.EnpValorCusto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.EnpValorVenda).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.EnpCodigoEntradaNavigation).WithMany(p => p.EntradaProdutos)
                .HasForeignKey(d => d.EnpCodigoEntrada)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ENTRADA_PRODUTO_ENTRADA");

            entity.HasOne(d => d.EnpCodigoProdutoNavigation).WithOne(p => p.EntradaProduto)
                .HasForeignKey<EntradaProduto>(d => d.EnpCodigoProduto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ENTRADA_PRODUTO_PRODUTO");
        });

        modelBuilder.Entity<Entradum>(entity =>
        {
            entity.HasKey(e => e.EntCodigo);

            entity.ToTable("ENTRADA");

            entity.Property(e => e.EnNuneroNotaFiscal)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EntDataHora).HasColumnType("datetime");
            entity.Property(e => e.EntUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Parcela>(entity =>
        {
            entity.HasKey(e => e.ParCodigo);

            entity.ToTable("PARCELAS");

            entity.Property(e => e.ParDataPagamento).HasColumnType("datetime");
            entity.Property(e => e.ParDataVencimento).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ParValorParcela).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.ParCodigoVendaNavigation).WithMany(p => p.Parcelas)
                .HasForeignKey(d => d.ParCodigoVenda)
                .HasConstraintName("FK_PARCELAS_VENDA");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.ProCodigo);

            entity.ToTable("PRODUTO");

            entity.Property(e => e.ProCodigoBarras)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.ProDataCadastro).HasColumnType("datetime");
            entity.Property(e => e.ProDescricao)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.ProCodigoTipoProdutoNavigation).WithMany(p => p.Produtos)
                .HasForeignKey(d => d.ProCodigoTipoProduto)
                .HasConstraintName("FK_PRODUTO_TIPO_PRODUTO");

            entity.HasOne(d => d.ProCodigoUnidadeNavigation).WithMany(p => p.Produtos)
                .HasForeignKey(d => d.ProCodigoUnidade)
                .HasConstraintName("FK_PRODUTO_UNIDADE");
        });

        modelBuilder.Entity<TipoPagamento>(entity =>
        {
            entity.HasKey(e => e.TpgCodigo);

            entity.ToTable("TIPO_PAGAMENTO");

            entity.Property(e => e.TpgDescricao)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoProduto>(entity =>
        {
            entity.HasKey(e => e.TipCodigo);

            entity.ToTable("TIPO_PRODUTO");

            entity.Property(e => e.TipDescricao)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Unidade>(entity =>
        {
            entity.HasKey(e => e.UnCodigo);

            entity.ToTable("UNIDADE");

            entity.Property(e => e.UnDescricao)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Vendum>(entity =>
        {
            entity.HasKey(e => e.VenCodigo);

            entity.ToTable("VENDA");

            entity.Property(e => e.VenData).HasColumnType("datetime");
            entity.Property(e => e.VenUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.VenCodigoClienteNavigation).WithMany(p => p.Venda)
                .HasForeignKey(d => d.VenCodigoCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VENDA_CLIENTE");

            entity.HasOne(d => d.VenCodigoTipoPagamentoNavigation).WithMany(p => p.Venda)
                .HasForeignKey(d => d.VenCodigoTipoPagamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VENDA_TIPO_PAGAMENTO");

            entity.HasMany(d => d.ItvCodigoProdutos).WithMany(p => p.ItvCodigoVenda)
                .UsingEntity<Dictionary<string, object>>(
                    "ItensVendum",
                    r => r.HasOne<Produto>().WithMany()
                        .HasForeignKey("ItvCodigoProduto")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ITENS_VENDA_PRODUTO"),
                    l => l.HasOne<Vendum>().WithMany()
                        .HasForeignKey("ItvCodigoVenda")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ITENS_VENDA_VENDA"),
                    j =>
                    {
                        j.HasKey("ItvCodigoVenda", "ItvCodigoProduto");
                        j.ToTable("ITENS_VENDA");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
