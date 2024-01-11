using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SGU.ORM;

public partial class SguContext : DbContext
{
    public SguContext()
    {
    }

    public SguContext(DbContextOptions<SguContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agendamento> Agendamentos { get; set; }

    public virtual DbSet<Contato> Contatos { get; set; }

    public virtual DbSet<Manutencao> Manutencaos { get; set; }

    public virtual DbSet<Servico> Servicos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=SGU;User Id=admin;Password=admin;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agendamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Agendame__3214EC2702AB8699");

            entity.ToTable("Agendamento");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.DtAgendamento).HasColumnType("datetime");
            entity.Property(e => e.FkServicoId).HasColumnName("fk_Servico_ID");
            entity.Property(e => e.FkUsuarioId).HasColumnName("fk_Usuario_ID");
            entity.Property(e => e.Tipo)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.FkServico).WithMany(p => p.Agendamentos)
                .HasForeignKey(d => d.FkServicoId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Agendamento_Agendamento");

            entity.HasOne(d => d.FkUsuario).WithMany(p => p.Agendamentos)
                .HasForeignKey(d => d.FkUsuarioId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Agendamento_3");
        });

        modelBuilder.Entity<Contato>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC07F6E43641");

            entity.ToTable("Contato");

            entity.HasIndex(e => e.Telefone, "UQ__Usuario__4EC504B69B03B9E1").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Usuario__A9D105345DD62377").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.Mensagem).HasColumnType("text");
            entity.Property(e => e.Nome)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.Telefone)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Manutencao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Manutenc__3214EC271200D3A8");

            entity.ToTable("Manutencao");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FkAgendamentoId).HasColumnName("fk_Agendamento_ID");
            entity.Property(e => e.Tecnica)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ValorManutencao)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Valor_Manutencao");

            entity.HasOne(d => d.FkAgendamento).WithMany(p => p.Manutencaos)
                .HasForeignKey(d => d.FkAgendamentoId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Manutencao");
        });

        modelBuilder.Entity<Servico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Servico__3214EC27B5FA8CB7");

            entity.ToTable("Servico");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Descricao)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Valor).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC27E2295BD0");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Email, "UQ__Usuario__A9D10534C278CFD5").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.Senha)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.Telefone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.TipoUsuario)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
