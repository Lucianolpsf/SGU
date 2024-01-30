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

    public virtual DbSet<Comentario> Comentarios { get; set; }

    public virtual DbSet<Servico> Servicos { get; set; }

    public virtual DbSet<TipoServico> TipoServicos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
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
            entity.Property(e => e.AgendarData).HasColumnType("date");
            entity.Property(e => e.DtAgendamento).HasColumnType("datetime");
            entity.Property(e => e.FkServicoId).HasColumnName("fk_Servico_ID");
            entity.Property(e => e.FkUsuarioId).HasColumnName("fk_Usuario_ID");

            entity.HasOne(d => d.FkServico).WithMany(p => p.Agendamentos)
                .HasForeignKey(d => d.FkServicoId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Agendamento_Agendamento");

            entity.HasOne(d => d.FkUsuario).WithMany(p => p.Agendamentos)
                .HasForeignKey(d => d.FkUsuarioId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Agendamento_3");
        });

        modelBuilder.Entity<Comentario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comentar__3214EC27156C254A");

            entity.ToTable("Comentario");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descricao).HasColumnType("text");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ID_Usuario");
        });

        modelBuilder.Entity<Servico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Servico__3214EC27B5FA8CB7");

            entity.ToTable("Servico");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.IdTipoServico).HasColumnName("ID_Tipo_Servico");
            entity.Property(e => e.Tecnica)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTipoServicoNavigation).WithMany(p => p.Servicos)
                .HasForeignKey(d => d.IdTipoServico)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ID_Tipo_Servico");
        });

        modelBuilder.Entity<TipoServico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TipoServ__3214EC27029AD569");

            entity.ToTable("TipoServico");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false);
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
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TipoUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
