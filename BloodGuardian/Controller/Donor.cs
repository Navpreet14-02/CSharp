using BloodGuardian.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodGuardian.View;
using System.Threading.Channels;

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




        public static Donor UpdateProfile(DBHandler Database, Donor d)
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
            if(d.Role==roles.BloodBankManager) Console.WriteLine("Blood Bank Name: "+Database.FindBloodBank(d).BankName);


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


            Database.UpdateDonor(d, updatedDonor);

            if (updatedDonor.Role == roles.Admin)
            {
                //App.AdminMenu(d);
            }
            else if (updatedDonor.Role == roles.BloodBankManager)
            {
                //App.BBManagerMenu(d);
            }
            else
            {
                //App.DonorMenu(d);
            }

            return updatedDonor;

        }

        public static void ViewDonors(DBHandler db,Donor d)
        {
            db.ReadDonors().ForEach(donor => {

                Console.WriteLine("---------------------------");
                Console.WriteLine("id: "+donor.Donorid);
                Console.WriteLine("Name: "+donor.Name);
                Console.WriteLine("Age: " + donor.Age);
                Console.WriteLine("Phone: "+ donor.Phone);
                Console.WriteLine("Email: "+donor.Email);
                Console.WriteLine("Address: "+donor.Address);
                Console.WriteLine("Blood Group: "+donor.BloodGrp);
                Console.WriteLine("Role"+donor.Role.ToString());
            } 
            );

           
        }

        public static void RemoveDonor(DBHandler db, Donor d)
        {

            ViewDonors(db,d);

            Console.WriteLine();
            Console.WriteLine("Enter the Id of the Donor you want to remove: ");
            var donorId = Convert.ToInt32(Console.ReadLine());  


            if(d.Role == roles.BloodBankManager)
            {
                BloodBank bank = db.FindBloodBank(d);
                db.DeleteBloodBank(null, bank.BankId);
            }


        }


    }
}
