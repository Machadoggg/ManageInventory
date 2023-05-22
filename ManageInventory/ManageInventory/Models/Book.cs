using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManageInventory.Models;

public partial class Book
{
    [Key]
    [Column("ISBN")]
    [StringLength(13)]
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    public string Isbn { get; set; } = null!;

    public int? IdEditorial { get; set; }

    [StringLength(45)]
    [Unicode(false)]
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    public string? Title { get; set; }

    [Column(TypeName = "text")]
    public string? Sinopsis { get; set; }

    [StringLength(50)]
    [Display(Name = "Number Pages")]
    public string? NumberPages { get; set; }

    [ForeignKey("IdEditorial")]
    [InverseProperty("Books")]
    public Editorial? IdEditorialNavigation { get; set; }

    [NotMapped]
    public Author? IdAuthor { get; set; }



}
