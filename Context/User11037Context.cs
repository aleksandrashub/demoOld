using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using demo2811.Models;

namespace demo2811.Context;

public partial class User11037Context : DbContext
{
    public User11037Context()
    {
    }

    public User11037Context(DbContextOptions<User11037Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Aim> Aims { get; set; }

    public virtual DbSet<Podrazd> Podrazds { get; set; }

    public virtual DbSet<Sotrudnik> Sotrudniks { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Zayavka> Zayavkas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("host=192.168.7.159;Database=user11037;Username=user11037;Password=24731");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aim>(entity =>
        {
            entity.HasKey(e => e.IdAim).HasName("aim_pk");

            entity.ToTable("aim");

            entity.Property(e => e.IdAim)
                .ValueGeneratedNever()
                .HasColumnName("id_aim");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Podrazd>(entity =>
        {
            entity.HasKey(e => e.IdPodrazd).HasName("podrazd_pk");

            entity.ToTable("podrazd");

            entity.Property(e => e.IdPodrazd)
                .ValueGeneratedNever()
                .HasColumnName("id_podrazd");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");

            entity.HasMany(d => d.IdSotruds).WithMany(p => p.IdPodrazds)
                .UsingEntity<Dictionary<string, object>>(
                    "PodrazdSotrud",
                    r => r.HasOne<Sotrudnik>().WithMany()
                        .HasForeignKey("IdSotrud")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("podrazd_sotrud_sotrudnik_fk"),
                    l => l.HasOne<Podrazd>().WithMany()
                        .HasForeignKey("IdPodrazd")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("podrazd_sotrud_podrazd_fk"),
                    j =>
                    {
                        j.HasKey("IdPodrazd", "IdSotrud").HasName("podrazd_sotrud_pk");
                        j.ToTable("podrazd_sotrud");
                        j.IndexerProperty<int>("IdPodrazd").HasColumnName("id_podrazd");
                        j.IndexerProperty<int>("IdSotrud").HasColumnName("id_sotrud");
                    });
        });

        modelBuilder.Entity<Sotrudnik>(entity =>
        {
            entity.HasKey(e => e.IdSotrudnik).HasName("sotrudnik_pk");

            entity.ToTable("sotrudnik");

            entity.Property(e => e.IdSotrudnik)
                .ValueGeneratedNever()
                .HasColumnName("id_sotrudnik");
            entity.Property(e => e.Code)
                .HasColumnType("character varying")
                .HasColumnName("code");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Otchestvo)
                .HasColumnType("character varying")
                .HasColumnName("otchestvo");
            entity.Property(e => e.Surname)
                .HasColumnType("character varying")
                .HasColumnName("surname");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.IdStat).HasName("status_pk");

            entity.ToTable("status");

            entity.Property(e => e.IdStat)
                .ValueGeneratedNever()
                .HasColumnName("id_stat");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("user_pk");

            entity.ToTable("user");

            entity.Property(e => e.IdUser)
                .ValueGeneratedNever()
                .HasColumnName("id_user");
            entity.Property(e => e.Birth).HasColumnName("birth");
            entity.Property(e => e.Image)
                .HasColumnType("character varying")
                .HasColumnName("image");
            entity.Property(e => e.Login)
                .HasColumnType("character varying")
                .HasColumnName("login");
            entity.Property(e => e.Mail)
                .HasColumnType("character varying")
                .HasColumnName("mail");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Nomer)
                .HasColumnType("character varying")
                .HasColumnName("nomer");
            entity.Property(e => e.Organization)
                .HasColumnType("character varying")
                .HasColumnName("organization");
            entity.Property(e => e.Otchestvo)
                .HasColumnType("character varying")
                .HasColumnName("otchestvo");
            entity.Property(e => e.Passwd)
                .HasColumnType("character varying")
                .HasColumnName("passwd");
            entity.Property(e => e.Phone)
                .HasColumnType("character varying")
                .HasColumnName("phone");
            entity.Property(e => e.Primechanie)
                .HasColumnType("character varying")
                .HasColumnName("primechanie");
            entity.Property(e => e.Seria)
                .HasColumnType("character varying")
                .HasColumnName("seria");
            entity.Property(e => e.Surname)
                .HasColumnType("character varying")
                .HasColumnName("surname");
        });

        modelBuilder.Entity<Zayavka>(entity =>
        {
            entity.HasKey(e => e.IdZayavka).HasName("zayavka_pk");

            entity.ToTable("zayavka");

            entity.Property(e => e.IdZayavka)
                .ValueGeneratedNever()
                .HasColumnName("id_zayavka");
            entity.Property(e => e.IdAim).HasColumnName("id_aim");
            entity.Property(e => e.IdPodrazd).HasColumnName("id_podrazd");
            entity.Property(e => e.IdStat).HasColumnName("id_stat");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Nomer)
                .HasColumnType("character varying")
                .HasColumnName("nomer");
            entity.Property(e => e.SrokKonets).HasColumnName("srok_konets");
            entity.Property(e => e.SrokNach).HasColumnName("srok_nach");

            entity.HasOne(d => d.IdAimNavigation).WithMany(p => p.Zayavkas)
                .HasForeignKey(d => d.IdAim)
                .HasConstraintName("zayavka_aim_fk");

            entity.HasOne(d => d.IdPodrazdNavigation).WithMany(p => p.Zayavkas)
                .HasForeignKey(d => d.IdPodrazd)
                .HasConstraintName("zayavka_podrazd_fk");

            entity.HasOne(d => d.IdStatNavigation).WithMany(p => p.Zayavkas)
                .HasForeignKey(d => d.IdStat)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("zayavka_status_fk");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Zayavkas)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("zayavka_user_fk");

            entity.HasMany(d => d.IdUsers).WithMany(p => p.IdZayavkas)
                .UsingEntity<Dictionary<string, object>>(
                    "Group",
                    r => r.HasOne<User>().WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("group_user_fk"),
                    l => l.HasOne<Zayavka>().WithMany()
                        .HasForeignKey("IdZayavka")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("group_zayavka_fk"),
                    j =>
                    {
                        j.HasKey("IdZayavka", "IdUser").HasName("group_pk");
                        j.ToTable("group");
                        j.IndexerProperty<int>("IdZayavka").HasColumnName("id_zayavka");
                        j.IndexerProperty<int>("IdUser").HasColumnName("id_user");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
