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

    public virtual DbSet<Manutencao> Manutencaos { get; set; }

    public virtual DbSet<Servico> Servicos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<ViewAgendamento> ViewAgendamentos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=SGU;User Id=admin;Password=@Karython0705;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agendamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Agendame__3214EC27509ADEBE");

            entity.ToTable("Agendamento");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AgendarData).HasColumnType("date");
            entity.Property(e => e.DtHoraAgendamento)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtHoraAgendamento");
            entity.Property(e => e.FkServicoId).HasColumnName("fk_Servico_ID");
            entity.Property(e => e.FkUsuarioId).HasColumnName("fk_Usuario_ID");
            entity.Property(e => e.Horario).HasColumnType("date");

            entity.HasOne(d => d.FkServico).WithMany(p => p.Agendamentos)
                .HasForeignKey(d => d.FkServicoId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Agendamento_3");

            entity.HasOne(d => d.FkUsuario).WithMany(p => p.Agendamentos)
                .HasForeignKey(d => d.FkUsuarioId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Agendamento_2");
        });

        modelBuilder.Entity<Comentario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comentar__3214EC277DAA7612");

            entity.ToTable("Comentario");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descricao).HasColumnType("text");
            entity.Property(e => e.FkUsuarioId).HasColumnName("fk_Usuario_ID");
            entity.Property(e => e.Satisfacao)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.FkUsuario).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.FkUsuarioId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Comentario_2");
        });

        modelBuilder.Entity<Manutencao>(entity =>
        {
            entity.ToTable("Manutencao");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FkServico).HasColumnName("fk_Servico");
            entity.Property(e => e.Tecnica)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Valor).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<Servico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Servico__3214EC27F0BC9C7A");

            entity.ToTable("Servico");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Tecnica)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC274ABA570E");

            entity.ToTable("Usuario");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Senha)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefone)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ViewAgendamento>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ViewAgendamentos");

            entity.Property(e => e.AgendarData).HasColumnType("date");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Horario).HasColumnType("date");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nome)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Tecnica)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefone)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
