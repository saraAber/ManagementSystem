using DAL.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IEmployeeRepository
    {
        Employee Create(Employee employee);
        Employee? Get(int id);
        List<Employee> GetListByManger(int manegerId);
        bool Delete(int id);
    }
}
