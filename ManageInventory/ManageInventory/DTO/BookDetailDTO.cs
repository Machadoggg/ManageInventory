using ManageInventory.Persistence.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManageInventory.DTO
{
    public class BookDetailDTO
    {
        [Display(Name = "Id Editorial")]
        public int IdEditorial { get; set; }


        [Display(Name = "Editorial Name")]
        public string? EditorialName { get; set; }

        public string? Title { get; set; }


        [Display(Name = "Synopsis")]
        public string? Sinopsis { get; set; }


        [Display(Name = "Number Pages")]
        public string? NumberPages { get; set; }


        [NotMapped]
        [Display(Name = "Author Name")]
        public string? AuthorName { get; set; }

        public Editorial IdEditorialNavigation { get; set; } = default!;


        [NotMapped]
        [Display(Name = "Id Author")]
        public Author? IdAuthor { get; set; }

    }
}
