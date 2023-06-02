using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using Microsoft.EntityFrameworkCore;

namespace ManageInventory.Persistence.Entities;

public partial class Author
{
    [Key]
    public int IdAuthor { get; set; }

    [StringLength(45)]
    //[Unicode(false)]
    public string Name { get; set; }

    [StringLength(45)]
    //[Unicode(false)]
    public string? LastName { get; set; }

    [NotMapped]
    public AuthorsHasBook? AuthorsHasBook { get; set; }
}
