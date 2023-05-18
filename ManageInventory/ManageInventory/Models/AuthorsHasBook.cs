using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ManageInventory.Models;

[Keyless]
[Table("Authors_Has_Books")]
public class AuthorsHasBook
{
    [ForeignKey("IdAuthor")]
    public int? IdAuthor { get; set; }

    
    [Column("ISBN")]
    [StringLength(13)]
    public string? Isbn { get; set; }

    
    public virtual Author? IdAuthorsNavigation { get; set; }

    [ForeignKey("Isbn")]
    public virtual Book? IsbnNavigation { get; set; }
}
