using System.ComponentModel.DataAnnotations;

namespace CoreHotel.DTO
{
    public class UserInfoDTO
    {
        [EmailAddress(ErrorMessage = "The Email is no valid")]
        [Required(ErrorMessage = "The user is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "The password  is required")]
        public string Password { get; set; }
    }
}
