using System;
using System.Collections.Generic;
using ManageInventory.Models;
using Microsoft.EntityFrameworkCore;

namespace ManageInventory.Data;

public partial class LibraryContext : DbContext
{
    public LibraryContext()
    {
    }

    public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<AuthorsHasBook> AuthorsHasBooks { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Editorial> Editorials { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=Library;User ID=sa;Password=Dontknow1;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuthorsHasBook>(entity =>
        {
            entity.HasOne(d => d.IdAuthorsNavigation)
            .WithMany()
            .HasConstraintName("FK_Authors_Has_Books_Authors");

            entity.HasOne(d => d.IsbnNavigation)
            .WithMany()
            .HasConstraintName("FK_Authors_Has_Books_Books");
        });

        modelBuilder.Entity<AuthorsHasBook>()
            .HasKey(a => new { a.IdAuthor, a.Isbn });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Isbn)
            .HasName("PK_Books_1");

            entity.HasOne(d => d.IdEditorialNavigation)
            .WithMany(p => p.Books)
            .HasConstraintName("FK_Books_Editorials");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
