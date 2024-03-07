using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WatchCatalogAPI.Models;

public partial class WatchDBContext : DbContext
{
    public WatchDBContext()
    {
    }

    public WatchDBContext(DbContextOptions<WatchDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Watch> Watches { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:ladysqlserver.database.windows.net,1433;Initial Catalog=AzureIntegrationWatchCatalogDB;Persist Security Info=False;User ID=lady.mariz.lugtu;Password=yumielle01_00;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Watch>(entity =>
        {
            entity.HasKey(e => e.WatchId).HasName("PK__Watches__3BA3DA83978A0151");

            entity.Property(e => e.WatchId).HasColumnName("WatchID");
            entity.Property(e => e.WatchDescription)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.WatchName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
