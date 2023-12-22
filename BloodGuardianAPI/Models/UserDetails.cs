using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BloodGuardianAPI.Models
{
    public class UserDetails
    {
        public int Id { get; set; }
        [Required]
        public string IdentityUserId { get; set; }
        [ForeignKey("IdentityUserId")]
        [JsonIgnore]
        public IdentityUser IdentityUser { get; set; }

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
        [MaxLength(50)]
        public string State { get; set; }

        [Required]
        [MaxLength(50)]
        public string Address { get; set; }

        [Required]
        public int BloodId { get; set; }
        [ForeignKey("BloodId")]
        public BloodGroup BloodGroup { get; set; }



    }
}
