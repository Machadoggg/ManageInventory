﻿using ManageInventory.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ManageInventory.DTO
{
    public class BookDTO
    {
        [Key]
        [Column("ISBN")]
        [StringLength(13)]
        public string Isbn { get; set; } = null!;

        public int? IdEditorial { get; set; }


        [StringLength(45)]
        [Unicode(false)]
        public string? Title { get; set; }

        [Column(TypeName = "text")]
        public string? Sinopsis { get; set; }

        [StringLength(50)]
        [Display(Name = "Number Pages")]
        public string? NumberPages { get; set; }

        [ForeignKey("IdEditorial")]
        [InverseProperty("Books")]
        public virtual Editorial? IdEditorialNavigation { get; set; }

        [NotMapped]
        public virtual Author? IdAuthor { get; set; }
    }
}
