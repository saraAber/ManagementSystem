using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Management
{


    public class Employee : UserModel
    {

        [Required]
        public int ManagerId { get; set; }
        [ForeignKey("ManagerId")]
        public virtual Manager? Manager { get; set; }
    }

}
