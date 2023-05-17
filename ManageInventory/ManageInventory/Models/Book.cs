using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ManageInventory.Models;

public partial class Book
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
    [Display (Name = "Number Pages")]
    public string? NumberPages { get; set; }

    [ForeignKey("IdEditorial")]
    [InverseProperty("Books")]
    public virtual Editorial? IdEditorialNavigation { get; set; }
}
