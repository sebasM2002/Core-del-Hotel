using System.ComponentModel.DataAnnotations;

namespace CoreHotel.DTO
{
    public class ResetPasswordDTO
    {
        [Required(ErrorMessage = "The password  is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "The confirmpassword  is required")]
        [Compare("Password", ErrorMessage = "The passwords fields do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
