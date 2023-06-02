using ManageInventory.Persistence.Entities;
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

    public virtual DbSet<UserProfile> UserProfiles { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

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

        modelBuilder.Entity<UserProfile>()
        .HasKey(u => u.UserId);


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
