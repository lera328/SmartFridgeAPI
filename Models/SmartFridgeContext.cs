using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SmartFridgeAPI.Models;

public partial class SmartFridgeContext : DbContext
{
    public SmartFridgeContext()
    {
    }

    public SmartFridgeContext(DbContextOptions<SmartFridgeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ЕдиницыИзмерения> ЕдиницыИзмеренияs { get; set; }

    public virtual DbSet<НаборыПродуктов> НаборыПродуктовs { get; set; }

    public virtual DbSet<Пользователи> Пользователиs { get; set; }

    public virtual DbSet<ПриемыПищи> ПриемыПищиs { get; set; }

    public virtual DbSet<ПродуктыВХолодильнике> ПродуктыВХолодильникеs { get; set; }

    public virtual DbSet<Рецепты> Рецептыs { get; set; }

    public virtual DbSet<СпискиПокупок> СпискиПокупокs { get; set; }

    public virtual DbSet<УпотребленныеПродукты> УпотребленныеПродуктыs { get; set; }

    public virtual DbSet<Холодильники> Холодильникиs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-01B2B8O;Database=SmartFridge;User ID=sa;Password=********;Encrypt=True;Trust Server Certificate=True;Multi Subnet Failover=False;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ЕдиницыИзмерения>(entity =>
        {
            entity.HasKey(e => e.IdЕдиницы);

            entity.ToTable("Единицы_измерения");

            entity.Property(e => e.IdЕдиницы)
                .ValueGeneratedNever()
                .HasColumnName("id_единицы");
            entity.Property(e => e.Наименование).HasMaxLength(50);
        });

        modelBuilder.Entity<НаборыПродуктов>(entity =>
        {
            entity.HasKey(e => e.IdПродукта);

            entity.ToTable("Наборы_продуктов");

            entity.Property(e => e.IdПродукта)
                .ValueGeneratedNever()
                .HasColumnName("id_продукта");
            entity.Property(e => e.IdЕдиницы).HasColumnName("id_единицы");
            entity.Property(e => e.IdРецепта).HasColumnName("id_рецепта");

            entity.HasOne(d => d.IdРецептаNavigation).WithMany(p => p.НаборыПродуктовs)
                .HasForeignKey(d => d.IdРецепта)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Наборы_продуктов_Рецепты");
        });

        modelBuilder.Entity<Пользователи>(entity =>
        {
            entity.HasKey(e => e.IdПользователя);

            entity.ToTable("Пользователи");

            entity.Property(e => e.IdПользователя)
                .ValueGeneratedNever()
                .HasColumnName("id_пользователя");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.IdХолодильника).HasColumnName("id_холодильника");
            entity.Property(e => e.Пароль).HasMaxLength(50);

            entity.HasOne(d => d.IdХолодильникаNavigation).WithMany(p => p.Пользователиs)
                .HasForeignKey(d => d.IdХолодильника)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Пользователи_Холодильники");
        });

        modelBuilder.Entity<ПриемыПищи>(entity =>
        {
            entity.HasKey(e => e.IdПриемаПищи);

            entity.ToTable("Приемы_пищи");

            entity.Property(e => e.IdПриемаПищи)
                .ValueGeneratedNever()
                .HasColumnName("id_приема_пищи");
            entity.Property(e => e.Наименование).HasMaxLength(50);
        });

        modelBuilder.Entity<ПродуктыВХолодильнике>(entity =>
        {
            entity.HasKey(e => e.IdПродукта);

            entity.ToTable("Продукты_в_холодильнике");

            entity.Property(e => e.IdПродукта)
                .ValueGeneratedNever()
                .HasColumnName("id_продукта");
            entity.Property(e => e.IdЕдиницы).HasColumnName("id_единицы");
            entity.Property(e => e.IdХолодильника).HasColumnName("id_холодильника");
            entity.Property(e => e.ДатаДобавления).HasColumnName("Дата_добавления");
            entity.Property(e => e.Кк).HasColumnName("КК");
            entity.Property(e => e.СрокГодности).HasColumnName("Срок_годности");

            entity.HasOne(d => d.IdХолодильникаNavigation).WithMany(p => p.ПродуктыВХолодильникеs)
                .HasForeignKey(d => d.IdХолодильника)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Продукты_в_холодильнике_Холодильники");
        });

        modelBuilder.Entity<Рецепты>(entity =>
        {
            entity.HasKey(e => e.IdРецепта);

            entity.ToTable("Рецепты");

            entity.Property(e => e.IdРецепта)
                .ValueGeneratedNever()
                .HasColumnName("id_рецепта");
            entity.Property(e => e.IdПользователя).HasColumnName("id_пользователя");
            entity.Property(e => e.Наименование).HasMaxLength(50);
            entity.Property(e => e.ПоследовательностьДействий).HasColumnName("Последовательность_действий");

            entity.HasOne(d => d.IdПользователяNavigation).WithMany(p => p.Рецептыs)
                .HasForeignKey(d => d.IdПользователя)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Рецепты_Пользователи");
        });

        modelBuilder.Entity<СпискиПокупок>(entity =>
        {
            entity.HasKey(e => e.IdСпПродукта);

            entity.ToTable("Списки покупок");

            entity.Property(e => e.IdСпПродукта)
                .ValueGeneratedNever()
                .HasColumnName("id_сп_продукта");
            entity.Property(e => e.IdХолодильника).HasColumnName("id_холодильника");
            entity.Property(e => e.Наименование).IsUnicode(false);
        });

        modelBuilder.Entity<УпотребленныеПродукты>(entity =>
        {
            entity.HasKey(e => e.IdУпотребленногоПродукта);

            entity.ToTable("Употребленные_продукты");

            entity.Property(e => e.IdУпотребленногоПродукта)
                .ValueGeneratedNever()
                .HasColumnName("id_употребленного_продукта");
            entity.Property(e => e.IdПользователя).HasColumnName("id_пользователя");
            entity.Property(e => e.IdПриемаПищи).HasColumnName("id_приема_пищи");
            entity.Property(e => e.IdПродукта).HasColumnName("id_продукта");

            entity.HasOne(d => d.IdПользователяNavigation).WithMany(p => p.УпотребленныеПродуктыs)
                .HasForeignKey(d => d.IdПользователя)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Употребленные_продукты_Пользователи");

            entity.HasOne(d => d.IdПриемаПищиNavigation).WithMany(p => p.УпотребленныеПродуктыs)
                .HasForeignKey(d => d.IdПриемаПищи)
                .HasConstraintName("FK_Употребленные_продукты_Приемы_пищи");

            entity.HasOne(d => d.IdПродуктаNavigation).WithMany(p => p.УпотребленныеПродуктыs)
                .HasForeignKey(d => d.IdПродукта)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Употребленные_продукты_Продукты_в_холодильнике");
        });

        modelBuilder.Entity<Холодильники>(entity =>
        {
            entity.HasKey(e => e.IdХолодильника);

            entity.ToTable("Холодильники");

            entity.Property(e => e.IdХолодильника)
                .ValueGeneratedNever()
                .HasColumnName("id_холодильника");
            entity.Property(e => e.КодДоступа)
                .HasMaxLength(50)
                .HasColumnName("Код_доступа");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
