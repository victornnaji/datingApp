using System.ComponentModel.DataAnnotations;

namespace DatingApp.Api.DTOs
{
    public class UserForRegisterDTO
    {
        [Required]
        public string username { get; set; }

        [Required]
        [StringLength(8, MinimumLength=4, ErrorMessage="Minimum of 4 and maximum of 8")]
        public string password { get; set; }
    }
}