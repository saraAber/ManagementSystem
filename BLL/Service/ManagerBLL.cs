using AutoMapper;
using BLL.Interface;
using DAL.Interface;
using DAL.Management;
using DTO;

namespace BLL.Service
{
    internal class ManagerBLL : IManagerBLL
    {
        private readonly IManagerRepository repository;
        private readonly IMapper mapper;
        public ManagerBLL(IManagerRepository managerBLL, IMapper mapper)
        {
            repository = managerBLL;
            this.mapper = mapper;
        }
        /// <summary>
        /// Creates a new manager record.
        /// </summary>
        /// <param name="manager">Manager DTO containing the manager's information.</param>
        /// <returns>A ManagerDTO representing the newly created manager.</returns>

        public ManagerDTO Create(ManagerCreateDTO manager)
        {
            // Map the DTO to the domain model (Manager)
            Manager manager1 = mapper.Map<Manager>(manager);
            // Set additional properties for the manager object
            manager1.CreatedDate = DateTime.Now;  // Set the current date as the creation date
            manager1.GUID = Guid.NewGuid().ToString();  // Generate a unique GUID for the manager
            manager1.Password = PasswordHasher.HashPassword(manager.Password);  // Hash the manager's password

            // Call the repository's Create method to save the manager in the database
            // Map the result back to a ManagerDTO and return it
            return mapper.Map<ManagerDTO>(repository.Create(manager1));
        }


        /// <summary>
        /// Attempts to log in a manager by verifying their email and password.
        /// </summary>
        /// <param name="data">LoginDTO containing the manager's email and password.</param>
        /// <returns>A ManagerDTO representing the logged-in manager, or null if login fails.</returns>
        public ManagerDTO? Login(LoginDTO data)
        {
            // Hash the provided password to compare with the stored hashed password
            string password = PasswordHasher.HashPassword(data.Password);
            // Call the repository's Login method to verifying their email and password  in the database
            // Map the result back to a ManagerDTO and return it
            return mapper.Map<ManagerDTO>(repository.Login(data.Email,password));
        }

        
    }
}
