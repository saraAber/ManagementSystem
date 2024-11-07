using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoginDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";
        [StringLength(254)]
        [DataType(DataType.Password)]
        [MinLength(8)]
        [MaxLength(15)]
        public string Password { get; set; } = "";
    }
}
