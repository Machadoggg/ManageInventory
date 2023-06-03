using System.ComponentModel.DataAnnotations;

namespace ManageInventory.Persistence.Entities
{
    public class UserProfile
    {
        [Key]
        public int UserId { get; set; }

        [Display(Name = "User Name")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string UserName { get; set; } = default!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Password { get; set; } = default!;

        public bool IsActive { get; set; }
    }
}
