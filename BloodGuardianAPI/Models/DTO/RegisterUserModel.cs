using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodGuardianAPI.Models.DTO
{
    public class RegisterUserModel
    {
        [Required]
        [RegularExpression((@"^[A-z][A-z0-9]{2,28}$"))]
        [MinLength(4)]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(4)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(10)]
        public string Phone_Number { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [MaxLength(50)]
        public string City { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password { get; set; }
        [Required]
        [MaxLength(50)]
        public string State { get; set; }
        [Required]
        [MaxLength(50)]
        public string Address { get; set; }
        [Required]
        public string BloodGroup { get; set; }
        [Required]
        public int Role { get; set; }

    }
}
