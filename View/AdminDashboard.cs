using BloodGuardian.Common;
using BloodGuardian.Common.Enums;
using BloodGuardian.Controller;
using BloodGuardian.Controller.Interfaces;
using BloodGuardian.View.Interfaces;
using BloodGuardian.Database;
using BloodGuardian.Models;
using BloodGuardian.Database.Interface;

namespace BloodGuardian.View
{
    public class AdminDashboard : IAdminDashboard
    {
        private static IAdmin _donorController;
        private static IRemoveRequest _requestController;
        private static IAdminBloodBank _bankController;
        private static IAdminBloodDonationCamp _campController;

        public AdminDashboard(IAdmin donorController,IRemoveRequest requestController,IAdminBloodBank bankController, IAdminBloodDonationCamp campController)
        {
            _donorController = donorController;
            _requestController = requestController;
            _bankController = bankController;
            _campController = campController;
        }

        public void CreateAdmin(Donor d)
        {

            Donor newAdmin = new Donor();

            Console.WriteLine(Message.EnterAdminName);
            newAdmin.Name = InputHandler.InputName(false);

            Console.WriteLine(Message.EnterAdminUserName);
            newAdmin.UserName = InputHandler.InputUserName(false);

            Console.WriteLine(Message.EnterAdminAge);
            newAdmin.Age = InputHandler.InputAge(false);


            Console.WriteLine(Message.EnterAdminPhone);
            newAdmin.Phone = InputHandler.InputPhone(false);

            Console.WriteLine(Message.EnterAdminEmail);
            newAdmin.Email = InputHandler.InputEmail(false);

            Console.WriteLine(Message.EnterAdminState);
            newAdmin.State = InputHandler.InputState(false);

            Console.WriteLine(Message.EnterAdminCity);
            newAdmin.City = InputHandler.InputCity(false);


            Console.WriteLine(Message.EnterAdminAddress);
            newAdmin.Address = InputHandler.InputAddress(false);


            Console.WriteLine(Message.EnterAdminPassword);
            newAdmin.Password = InputHandler.InputPassword(false);

            Console.WriteLine(Message.EnterBloodGroup);
            newAdmin.BloodGrp = InputHandler.InputBloodGroup(false);

            _donorController.AddAdmin(newAdmin);

        }



        public void AdminViewDonors(Donor d)
        {

            var donors = _donorController.GetDonors();

            if (donors == null || donors.Count == 0)
            {
                Console.WriteLine(Message.NoRegisteredDonors);
                return;
            }

            donors.ForEach(donor =>
            {

                Console.WriteLine(Message.SingleDashDesign);
                Console.WriteLine("id: " + donor.Donorid);
                Console.WriteLine("Name: " + donor.Name);
                Console.WriteLine("UserName: " + donor.UserName);
                Console.WriteLine("Age: " + donor.Age);
                Console.WriteLine("Phone: " + donor.Phone);
                Console.WriteLine("Email: " + donor.Email);
                Console.WriteLine("Address: " + donor.Address);
                Console.WriteLine("Blood Group: " + donor.BloodGrp);
                Console.WriteLine("Role: " + donor.Role.ToString());
                Console.WriteLine(Message.SingleDashDesign);

            }
            );


        }

        public void RemoveDonor(Donor d)
        {

            AdminViewDonors(d);

            Console.WriteLine();

            Console.Write(Message.EnterDonorId);
            int donorId = InputHandler.InputId();

            var donor = _donorController.GetDonors().ElementAtOrDefault(donorId);

            if (donor == null)
            {
                Console.WriteLine(Message.WrongDonorId);
            }
            else
            {
                _donorController.AdminRemoveDonor(donor);
            }
        }


        public void AdminViewBloodBanks(Donor d)
        {

            var banks = _bankController.GetBloodBanks();

            if (banks.Count == 0)
            {
                Console.WriteLine(Message.NoRegisteredBloodBanks);
                return;
            }

            banks.ForEach(bank =>
            {
                Console.WriteLine(Message.SingleDashDesign);
                Console.WriteLine("Id: " + bank.BankId);
                Console.WriteLine("Bank Name: " + bank.BankName);
                Console.WriteLine("Bank Manager User Name: " + bank.ManagerUserName);
                Console.WriteLine("Manager Name: " + bank.ManagerName);
                Console.WriteLine("Manager Email: " + bank.ManagerEmail);
                Console.WriteLine("Manager Contact: " + bank.Contact);
                Console.WriteLine("Address: " + bank.Address);
                Console.WriteLine(Message.SingleDashDesign);

            });

        }

        public void RemoveBloodBank(Donor d)
        {
            AdminViewBloodBanks(d);

            Console.WriteLine(Message.DoubleDashDesign);
            Console.WriteLine(Message.EnterBloodBankId);


            int bankid = InputHandler.InputId();

            var bank = _bankController.FindBloodBankbyId(bankid);

            if (bank == null)
            {
                Console.WriteLine(Message.WrongBankId);
            }
            else
            {
                _bankController.AdminRemoveBloodBank(bank);
            }



        }


        public void ViewBloodDonationCamps(Donor d)
        {

            var banks = _bankController.GetBloodBanks();

            if (banks == null || banks.Count == 0)
            {
                Console.WriteLine(Message.NoDonationCampOrganized);
                return;
            }

            banks.ForEach((bank) =>
            {
                Console.WriteLine(Message.DoubleDashDesign);
                var camps = bank.BloodDonationCamps;

                Console.WriteLine($"Camps organized by {bank.BankName}, ID - {bank.BankId}:");

                if (camps.Count == 0)
                {
                    Console.WriteLine(Message.NoDonationCampsBank);
                }
                camps.ForEach((camp) =>
                {
                    Console.WriteLine(Message.SingleDashDesign);
                    Console.WriteLine("Camp ID: " + camp.camp_id);
                    Console.WriteLine("Camp Date: " + camp.Date);
                    Console.WriteLine($"Camp Duration:{camp.Start_Time} to {camp.End_Time}");
                    Console.WriteLine("Camp Address: " + camp.Camp_Address);
                    Console.WriteLine(Message.SingleDashDesign);
                    Console.WriteLine();


                });
            });
        }

        public void RemoveBloodDonationCamp(Donor d)
        {

            ViewBloodDonationCamps(d);


            Console.WriteLine(Message.DoubleDashDesign);
            Console.WriteLine(Message.RemoveCampSteps);
            Console.WriteLine(Message.DoubleDashDesign);



            Console.Write(Message.EnterBankId);
            int bankid = InputHandler.InputId();

            //_campController.AdminRemoveBloodDonationCamp(d,bankid);


            var bank = _bankController.GetBloodBanks().ElementAtOrDefault(bankid);

            if (bank == null)
            {
                Console.WriteLine(Message.WrongBankId);
            }
            else
            {

                Console.WriteLine();


                Console.Write(Message.EnterCampId);
                int campid = InputHandler.InputId();

                _campController.RemoveBloodDonationCamps(bank, campid);

                //var choosenCamp = bank.BloodDonationCamps.ElementAtOrDefault(campid);

                //if (choosenCamp == null)
                //{
                //    Console.WriteLine(Message.WrongCampId);
                //}

                //RemoveBloodDonationCamps(bank, d);
            }


        }


        public void RemoveRequest(Donor d)
        {

            Console.Write(Message.EnterRequestId);
            int requestId = InputHandler.InputId();

            var request = _requestController.GetBloodRequests().ElementAtOrDefault(requestId);

            if (request == null)
            {
                Console.WriteLine(Message.WrongRequestId);
            }
            else
            {
                _requestController.AdminRemoveRequest(request);
            }
        }
    }
}
