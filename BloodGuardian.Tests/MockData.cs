using BloodGuardian.Common.Enums;
using BloodGuardian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodGuardian.Tests
{
    public class MockData
    {
        public static List<Donor> _donorList = new List<Donor>
        {

            new Donor(){Donorid= 0,UserName= "Tarun14",Name= "Tarun",Age= 25,Phone= 1293412395,Email= "tarun14@gmail.com",State= "Punjab",Address= "Patiala,Punjab",City= "Patiala",Password= "Tarun1402",BloodGrp= "B+",Role= Roles.Donor },
            new Donor() {Donorid= 1,UserName= "Shahrukh14",Name= "Shahrukh",Age= 35,Phone= 3953598345,Email= "shah@wg.com",State= "Punjab",Address= "Patiala,Punjab",City= "Patiala",Password= "Sharhrukh14",BloodGrp= "O+",Role= Roles.BloodBankManager},

            new Donor(){Donorid= 2,UserName= "Varun14",Name= "Varun Dhawan",Age= 26,Phone= 5689305685,Email= "varun@gmail.com",State= "Punjab",Address= "Patiala,Punjab",City= "Patiala",Password= "Varun1402",BloodGrp= "O+",Role= Roles.BloodBankManager}


        };

        public static List<BloodBank> _banksList = new List<BloodBank>()
        {
            new BloodBank()
            {
                BankId= 0,
                ManagerName= "Shahrukh",
                ManagerUserName= "Shahrukh14",
                ManagerEmail= "shah@wg.com",
                Contact= 3953598345,
                BankName= "shahrukh-bloodbank",
                State= "Punjab",
                Address= "Patiala,Punjab",
                City= "Patiala",
                Blood_WithDrawal_Record= new List<BloodTransferReceipt>(),
                Blood_Deposit_Record=new List<BloodTransferReceipt>(),
                BloodUnits= new Dictionary<string,int>{
                    { "A+", 200 },
                    { "A-", 200 },
                    { "B+", 200 },
                    { "B-", 300 },
                    { "O+", 100 },
                    { "O-", 100 },
                    { "AB+", 100 },
                    { "AB-", 50 }
                },
                BloodDonationCamps= new List<BloodDonationCamp>(),
            },

            new BloodBank()
            {
                BankId= 1,
                ManagerName= "Salman",
                ManagerUserName= "Salman14",
                ManagerEmail= "salman@gmail.com",
                Contact= 3953598345,
                BankName= "salman-bloodbank",
                State= "Punjab",
                Address= "Patiala,Punjab",
                City= "Patiala",
                Blood_WithDrawal_Record= new List<BloodTransferReceipt>(),
                Blood_Deposit_Record=new List<BloodTransferReceipt>(),
                BloodUnits= new Dictionary<string,int>{
                    { "A+", 200 },
                    { "A-", 200 },
                    { "B+", 200 },
                    { "B-", 300 },
                    { "O+", 100 },
                    { "O-", 100 },
                    { "AB+", 100 },
                    { "AB-", 50 }
                },
                BloodDonationCamps= new List<BloodDonationCamp>(),
            },


            new BloodBank()
            {
                BankId= 2,
                ManagerName= "Varun Dhawan",
                ManagerUserName= "Varun14",
                ManagerEmail= "varun@gmail.com",
                Contact= 5689305685,
                BankName= "dhawan-bloodbank",
                State= "Punjab",
                Address= "Patiala,Punjab",
                City= "Patiala",
                Blood_WithDrawal_Record= new List<BloodTransferReceipt>()
                {
                        new BloodTransferReceipt(){
                            Id= 0,
                            BloodDonorName= null,
                            BloodReceiverName= "Kishan1",
                            BloodGroup= "B-",
                            CustomerEmail= "kishan1@gmail.com",
                            CustomerPhone= 9045893457,
                            BloodTransferDate= DateTime.Parse("11/26/2023"),
                            BloodAmount= 50
                        },
                        new BloodTransferReceipt()
                        {
                            Id= 1,
                            BloodDonorName= null,
                            BloodReceiverName= "Kishan2",
                            BloodGroup= "B-",
                            CustomerEmail= "kishan2@gmail.com",
                            CustomerPhone= 2943529839,
                            BloodTransferDate= DateTime.Parse("11/26/2023"),
                            BloodAmount= 50
                        },
                        new BloodTransferReceipt()
                        {
                            Id= 2,
                            BloodDonorName= null,
                            BloodReceiverName= "Kishan3",
                            BloodGroup= "B+",
                            CustomerEmail= "kishan3@gmail.com",
                            CustomerPhone= 4596496948,
                            BloodTransferDate= DateTime.Parse("11/26/2023"),
                            BloodAmount= 100
                        }
                    },
                Blood_Deposit_Record=new List<BloodTransferReceipt>() {
                    new BloodTransferReceipt(){
                        Id= 0,
                        BloodDonorName= "Ravi1",
                        BloodReceiverName= null,
                        BloodGroup= "O-",
                        CustomerEmail= "ravi114@gmail.com",
                        CustomerPhone= 4395864968,
                        BloodTransferDate= DateTime.Parse("11/26/2023"),
                        BloodAmount= 100
                    },
                    new BloodTransferReceipt(){
                        Id= 1,
                        BloodDonorName= "Ravi2",
                        BloodReceiverName= null,
                        BloodGroup= "O+",
                        CustomerEmail= "ravi214@gmail.com",
                        CustomerPhone= 4569804456,
                        BloodTransferDate= DateTime.Parse("11/26/2023"),
                        BloodAmount= 100
                    },
                    new BloodTransferReceipt(){
                        Id= 2,
                        BloodDonorName= "Ravi3",
                        BloodReceiverName= null,
                        BloodGroup= "B+",
                        CustomerEmail= "ravi314@gmail.com",
                        CustomerPhone= 3294053902,
                        BloodTransferDate= DateTime.Parse("11/26/2023"),
                        BloodAmount= 100
                    }
                },
                BloodUnits= new Dictionary<string,int>{
                    { "A+", 200 },
                    { "A-", 200 },
                    { "B+", 200 },
                    { "B-", 300 },
                    { "O+", 100 },
                    { "O-", 100 },
                    { "AB+", 100 },
                    { "AB-", 50 }
                },
                BloodDonationCamps= new List<BloodDonationCamp>(){
                    new BloodDonationCamp(){
                        camp_id= 0,
                        Date= DateTime.Parse("2023-12-10"),
                        Camp_State= "Punjab",
                        Camp_City= "Patiala",
                        Camp_Address= "Patiala,Punjab",
                        Start_Time= TimeOnly.Parse("10:00"),
                        End_Time= TimeOnly.Parse("20:00")
                    }
                }
            },

        };

        public static List<Request> _requestList = new List<Request>() {
              new Request(){
                RequestId= 0,
                RequesterName= "Kishan",
                RequesterPhone= 2843752384,
                BloodRequirementType= "B-",
                Address= "Patiala,Punjab"
              },
              new Request()
              {
                RequestId= 1,
                RequesterName= "Rohan",
                RequesterPhone= 3294853928,
                BloodRequirementType= "AB-",
                Address= "Patiala,Punjab"
              },
              new Request()
              {
                RequestId= 2,
                RequesterName= "Ravi",
                RequesterPhone= 2834582347,
                BloodRequirementType= "B+",
                Address= "ravi@gmail.com"
              },

        };


    }
}
