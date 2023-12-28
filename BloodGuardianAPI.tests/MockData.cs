using BloodGuardianAPI.Models;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;
using System.Text;
using System.Linq;

namespace BloodGuardianAPI.tests
{
    public class MockData
    {


        public static IEnumerable<BloodRequest> Requests = new List<BloodRequest>()
        {
            new BloodRequest()
            {
                Id=1,
                RequesterName= "Kishan",
                BloodRequirementType= 6,
                RequesterPhone= "2843752384",
                Address= "Patiala,Punjab"
            },
            new BloodRequest()
            {
                Id=2,
                RequesterName= "Ravi",
                BloodRequirementType= 4,
                RequesterPhone= "2843752384",
                Address= "Noida,Uttar Pradesh"
            }
        };

        public static IEnumerable<BloodBank> BloodBanks = new List<BloodBank>()
        {
            new BloodBank()
            {
                Id = 1,
                BankName = "Varun-BloodBank",
                State = "Punjab",
                City = "Patiala",
                Address = "Patiala,Punjab",
                IdentityUserId = "1",
            },
            new BloodBank()
            {
                Id = 2,
                BankName = "Dhawan-BloodBank",
                State = "Uttar Pradesh",
                City = "Noida",
                Address = "Noida,Uttar Pradesh",
                IdentityUserId = "2",
            }
        };


        public static IEnumerable<IdentityUser> IdentityUsers = new List<IdentityUser>()
        {
            new IdentityUser()
            {
                Id="1",
                UserName="Param14",
                Email="param14@gmail.com"
            },
            new IdentityUser()
            {
                Id="2",
                UserName="Vishal",
                Email="vishal14@gmail.com"

            },
        };

        public static IEnumerable<UserDetails> Users = new List<UserDetails>()
        {
            new UserDetails()
            {
                Id=1,
                Name = "Param",
                Age = 22,
                Phone_Number = "4734435746",
                Email = "param14@gmail.com",
                State = "Punjab",
                Address = "Mohali, Punjab",
                City = "Mohali",
                BloodId = 1,
                IdentityUser= IdentityUsers.ElementAt(0),
                IdentityUserId="1",
                
            },
            new UserDetails()
            {
                Id=2,
                Name = "Vishal",
                Age = 22,
                Phone_Number = "4734435746",
                Email = "vishal14@gmail.com",
                State = "Punjab",
                Address = "Kharar, Punjab",
                City = "Kharar",
                BloodId = 2,
                IdentityUser= IdentityUsers.ElementAt(1),
                IdentityUserId="2",



            },
        };




        public static IEnumerable<BloodDonationCamp> Camps = new List<BloodDonationCamp>()
        {
            new BloodDonationCamp()  {
                Id=1,
                Camp_Date=DateTime.Parse("12/25/2023"),
                Camp_City="Patiala",
                Camp_State="Punjab",
                Camp_Address="Patiala,Punjab",
                Start_Time=DateTime.Parse("6:00"),
                End_Time=DateTime.Parse("20:00"),
                BankId=1

            },
            new BloodDonationCamp()  {
                Id=2,
                Camp_Date=DateTime.Parse("12/25/2023"),
                Camp_City="Noida",
                Camp_State="Uttar Pradesh",
                Camp_Address="Noida,Uttar Pradesh",
                Start_Time=DateTime.Parse("6:00"),
                End_Time=DateTime.Parse("20:00"),
                BankId=2

            }
        };

        public static IEnumerable<BloodTransferReceipt> Receipts = new List<BloodTransferReceipt>()
        {
            new BloodTransferReceipt()  
            {
                CustomerName= "Ravi2",
                BloodId= 2,
                CustomerEmail= "ravi214@gmail.com",
                CustomerPhone= "4569804456",
                BloodTransferDate= DateTime.Parse("12/19/2023"),
                BloodAmount= 100,
                Receipt_Type="Deposit",
                BankId=1,
            },

            new BloodTransferReceipt()
            {
                CustomerName= "Kishan",
                BloodId= 2,
                CustomerEmail= "Kishan214@gmail.com",
                CustomerPhone= "4569804456",
                BloodTransferDate= DateTime.Parse("12/19/2023"),
                BloodAmount= 100,
                Receipt_Type="WithDraw",
                BankId = 1,
            },

            new BloodTransferReceipt()
            {
                CustomerName= "Param",
                BloodId= 2,
                CustomerEmail= "param14@gmail.com",
                CustomerPhone= "4569804456",
                BloodTransferDate= DateTime.Parse("12/19/2023"),
                BloodAmount= 100,
                Receipt_Type="Deposit",
                BankId=1,
            },
        };


        public static IEnumerable<BloodGroup> BloodGroups = new List<BloodGroup>()
        {
            new BloodGroup()
            {
                Id=1,
                Name="A+",
            },
            new BloodGroup()
            {
                Id=2,
                Name="A-",
            },
            new BloodGroup()
            {
                Id=3,
                Name="B+",
            },
            new BloodGroup()
            {
                Id=4,
                Name="B-",
            },
        };

        public static IEnumerable<BankBloodGroupMapping> BankBloodGrpMap = new List<BankBloodGroupMapping>()
        {
            new BankBloodGroupMapping()
            {
                BankId=1,
                BloodId=2,
                BloodAmount=50,
            },
            new BankBloodGroupMapping()
            {
                BankId=2,
                BloodId=4,
                BloodAmount=100,
            },
        };

    }
}
