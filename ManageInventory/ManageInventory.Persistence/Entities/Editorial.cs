using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManageInventory.Persistence.Entities;

public partial class Editorial
{
    [Key]
    public int IdEditorial { get; set; }

    [StringLength(45)]
    public string? Name { get; set; }

    [StringLength(45)]
    public string? Headquarters { get; set; }

    [InverseProperty("IdEditorialNavigation")]
    public ICollection<Book> Books { get; set; } = new List<Book>();
}
