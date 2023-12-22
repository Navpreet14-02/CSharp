using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BloodGuardianAPI.Models
{
    public class BloodTransferReceipt
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }

        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string Receipt_Type { get; set; }
        public DateTime BloodTransferDate { get; set; }
        
        public int BloodAmount { get; set; }
        [Required]
        public int BankId { get; set; }
        [ForeignKey("BankId")]
        [JsonIgnore]
        public BloodBank BloodBank { get; set; }
        [Required]
        public int BloodId { get; set; }
        [ForeignKey("BloodId")]
        [JsonIgnore]
        public virtual BloodGroup BloodGroup { get; set; }



    }
}
