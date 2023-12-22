using BloodGuardianAPI.Models;
using BloodGuardianAPI.Models.DTO;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BloodGuardianAPI.Business.Interfaces
{
    public interface IUsersBusiness
    {
        IEnumerable<UserDetails> GetAllUsers();
        Task<bool> RemoveAUser(int userId);
        bool UpdateUserProfile(int userId, JsonPatchDocument<UserDetails> updatedUser);
        Task<List<BloodDonationHistoryDTO>> GetUserBloodDonationHistory(int userId);
    }

}
