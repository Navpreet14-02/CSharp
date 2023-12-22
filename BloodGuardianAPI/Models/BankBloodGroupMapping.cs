using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodGuardianAPI.Models
{
    public class BankBloodGroupMapping
    {
        public int Id { get; set; }
        public int BankId { get; set; }
        public int BloodId { get; set; }
        public int BloodAmount { get; set; }
        [ForeignKey("BloodId")]
        public virtual BloodGroup BloodGroup { get; set; }
        [ForeignKey("BankId")]
        public virtual BloodBank BloodBank { get; set; }

    }
}
