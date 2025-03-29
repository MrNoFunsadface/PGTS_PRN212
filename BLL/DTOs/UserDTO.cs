using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class UserRequestDTO
    {
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email is required"), EmailAddress]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Password is required")]
        [StringLength(16, MinimumLength = 4, ErrorMessage = "Your new password must be between 4 and 16 characters")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "ConfirmPassword is required")]
        [Compare("Password", ErrorMessage = "The confirm password does not match password")]
        public string ConfirmPassword { get; set; } = null!;

        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^0\d{9}$", ErrorMessage = "Phone number must start with 0 and be exactly 10 digits long")]
        public string? Phone { get; set; }

        public bool isAdmin { get; set; }
        public bool isActive { get; set; }
    }

    public class UserResponseDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string Email { get; set; } = null!;

        public string? Password { get; set; }
        public string? Phone { get; set; }

        public bool isAdmin { get; set; }
        public bool isActive { get; set; }
    }

    public class UserLoginDTO
    {
        [Required(ErrorMessage = "Email is required"), EmailAddress]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = null!;
    }

    public class UserResetPasswordDTO
    {
        [Required(ErrorMessage = "Password is required")]
        [StringLength(16, MinimumLength = 4, ErrorMessage = "Your new password must be between 4 and 16 characters")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "ConfirmPassword is required")]
        [Compare("Password", ErrorMessage = "The confirm password does not match password")]
        public string ConfirmPassword { get; set; } = null!;
    }

    public class UserProfileDTO
    {
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email is required"), EmailAddress]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^0\d{9}$", ErrorMessage = "Phone number must start with 0 and be exactly 10 digits long")]
        public string? Phone { get; set; }
    }
}
