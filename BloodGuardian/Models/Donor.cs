using BloodGuardian.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodGuardian.View;


namespace BloodGuardian.Models
{
    internal enum roles
    {
        Admin,
        Donor,
        BloodBankManager,
    }

    internal class Donor
    {
        public static List<string> BloodGroups =new List<string>{ "A+", "A-","B+","B-","O+","O-","AB+","AB-" };

        public int Donorid { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public long Phone { get; set; }
        public string Email { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Password { get; set; }
        public string BloodGrp{ get; set; }
        public roles Role { get; set; }





        public static Donor CreateUser()
        {
            Donor newDonor = new Donor();
            Console.Write("Enter your Name: ");
            newDonor.Name = Console.ReadLine();

            Console.Write("Enter your Age: ");
            newDonor.Age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter your Phone: ");
            newDonor.Phone = Convert.ToInt64(Console.ReadLine());

            Console.Write("Enter your Email: ");
            newDonor.Email = Console.ReadLine();

            Console.Write("Enter your Role - Donor or BloodBankManager: ");
            newDonor.Role = Enum.Parse<roles>(Console.ReadLine());

            Console.Write("Enter your State (In case you are a Blood Bank Manager, Enter its State ): ");
            newDonor.State = Console.ReadLine();

            Console.Write("Enter your City (In case you are a Blood Bank Manager, Enter its City ): ");
            newDonor.City = Console.ReadLine();

            Console.Write("Enter your Address (In case you are a Blood Bank Manager, Enter its Address ): ");
            newDonor.Address = Console.ReadLine();

            Console.Write("Enter your Password: ");
            newDonor.Password = Console.ReadLine();

            Console.Write("Enter your Blood Group - A+,A-,B+,B-,O+,O-,AB+,AB-: ");
            newDonor.BloodGrp = Console.ReadLine();


            return newDonor;
        }

        public static Donor UpdateProfile(Donor d)
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("Below are your old details:");
            Console.WriteLine("Name: "+d.Name);
            Console.WriteLine("Age: " + d.Age);
            Console.WriteLine("Phone: " + d.Phone);
            Console.WriteLine("Email: " + d.Email);
            Console.WriteLine("State: "+d.State);
            Console.WriteLine("City: " + d.City);
            Console.WriteLine("Address: "+d.Address);
            Console.WriteLine("Password: "+d.Password);
            if(d.Role==roles.BloodBankManager) Console.WriteLine("Blood Bank Name: "+DBHandler.FindBloodBank(d).BankName);


            Console.WriteLine("==============================");
            Console.WriteLine("Enter your new Details: ");

            Donor updatedDonor = new Donor();
            updatedDonor.Donorid = d.Donorid;

            Console.Write("Enter your Name: ");
            var nameInput = Console.ReadLine();
            updatedDonor.Name = nameInput==String.Empty ? d.Name:nameInput;

            Console.Write("Enter your Age: ");
            var ageInput = Console.ReadLine();
            updatedDonor.Age = ageInput=="" ? d.Age:Convert.ToInt32(ageInput);

            Console.Write("Enter your Phone: ");
            var phoneInput = Console.ReadLine();
            updatedDonor.Phone = phoneInput == "" ? d.Phone : Convert.ToInt64(phoneInput);

            Console.Write("Enter your Email: ");
            var emailInput = Console.ReadLine();
            updatedDonor.Email = emailInput == String.Empty ? d.Email : emailInput;

            Console.Write("Enter your State (In case you are a Blood Bank Manager, Enter its State ): ");
            var stateInput = Console.ReadLine();
            updatedDonor.State = stateInput == String.Empty ? d.State : stateInput;

            Console.Write("Enter your City (In case you are a Blood Bank Manager, Enter its City ): ");
            var cityInput = Console.ReadLine();
            updatedDonor.City = cityInput == String.Empty ? d.City : cityInput;

            Console.Write("Enter your Address (In case you are a Blood Bank Manager, Enter its Address ): ");
            var addressInput = Console.ReadLine();
            updatedDonor.Address = addressInput == String.Empty ? d.Address : addressInput;

            Console.Write("Enter your Password: ");
            var passInput = Console.ReadLine();
            updatedDonor.Password = passInput == String.Empty ? d.Password : passInput;

            updatedDonor.Role = d.Role;
            updatedDonor.BloodGrp = d.BloodGrp;


            DBHandler.UpdateDonor(d, updatedDonor);

            if (updatedDonor.Role == roles.Admin)
            {
                //App.AdminMenu(d);
            }
            else if (updatedDonor.Role == roles.BloodBankManager)
            {
                App.BBManagerMenu(d);
            }
            else
            {
                App.DonorMenu(d);
            }

            return updatedDonor;

        }


    }
}
