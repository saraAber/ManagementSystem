using BLL.Interface;
using DAL.Management;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.Controllers
{
    // Ensure that the controller requires authentication and that only authorized users can access it
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // Injecting the Business Logic Layer (BLL)
        private readonly IEmployeeBLL employeeBll;
        // Constructor to initialize the BLL
        public EmployeeController(IEmployeeBLL employeeBLL)
        {
            this.employeeBll = employeeBLL;
        }
        /// <summary>
        /// POST method to create a new employee 
        ///  whith the manager's ID from the JWT claims
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>Created status with the created employee object if successful</returns>
        [HttpPost]
        public IActionResult Create(EmployeeCreateDTO employee)
        {
            try
            {
                //Retrieve the manager's ID from the JWT claims
                string? s = User.Claims.FirstOrDefault(x => x.Type == "id")?.Value;
                if (s == null)
                    return BadRequest("manager data not found");
                employee.ManagerId = int.Parse(s);
                EmployeeDTO employee1 = employeeBll.Create(employee );
                if (employee1 == null)
                {
                    return BadRequest("created was filed");
                }
                // Return a Created status with the created employee object if successful
                return Created("sucsses", employee1);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// GET method to retrieve a list of employees based on the manager's ID
        /// </summary>
        /// <returns>list of employees for that manager from the JWT</returns>
        [HttpGet]
        public IActionResult GetList()
        {
            try
            {
                // Retrieve the manager's ID from the JWT claims
                string? id = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "id")?.Value;
                // If the manager's ID is found, return the list of employees for that manager
                if (id != null)
                {
                    return Ok(employeeBll.GetListByManger(int.Parse(id)));
                }
                return BadRequest("manager data not found");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// DELETE method to remove an employee by ID
        /// </summary>
        /// <param name="id">employeeId</param>
        /// <returns>a success or failure message</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            try
            {
                if (employeeBll.Delete(id))
                    return Ok("delete was sucsses");
                return BadRequest("Employee not found!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

    }
}
