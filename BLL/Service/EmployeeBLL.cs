using AutoMapper;
using BLL.Interface;
using DAL.Interface;
using DAL.Management;
using DTO;

namespace BLL.Service
{
    public class EmployeeBLL : IEmployeeBLL
    {
        private readonly IEmployeeRepository repository;
        private readonly IMapper mapper;
        public EmployeeBLL(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            repository = employeeRepository;
            this.mapper = mapper;
        }
        /// <summary>
        /// Creates a new employee record.
        /// </summary>
        /// <param name="employee">The employee data transfer object (DTO) containing the employee's details.</param>
        /// <returns>The newly created employee in the form of an EmployeeDTO, including the created date, GUID, and hashed password.</returns>
        public EmployeeDTO Create(EmployeeCreateDTO employee)
        {
            // Map the EmployeeDTO to the domain model Employee
            Employee employee1 = mapper.Map<Employee>(employee);

            // Set additional properties for the employee object
            employee1.CreatedDate = DateTime.Now;
            employee1.GUID = Guid.NewGuid().ToString();
            employee1.Password = PasswordHasher.HashPassword(employee1.Password);
            return mapper.Map<EmployeeDTO>(repository.Create(employee1));
        }
        
        /// <summary>
        /// Retrieves a list of employees managed by a specific manager.
        /// </summary>
        /// <param name="managerId">The ID of the manager whose employees are to be retrieved.</param>
        /// <returns>A list of EmployeeDTO objects representing the employees managed by the given manager.</returns>

        public List<EmployeeDTO> GetListByManger(int manegerId)
        {
            return mapper.Map<List<EmployeeDTO>>(repository.GetListByManger(manegerId));
        }
        /// <summary>
        /// Deletes an employee record based on their unique ID.
        /// </summary>
        /// <param name="id">The ID of the employee to be deleted.</param>
        /// <returns>True if the employee was successfully deleted, otherwise false.</returns>

        public bool Delete(int id)
        {
            return repository.Delete(id);
        }
    }
}
