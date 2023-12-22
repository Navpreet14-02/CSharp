using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BloodGuardianAPI.Models
{
    public class BloodRequest
    {
        public int Id { get; set; }
        [Required]
        public string RequesterName { get; set; }
        [Required]

        public int BloodRequirementType { get; set; }
        [ForeignKey("BloodRequirementType")]
        [JsonIgnore]
        public BloodGroup BloodGroup { get; set; }
        [Required]
        [MaxLength(10)]
        public string RequesterPhone { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
