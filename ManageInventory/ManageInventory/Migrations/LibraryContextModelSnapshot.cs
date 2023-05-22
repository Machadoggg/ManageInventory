﻿// <auto-generated />
using System;
using ManageInventory.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ManageInventory.API.Migrations
{
    [DbContext(typeof(LibraryContext))]
    partial class LibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ManageInventory.Models.Author", b =>
                {
                    b.Property<int>("IdAuthor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAuthor"));

                    b.Property<string>("LastName")
                        .HasMaxLength(45)
                        .IsUnicode(false)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45)
                        .IsUnicode(false)
                        .HasColumnType("varchar(45)");

                    b.HasKey("IdAuthor");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("ManageInventory.Models.AuthorsHasBook", b =>
                {
                    b.Property<int?>("IdAuthor")
                        .HasColumnType("int");

                    b.Property<string>("Isbn")
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)")
                        .HasColumnName("ISBN");

                    b.HasKey("IdAuthor", "Isbn");

                    b.ToTable("Authors_Has_Books");
                });

            modelBuilder.Entity("ManageInventory.Models.Book", b =>
                {
                    b.Property<string>("Isbn")
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)")
                        .HasColumnName("ISBN");

                    b.Property<int?>("IdEditorial")
                        .HasColumnType("int");

                    b.Property<string>("NumberPages")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Sinopsis")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.HasKey("Isbn")
                        .HasName("PK_Books_1");

                    b.HasIndex("IdEditorial");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("ManageInventory.Models.Editorial", b =>
                {
                    b.Property<int>("IdEditorial")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEditorial"));

                    b.Property<string>("Headquarters")
                        .HasMaxLength(45)
                        .IsUnicode(false)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Name")
                        .HasMaxLength(45)
                        .IsUnicode(false)
                        .HasColumnType("varchar(45)");

                    b.HasKey("IdEditorial");

                    b.ToTable("Editorials");
                });

            modelBuilder.Entity("ManageInventory.Shared.Entities.UserProfile", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("ManageInventory.Models.Book", b =>
                {
                    b.HasOne("ManageInventory.Models.Editorial", "IdEditorialNavigation")
                        .WithMany("Books")
                        .HasForeignKey("IdEditorial")
                        .HasConstraintName("FK_Books_Editorials");

                    b.Navigation("IdEditorialNavigation");
                });

            modelBuilder.Entity("ManageInventory.Models.Editorial", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
