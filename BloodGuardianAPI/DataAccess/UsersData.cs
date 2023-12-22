using BloodGuardianAPI.Data;
using BloodGuardianAPI.DataAccess.Interfaces;
using BloodGuardianAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BloodGuardianAPI.DataAccess
{
    public class UsersData : IUsersData
    {

        private readonly AppDbContext _dbContext;

        public UsersData(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<UserDetails> GetUsers()
        {
            return _dbContext.UserDetails;
        }

        public UserDetails GetUser(int id)
        {
            return _dbContext.UserDetails.Find(id);
        }

        public void AddUser(UserDetails user)
        {

            _dbContext.UserDetails.Add(user);
            _dbContext.SaveChanges();


        }

        public void RemoveUser(UserDetails user)
        {

            _dbContext.UserDetails.Remove(user);
            _dbContext.SaveChanges();


        }


        public int FindBloodIdByName(string bloodgroup)
        {

            return _dbContext.BloodGroups.FirstOrDefault(b=>b.Name == bloodgroup).Id;
        }

        public string FindBloodGroupById(int id)
        {

            return _dbContext.BloodGroups.Find(id).Name;
        }

        public void UpdateUser(int userId, JsonPatchDocument<UserDetails> updatedUser)
        {

            var user = GetUsers().FirstOrDefault(u => u.Id == userId);


            updatedUser.ApplyTo(user);
            _dbContext.SaveChanges();
        }


    }
}
