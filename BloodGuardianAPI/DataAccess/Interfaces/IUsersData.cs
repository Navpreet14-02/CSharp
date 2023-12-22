using BloodGuardianAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;

namespace BloodGuardianAPI.DataAccess.Interfaces
{
    public interface IUsersData
    {
        IEnumerable<UserDetails> GetUsers();
        UserDetails GetUser(int id);
        void AddUser(UserDetails user);
        void RemoveUser(UserDetails user);
        void UpdateUser(int userId, JsonPatchDocument<UserDetails> updatedUser);
        int FindBloodIdByName(string bloodgroup);
        string FindBloodGroupById(int id);
    }
}
