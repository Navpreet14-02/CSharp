using BloodGuardian.Common;
using BloodGuardian.Controller.Interfaces;
using BloodGuardian.Models;
using BloodGuardian.View.Interfaces;

namespace BloodGuardian.View
{
    public class DonorDashboard : IDonorDashboard
    {
        private IDonor _donorController;

        public DonorDashboard(IDonor donorController)
        {
            _donorController = donorController;
        }



        public Donor InputUpdatedUserInfo(Donor oldDonor)
        {


            Donor updatedDonor = new Donor();


            Console.WriteLine(Message.EnterName);
            String name = InputHandler.InputName(true);
            updatedDonor.Name = name == String.Empty ? oldDonor.Name : name;


            Console.WriteLine(Message.EnterUserName);
            String uname = InputHandler.InputUserName(true);
            updatedDonor.UserName = uname == String.Empty ? oldDonor.UserName : uname;


            Console.WriteLine(Message.EnterAge);
            int age = InputHandler.InputAge(true);
            updatedDonor.Age = age == -1 ? oldDonor.Age : Convert.ToInt32(age);


            Console.WriteLine(Message.EnterPhone);
            long phone = InputHandler.InputPhone(true);
            updatedDonor.Phone = phone == -1 ? oldDonor.Phone : Convert.ToInt64(phone);


            Console.WriteLine(Message.EnterEmail);
            string email = InputHandler.InputEmail(true);
            updatedDonor.Email = email == String.Empty ? oldDonor.Email : email;


            Console.WriteLine(Message.EnterState);
            string state = InputHandler.InputState(true);
            updatedDonor.State = state == String.Empty ? oldDonor.State : state;


            Console.WriteLine(Message.EnterCity);
            string city = InputHandler.InputCity(true);
            updatedDonor.City = city == String.Empty ? oldDonor.City : city;


            Console.WriteLine(Message.EnterAddress);
            string address = InputHandler.InputAddress(true);
            updatedDonor.Address = address == String.Empty ? oldDonor.Address : address;


            Console.WriteLine(Message.EnterPassword);
            Console.WriteLine();
            string password = InputHandler.InputPassword(true);
            updatedDonor.Password = password == String.Empty ? oldDonor.Password : password;

            updatedDonor.Donorid = oldDonor.Donorid;

            updatedDonor.Role = oldDonor.Role;
            updatedDonor.BloodGrp = oldDonor.BloodGrp;

            return updatedDonor;
        }

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


            Console.WriteLine(Message.DoubleDashDesign);
            Console.WriteLine(Message.EnterNewDetails);

            Donor updatedDonor = InputUpdatedUserInfo(d);

            _donorController.UpdateProfile(d, updatedDonor);

            return updatedDonor;

        }

        public void ViewBloodDonationHistory(Donor d)
        {
            var BankdepositLists = _donorController.GetBloodDonationHistory(d);


            var isFound = false;

            foreach (KeyValuePair<BloodBank, List<BloodTransferReceipt>> entry in BankdepositLists)
            {


                entry.Value.ForEach((receipt) =>
                {
                    if (receipt.CustomerEmail.Equals(d.Email) && receipt.CustomerPhone.Equals(d.Phone))
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

    }
}
