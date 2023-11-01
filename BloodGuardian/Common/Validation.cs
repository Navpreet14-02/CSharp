using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using BloodGuardian.Models;

namespace BloodGuardian.Common
{
    public class Validation
    {

        private static Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        private static Regex hasOnlyAlphaNumeric = new Regex(@"^[A-z][A-z0-9]{2,28}$");

        public static void ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name)) throw new InvalidDataException(Message.NoEmptyName);

            if (name.Length < 3) throw new InvalidDataException(Message.NameLength);
        }

        public static void ValidateUserName(string name)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name)) throw new InvalidDataException(Message.NoEmptyUserName);


            if (!hasOnlyAlphaNumeric.IsMatch(name)) throw new InvalidDataException(Message.AlphanumericUserName);


            if (name.Length < 3) throw new InvalidDataException(Message.UserNameLength);


        }

        public static void ValidateAge(string age)
        {
            int ageValue;
            if (!int.TryParse(age, out ageValue)) throw new InvalidDataException(Message.EnterValidInput);

            if (ageValue <= 18) throw new InvalidDataException(Message.MinimumSupportedAge);


            if (ageValue > 65) throw new InvalidDataException(Message.MaximumSupportedAge);
        }

        public static void ValidatePhone(string phone)
        {
            long phoneValue;
            if (!long.TryParse(phone, out phoneValue)) throw new InvalidDataException(Message.EnterValidPhone);

            if (phone.Length < 10 || phone.Length > 10) throw new InvalidDataException(Message.PhoneLength);


        }

        public static void ValidateState(string state)
        {
            if (string.IsNullOrEmpty(state) || string.IsNullOrWhiteSpace(state)) throw new InvalidDataException(Message.NoEmptyState);
        }


        public static void ValidateCity(string city)
        {
            if (string.IsNullOrEmpty(city) || string.IsNullOrWhiteSpace(city)) throw new InvalidDataException(Message.NoEmptyCity);
        }


        public static void ValidateAddress(string address)
        {
            if (string.IsNullOrEmpty(address) || string.IsNullOrWhiteSpace(address)) throw new InvalidDataException(Message.NoEmptyAddress);
        }

        public static void ValidateRole(string role)
        {
            if (string.IsNullOrEmpty(role) || string.IsNullOrWhiteSpace(role)) throw new InvalidDataException(Message.NoEmptyRole);

            int roleInput;
            if (!int.TryParse(role, out roleInput))
            {
                throw new InvalidDataException(Message.EnterValidRole);
                
            }


            int roletaken = Convert.ToInt32(role);
            if (roletaken != (int)roles.Donor && roletaken != (int)roles.BloodBankManager)
            {
                throw new InvalidDataException(Message.ChooseValidRole);
                
               
            }
           
        
        }

        public static void ValidatePassword(string password)
        {

            if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password)) throw new InvalidDataException(Message.NoEmptyPassword);

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasLowerChar = new Regex(@"[a-z]+");

            var hasMinimum8Chars = new Regex(@".{8,}");

            var isValidated = hasNumber.IsMatch(password) && hasUpperChar.IsMatch(password) && hasMinimum8Chars.IsMatch(password) && hasLowerChar.IsMatch(password);


            if (!isValidated) throw new InvalidDataException(Message.EnterStrongPassword);


        }

        public static void ValidateEmail(string email)
        {

            if (string.IsNullOrEmpty(email) || string.IsNullOrWhiteSpace(email)) throw new InvalidDataException(Message.NoEmptyEmail);


            if (!emailRegex.IsMatch(email)) throw new InvalidDataException(Message.NoEmptyEmail);


        }

        public static void ValidateBloodGroup(string bloodgrp)
        {

            if (string.IsNullOrEmpty(bloodgrp) || string.IsNullOrWhiteSpace(bloodgrp)) throw new InvalidDataException(Message.NoEmptyBloodGroup);

            List<string> BloodGroups = new List<string> { "A+", "A-", "B+", "B-", "O+", "O-", "AB+", "AB-" };

            if (!BloodGroups.Contains(bloodgrp)) throw new InvalidDataException(Message.EnterValidBloodGroup);


        }


        public static void ValidateDate(string date)
        {
            if (string.IsNullOrEmpty(date) || string.IsNullOrWhiteSpace(date)) throw new InvalidDataException(Message.NoEmptyDate);

            DateTime transferDate;
            if (!DateTime.TryParse(date, out transferDate))
            {
                throw new InvalidDataException(Message.EnterValidDate);

            }


        }

        public static void ValidateTime(string time)
        {
            if (string.IsNullOrEmpty(time) || string.IsNullOrWhiteSpace(time)) throw new InvalidDataException(Message.NoEmptyTime);

            TimeOnly timeInput;
            if (!TimeOnly.TryParse(time, out timeInput))
            {
                throw new InvalidDataException(Message.EnterValidTime);

            }


        }


        public static void ValidateBloodAmount(string amount)
        {

            if (string.IsNullOrEmpty(amount) || string.IsNullOrWhiteSpace(amount)) throw new InvalidDataException(Message.NoEmptyAmount);


            int amnt;
            if (!int.TryParse(amount, out amnt) || amnt<0) throw new InvalidDataException(Message.EnterValidInput);

            if (amnt > 500) throw new InvalidDataException(Message.BloodAmountRange);

        }

    }
}
