using AespaRegistration.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AespaRegistration.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserRegistrationController : ControllerBase
    {
        private static List<UserRegistration> registrations = new List<UserRegistration>();

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserRegistration user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    success = false,
                    errors = ModelState.Values.SelectMany(v => v.Errors)
                                              .Select(e => e.ErrorMessage)
                });
            }

            user.UserID = registrations.Any() ? registrations.Max(u => u.UserID) + 1 : 1;

            // Use PasswordHasher instead of BCrypt
            var passwordHasher = new PasswordHasher<UserRegistration>();
            user.Password = passwordHasher.HashPassword(user, user.Password!);

            user.ConfirmPassword = null;
            registrations.Add(user);

            return Ok(new
            {
                success = true,
                message = "Registration successful",
                data = new
                {
                    user.UserID,
                    user.FirstName,
                    user.LastName,
                    user.Email,
                    user.Age
                }
            });
        }
    }
}