using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace BloodGuardianAPI.Models
{
    public class BloodBank
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string BankName { get; set; }
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
        public string IdentityUserId { get; set; }
        [ForeignKey("IdentityUserId")]
        [JsonIgnore]
        public IdentityUser User { get; set; }
        [JsonIgnore]
        public ICollection<BankBloodGroupMapping> BloodUnits { get; set; }
        [JsonIgnore]
        public ICollection<BloodDonationCamp> BloodDonationCamps { get; set; }
        [JsonIgnore]
        public ICollection<BloodTransferReceipt> BloodTransferReceipts { get; set; }


    }
}
