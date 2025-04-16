using Microsoft.AspNetCore.Mvc;
using AFTERCLASS.AMS.API.Application;
using AFTERCLASS.AMS.API.Domain.Entities;
using AFTERCLASS.AMS.API.Infrastructure.Repositories;
using MySqlX.XDevAPI;
using AFTERCLAS.AMS.API.Application.Auth;

namespace AFTERCLASS.AMS.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly  ITeacherRepository _repository;

        public AuthController(ITeacherRepository repository)
        {
            _repository = repository;
        }


        [HttpPost("login")]
        public IActionResult Login(string email, string password)
        {
            var teacher = _repository.GetByEmail(email);

            if (teacher == null)
            {
                return BadRequest("Email not found.");
            }

            if (teacher.Password != password)
            {
                return BadRequest("Invalid password.");
            }

            var token = TokenAuth.GenerateToken(teacher);
            return Ok(new { message = "Login successful.", token });
        }

        
        [HttpPost("register")]
        public IActionResult Register(string name, string email, string password)
        {
            
            var existingClient = _repository.GetByEmail(email);
            if (existingClient != null)
            {
                return BadRequest("Email is already registered.");
            }

          
            var newTeacher = new Teacher
            {
                Name = name,
                Email = email,
                Password = password 
            };

            _repository.Add(newTeacher);

            return Ok(new { message = "Registration successful." });
        }

       
    }
}

