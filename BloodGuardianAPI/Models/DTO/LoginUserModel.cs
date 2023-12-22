using System.ComponentModel.DataAnnotations;

namespace BloodGuardianAPI.Models.DTO
{
    public class LoginUserModel
    {
        [Required]
        [RegularExpression((@"^[A-z][A-z0-9]{2,28}$"))]
        [MinLength(4)]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password { get; set; }
    }
}
