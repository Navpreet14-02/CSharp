using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BloodGuardianAPI.Models
{
    public class BloodDonationCamp
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Date)] 
        public DateTime Camp_Date { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(3)]

        public string Camp_City { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string Camp_State { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string Camp_Address { get; set; }
        [Required]
        [DataType(DataType.Time)]  
        public DateTime Start_Time { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public DateTime End_Time { get; set;}
        public int BankId { get; set; }
        [ForeignKey("BankId")]
        [JsonIgnore]
        public BloodBank BloodBank { get; set; }


    }
}
