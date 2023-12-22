using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodGuardianAPI.Models.DTO
{
    public class RegisterBloodBankModel
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
        public IDictionary<string,int> BloodUnits { get; set; }
    }
}
