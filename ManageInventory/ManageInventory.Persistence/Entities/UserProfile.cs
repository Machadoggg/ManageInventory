using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageInventory.Persistence.Entities
{
    public class UserProfile
    {
        [Key]
        public int UserId { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;
        public bool IsActive { get; set; }
    }
}
