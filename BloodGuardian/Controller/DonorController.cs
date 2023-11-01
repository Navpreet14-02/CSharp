using BloodGuardian.Database;
using BloodGuardian.Models;
using BloodGuardian.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodGuardian.Common;

namespace BloodGuardian.Controller
{
    internal class DonorController
    {
        public Donor UpdateProfile(Donor d)
        {
            Console.WriteLine(Message.SingleDashDesign);
            Console.WriteLine(Message.ShowOldDetails);
            Console.WriteLine("Name: " + d.Name);
            Console.WriteLine("User Name: " + d.UserName);
            Console.WriteLine("Age: " + d.Age);
            Console.WriteLine("Phone: " + d.Phone);
            Console.WriteLine("Email: " + d.Email);
            Console.WriteLine("State: " + d.State);
            Console.WriteLine("City: " + d.City);
            Console.WriteLine("Address: " + d.Address);
            Console.WriteLine("Password: " + d.Password);
            if (d.Role == roles.BloodBankManager) Console.WriteLine("Blood Bank Name: " + DBHandler.Instance.FindBloodBank(d, -1).BankName);


            Console.WriteLine(Message.DoubleDashDesign);
            Console.WriteLine(Message.EnterNewDetails);

            Donor updatedDonor = DonorUI.UpdatedUserInfo(d);



            DBHandler.Instance.UpdateDonor(d, updatedDonor);


            return updatedDonor;

        }

        public void ViewDonors(Donor d)
        {
            DBHandler.Instance.ReadDonors().ForEach(donor => {

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

        public Donor FindDonor(string username, string password)
        {

            var donorList = DBHandler.Instance.ReadDonors();
            Donor d = new Donor();
            if (password == null)
            {
                d = donorList.FirstOrDefault((donor) => donor.UserName == username);

            }
            else
            {
                d = donorList.Find((donor) => donor.UserName == username && donor.Password == password);

            }

            return d;
        }

        public void RemoveDonor(Donor d)
        {

            ViewDonors(d);

            Console.WriteLine();

            int donorId;
            while (true)
            {
                Console.Write(Message.EnterDonorId);
                string input = Console.ReadLine();

                int res;
                if (input == String.Empty || !int.TryParse(input, out res))
                {
                    Console.WriteLine(Message.EnterValidInput);
                    continue;
                }

                donorId = Convert.ToInt32(input);
                Console.WriteLine(Message.EnterDonorId);
                break;

            }

            var donor = DBHandler.Instance.ReadDonors().ElementAtOrDefault(donorId);

            if (donor == null)
            {
                Console.WriteLine(Message.WrongDonorId);
            }
            else
            {

                DBHandler.Instance.DeleteDonor(donorId);
                if (d.Role == roles.BloodBankManager)
                {
                    BloodBank bank = DBHandler.Instance.FindBloodBank(d, -1);
                    DBHandler.Instance.DeleteBloodBank(null, bank.BankId);
                }
            }



        }

        public void ViewBloodDonationHistory(Donor d)
        {
            var BankdepositLists = new Dictionary<BloodBank, List<BloodTransferReceipt>>();
            DBHandler.Instance.ReadBloodBanks().ForEach(bank =>
            {
                BankdepositLists.Add(bank, bank.Blood_Deposit_Record);
            });


            var isFound = false;

            foreach (KeyValuePair<BloodBank, List<BloodTransferReceipt>> entry in BankdepositLists)
            {


                entry.Value.ForEach((receipt) =>
                {
                    if (receipt.CustomerEmail == d.Email && receipt.CustomerPhone == d.Phone)
                    {
                        isFound = true;

                        Console.WriteLine();
                        Console.WriteLine(Message.SingleDashDesign);
                        Console.WriteLine($"Bank Name: {entry.Key.BankName}");
                        Console.WriteLine($"Address: {entry.Key.Address}");
                        Console.WriteLine($"Date: {receipt.BloodTransferDate}");
                        Console.WriteLine(Message.SingleDashDesign);


                    }
                });



            }

            if (!isFound)
            {
                Console.WriteLine(Message.NoBloodDonated);
            }


        }

        public void AddAdmin(Donor d)
        {

            Donor newAdmin = AdminUI.InputAdmin(d);

            newAdmin.Role = roles.Admin;

            DBHandler.Instance.AddDonor(newAdmin);


        }
    }
}
