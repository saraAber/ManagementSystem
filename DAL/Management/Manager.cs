using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Management
{
    public class Manager : UserModel
    {

        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    }
}
