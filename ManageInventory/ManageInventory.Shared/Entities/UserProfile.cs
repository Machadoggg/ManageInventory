using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageInventory.Shared.Entities
{
    public class UserProfile
    {
        [Key]
        public int UserId { get; set; }
        [Display(Name ="User Name")]
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}
