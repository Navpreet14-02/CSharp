using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BloodGuardian.Models
{
    internal class Validation
    {

        public static void ValidateName(string name)
        {
            if (String.IsNullOrEmpty(name) || String.IsNullOrWhiteSpace(name)) throw new InvalidDataException("Name can not be empty.");

            if (name.Length < 3) throw new InvalidDataException("Length of name should be atleast 3.");
        }

        public static void ValidateAge(string age)
        {
            int ageValue;
            if (!int.TryParse(age,out ageValue)) throw new InvalidDataException("Enter valid input.");

            if (ageValue <=18) throw new InvalidDataException("Age Should be Greater than or equal to 18");


            if (ageValue > 65) throw new InvalidDataException("Age should be less than 65.");
        }

        public static void ValidatePhone(string phone)
        {
            int phoneValue;
            if (!int.TryParse(phone, out phoneValue)) throw new InvalidDataException("Enter valid Phone Number.");

            if (phone.Length < 10 || phone.Length>10) throw new InvalidDataException("The length of the phone number should be 10 digits.");


        }

        public static void ValidateState(string state)
        {
            if (String.IsNullOrEmpty(state) || String.IsNullOrWhiteSpace(state)) throw new InvalidDataException("State can not be empty.");
        }


        public static void ValidateCity(string city)
        {
            if (String.IsNullOrEmpty(city) || String.IsNullOrWhiteSpace(city)) throw new InvalidDataException("State can not be empty.");
        }


        public static void ValidateAddress(string address)
        {
            if (String.IsNullOrEmpty(address) || String.IsNullOrWhiteSpace(address)) throw new InvalidDataException("State can not be empty.");
        }

        public static void ValidateRole(string role)
        {
            object roleInput;
            if (String.IsNullOrEmpty(role) || String.IsNullOrWhiteSpace(role) || !Enum.TryParse(typeof(roles), role, out roleInput)) throw new InvalidDataException("Enter Valid Role.");

        }

        public static void ValidatePassword(string password)
        {

            if (String.IsNullOrEmpty(password) || String.IsNullOrWhiteSpace(password)) throw new InvalidDataException("Password can not be empty.");

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasLowerChar = new Regex(@"[a-z]+");

            var hasMinimum8Chars = new Regex(@".{8,}");

            var isValidated = hasNumber.IsMatch(password) && hasUpperChar.IsMatch(password) && hasMinimum8Chars.IsMatch(password);


            if (!isValidated) throw new InvalidDataException("Enter strong password with minimum length of 8 with numbers and Characters.");


        }

        public static void ValidateEmail(string email)
        {

            if (String.IsNullOrEmpty(email) || String.IsNullOrWhiteSpace(email)) throw new InvalidDataException("Email can not be empty.");


            //var emailRegex = new Regex(@"^([a - zA - Z0 - 9_\-\.] +)@([a - zA - Z0 - 9_\-\.] +)\.([a - zA - Z]{ 2,5})$");

            var emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");


            if (!emailRegex.IsMatch(email)) throw new InvalidDataException("Enter Valid Email.");
            

        }

        public static void ValidateBloodGroup(string bloodgrp)
        {

            if (String.IsNullOrEmpty(bloodgrp) || String.IsNullOrWhiteSpace(bloodgrp)) throw new InvalidDataException("Blood Group can not be empty.");

            List<string> BloodGroups = new List<string> { "A+", "A-", "B+", "B-", "O+", "O-", "AB+", "AB-" };

            if (!BloodGroups.Contains(bloodgrp)) throw new InvalidDataException("Enter Valid Blood Group.");


        }


        public static void ValidateDate(string date)
        {
            if (String.IsNullOrEmpty(date) || String.IsNullOrWhiteSpace(date)) throw new InvalidDataException("Date can not be empty.");

            DateTime transferDate;
            if (!DateTime.TryParse(Console.ReadLine(), out transferDate))
            {
                throw new InvalidDataException("Enter Invalid Date.");

            }
        

        }

        public static void ValidateTime(string time)
        {
            if (String.IsNullOrEmpty(time) || String.IsNullOrWhiteSpace(time)) throw new InvalidDataException("Time can not be empty.");

            TimeOnly timeInput;
            if (!TimeOnly.TryParse(time, out timeInput))
            {
                throw new InvalidDataException("Enter Invalid Time.");

            }


        }


        public static void ValidateBloodAmount(string amount)
        {

            if (String.IsNullOrEmpty(amount) || String.IsNullOrWhiteSpace(amount)) throw new InvalidDataException("Amount can not be empty.");


            int amnt;
            if (!int.TryParse(amount, out amnt)) throw new InvalidDataException("Enter valid input.");

        }

    }
}
