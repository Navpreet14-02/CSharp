using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private List<string> BloodGroups =new List<string> { "A+", "A-","B+","B-","O+","O-","AB+","AB-" };

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

            Console.Write("Enter your Role - Admin,Donor or BloodBankManager: ");
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


    }
}
