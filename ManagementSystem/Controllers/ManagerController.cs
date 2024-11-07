using BLL.Interface;
using DAL.Management;
using DTO;
using ManagementSystem.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        // Injecting the Business Logic Layer (BLL) and Auth service
        private readonly IManagerBLL managerBLL;
        private readonly IAuthService authService;

        // Constructor to initialize the BLL and Auth service

        public ManagerController(IManagerBLL managerBLL, IAuthService authService)
        {
            this.managerBLL = managerBLL;
            this.authService = authService;
        }
        /// <summary>
        /// Signup in a manager by validating their credentials and returning a JWT token if successful.
        /// </summary>
        /// <param name="manager"></param>
        /// <returns>A JWT token if Signup is successful,
        /// or a BadRequest with an error message if the Signup fails.</returns>
        [HttpPost]
        public IActionResult Signup(ManagerCreateDTO manager)
        {
            try
            {
                ManagerDTO manager1 = managerBLL.Create(manager);
                if (manager1 == null)
                {
                    return BadRequest("Signup was filed");
                }
                string token = authService.GenerateJwtToken(manager1);
                return Ok(new { token, manager });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Logs in a manager by validating their credentials and returning a JWT token if successful.
        /// </summary>
        /// <param name="data">The login credentials provided by the manager (Email,password).</param>
        /// <returns>A JWT token if login is successful, or a BadRequest with an error message if the login fails.</returns>
        [HttpPost("login")]
        public IActionResult Login(LoginDTO data)
        {
            try
            {
                ManagerDTO? manager = managerBLL.Login(data);
                if (manager == null)
                {
                    return BadRequest("login was filed");
                }
                string token = authService.GenerateJwtToken(manager);
                return Ok(new { token, manager });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}
