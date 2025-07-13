// Author: Choudhury Saadmaan Mahmid
// Created: July 12, 2025
// Description: DbContext for the table Top_Movies_2025 under the IMDB database.

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace IMDBMovieAPI.Models;

public partial class MovieDbContext : DbContext
{
    public MovieDbContext()
    {
    }

    public MovieDbContext(DbContextOptions<MovieDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TopMovies2025> TopMovies2025s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLExpress;Database=IMDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TopMovies2025>(entity =>
        {
            entity.HasKey(e => e.Rank).HasName("PK__Top_Movi__DF85EC5609BD7822");

            entity.ToTable("Top_Movies_2025");

            entity.Property(e => e.Rank).ValueGeneratedNever();
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
