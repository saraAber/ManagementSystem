using DAL.Interface;
using DAL.Management;
using System.Xml.Linq;

namespace DAL.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        readonly AppDbContext appDbContext;
        public EmployeeRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public Employee Create(Employee employee)
        {
            if (appDbContext.Employees.Any(x => x.ManagerId == employee.ManagerId && (x.Email == employee.Email || employee.Name == x.Name)))
                throw new Exception("Employee alredt exthis!");
            employee = appDbContext.Employees.Add(employee).Entity;
            appDbContext.SaveChanges();
            return employee;
        }

        public Employee? Get(int id)
        {
            return appDbContext.Employees.FirstOrDefault(e => e.Id == id);
        }

        public bool Delete(int id)
        {
            Employee? employee = Get(id);
            if (employee == null)
                return false;

            appDbContext.Employees.Remove(employee);
            appDbContext.SaveChanges();
            return true;
        }
        public List<Employee> GetListByManger(int manegerId)
        {
            return appDbContext.Employees.Where(e => e.ManagerId == manegerId).ToList();
        }
    }
}
