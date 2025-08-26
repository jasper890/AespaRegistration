using System.ComponentModel.DataAnnotations;

namespace AespaRegistration.Models
{
    public class UserRegistration
    {
        public int UserID { get; set; }
        [Required (ErrorMessage = "Firstname is Required")]
        public string? FirstName { get; set; }

        [Required (ErrorMessage = "Lastname is Required")]
        [MinLength(1, ErrorMessage ="Lastname must be at least 2 characters")]
        public string?  LastName { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$",
          ErrorMessage = "Invalid email format.")]
        public string? Email { get; set; }
        [Required (ErrorMessage ="Password is required")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[\W_]).{8,}$",
        ErrorMessage = "Password must be at least 8 characters, contain 1 uppercase letter, and 1 special character.")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required.")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string? ConfirmPassword { get; set; }
        [Required (ErrorMessage = "Age is Required")]
        [Range(18, int.MaxValue, ErrorMessage = "Age must be at least 18.")]
        public int Age { get; set; } = 0; 
    }
}