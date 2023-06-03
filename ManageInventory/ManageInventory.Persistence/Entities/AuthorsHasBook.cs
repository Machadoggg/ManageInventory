using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManageInventory.Persistence.Entities;

[Table("Authors_Has_Books")]
public class AuthorsHasBook
{
    [ForeignKey("IdAuthor")]
    public int? IdAuthor { get; set; }

    [Column("ISBN")]
    [StringLength(13)]
    public string? Isbn { get; set; }

}
