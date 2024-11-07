using System.ComponentModel.DataAnnotations;

namespace DAL.Management
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(5)]
        public string Name { get; set; } = "";
        [Required]
        [StringLength(254)]
        [DataType(DataType.PostalCode)]

        public string GUID { get; set; } = "";
        [Required]
        [StringLength(254)]
        [DataType(DataType.EmailAddress)]

        public string Email { get; set; } = "";
        [Required]
        [StringLength(254)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = "";
        [Required]
        [StringLength(254)]
        public string FullName { get; set; } = "";
        [Required]
        [DataType(DataType.Time)]
        public DateTime CreatedDate { get; set; }

    }
}
