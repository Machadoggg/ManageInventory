using ManageInventory.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ManageInventory.DTO
{
    public class BookDetailDTO
    {
        //public string Isbn { get; set; } = null!;
        [Display(Name = "Id Editorial")]
        public int? IdEditorial { get; set; }
        [Display(Name = "Editorial Name")]
        public string? EditorialName { get; set; }
        //public virtual Editorial Editorial { get; set; }

        public string? Title { get; set; }

        public string? Sinopsis { get; set; }

        [Display(Name = "Number Pages")]
        public string? NumberPages { get; set; }
        [NotMapped]
        [Display(Name = "Author Name")]
        public string? AuthorName { get; set; }

        public Editorial IdEditorialNavigation { get; set; } = default!;

        [NotMapped]
        [Display(Name = "Id Author")]
        public virtual Author? IdAuthor { get; set; }
        
        //public virtual Author? AuthorName { get; set; }

    }
}
