using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DTO
{
    public class ManagerCreateDTO
    {
        [Required]
        [MaxLength(254)]
        [MinLength(2)]

        public string Name { get; set; } = "";
        
        [Required]
        [StringLength(254)]
        [EmailAddress]
        public string Email { get; set; } = "";
        
        [Required]
        [StringLength(254)]
        public string FullName { get; set; } = "";

        [Required]
        [StringLength(254)]
        [DataType(DataType.Password)]
        [MinLength(8)]
        [MaxLength(15)]
        public string Password { get; set; } = "";
    }
}
