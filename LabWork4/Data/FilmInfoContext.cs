using System;
using System.Collections.Generic;
using LabWork4.Models;
using Microsoft.EntityFrameworkCore;

namespace LabWork4.Data;

public partial class FilmInfoContext : DbContext
{
    public FilmInfoContext()
    {
    }

    public FilmInfoContext(DbContextOptions<FilmInfoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Film> Films { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Data Source=mssql;Initial Catalog=ispp2106;User ID=ispp2106;Password=2106;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Film>(entity =>
        {
            entity.Property(e => e.FilmId).ValueGeneratedNever();
            entity.Property(e => e.AgeRating)
                .HasMaxLength(3)
                .IsFixedLength();
            entity.Property(e => e.FilmName)
                .HasMaxLength(30)
                .IsFixedLength();
            entity.Property(e => e.Rating).HasColumnType("decimal(3, 1)");

            entity.HasOne(d => d.Genre).WithMany(p => p.Films)
                .HasForeignKey(d => d.GenreId)
                .HasConstraintName("FK_Films_Genres");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.Property(e => e.GenreId).ValueGeneratedNever();
            entity.Property(e => e.GenreName)
                .HasMaxLength(30)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
