using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BloodGuardianAPI.Models
{
    public class BloodGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<BankBloodGroupMapping> BankBloodGroupMapping { get; set; }
        [JsonIgnore]
        public ICollection<BloodTransferReceipt> BloodTransferReceipts{ get; set; }



    }
}
