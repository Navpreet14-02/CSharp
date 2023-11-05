using BloodGuardian.Database;

namespace BloodGuardian.Common
{
    internal class InputHandler
    {

        public static string InputName(bool isUpdate)
        {
            string res = string.Empty;
            while (true)
            {

                string name = Console.ReadLine();

                if (isUpdate && name == string.Empty) return res;

                try
                {
                    Validation.ValidateName(name);

                }
                catch (InvalidDataException e)
                {
                    ExceptionsDBHandler.Instance.LogException(e);
                    Console.WriteLine(e.Message);
                    continue;
                }

                res = name;
                Console.WriteLine(Message.SingleDashDesign);
                break;

            }

            return res;
        }

        public static string InputUserName(bool isUpdate)
        {
            string res = string.Empty;
            while (true)
            {

                string uname = Console.ReadLine();

                if (isUpdate && uname == string.Empty) return res;

                try
                {
                    Validation.ValidateUserName(uname);

                }
                catch (InvalidDataException e)
                {
                    ExceptionsDBHandler.Instance.LogException(e);
                    Console.WriteLine(e.Message);
                    continue;
                }

                res = uname;
                Console.WriteLine(Message.SingleDashDesign);
                break;

            }

            return res;
        }

        public static int InputAge(bool isUpdate)
        {
            int res = -1;
            while (true)
            {

                string age = Console.ReadLine();

                if (isUpdate && age == string.Empty) return res;


                try
                {
                    Validation.ValidateAge(age);

                }
                catch (InvalidDataException e)
                {
                    ExceptionsDBHandler.Instance.LogException(e);
                    Console.WriteLine(e.Message);
                    continue;
                }

                res = Convert.ToInt32(age);
                Console.WriteLine(Message.SingleDashDesign);

                break;

            }

            return res;
        }

        public static long InputPhone(bool isUpdate)
        {
            long res = -1;
            while (true)
            {
                string phone = Console.ReadLine();

                if (isUpdate && phone == string.Empty) return res;


                try
                {
                    Validation.ValidatePhone(phone);

                }
                catch (InvalidDataException e)
                {

                    ExceptionsDBHandler.Instance.LogException(e);
                    Console.WriteLine(e.Message);
                    continue;
                }


                res = Convert.ToInt64(phone);
                Console.WriteLine(Message.SingleDashDesign);

                break;

            }

            return res;
        }

        public static int InputId()
        {
            int res;
            while (true)
            {
                string id = Console.ReadLine();



                try
                {
                    Validation.ValidateId(id);

                }
                catch (InvalidDataException e)
                {

                    ExceptionsDBHandler.Instance.LogException(e);
                    Console.WriteLine(e.Message);
                    continue;
                }

                res = Convert.ToInt32(id);
                Console.WriteLine(Message.SingleDashDesign);
                break;

            }

            return res;
        }

        public static string InputEmail(bool isUpdate)
        {

            string res = string.Empty;
            while (true)
            {

                string email = Console.ReadLine();
                if (isUpdate && email == string.Empty) return email;

                try
                {
                    Validation.ValidateEmail(email);

                }
                catch (InvalidDataException e)
                {

                    ExceptionsDBHandler.Instance.LogException(e);
                    Console.WriteLine(e.Message);
                    continue;
                }

                res = email;
                Console.WriteLine(Message.SingleDashDesign);

                break;

            }

            return res;
        }

        public static string InputRole(bool isUpdate)
        {

            string res;
            while (true)
            {


                string role = Console.ReadLine();


                try
                {
                    Validation.ValidateRole(role);
                }
                catch (InvalidDataException e)
                {

                    ExceptionsDBHandler.Instance.LogException(e);
                    Console.WriteLine(e.Message);
                    continue;
                }


                res = role;

                Console.WriteLine(Message.SingleDashDesign);

                break;
            }

            return res;
        }


        public static string InputState(bool isUpdate)
        {

            string res = string.Empty;
            while (true)
            {

                string state = Console.ReadLine();

                if (isUpdate && state == string.Empty) return res;

                try
                {
                    Validation.ValidateState(state);

                }
                catch (InvalidDataException e)
                {

                    ExceptionsDBHandler.Instance.LogException(e);
                    Console.WriteLine(e.Message);
                    continue;
                }
                res = state;
                Console.WriteLine(Message.SingleDashDesign);

                break;

            }

            return res;
        }

        public static string InputCity(bool isUpdate)
        {

            string res = string.Empty;
            while (true)
            {


                string city = Console.ReadLine();

                if (isUpdate && city == string.Empty) return res;


                try
                {
                    Validation.ValidateCity(city);

                }
                catch (InvalidDataException e)
                {

                    ExceptionsDBHandler.Instance.LogException(e);
                    Console.WriteLine(e.Message);
                    continue;
                }
                res = city;
                Console.WriteLine(Message.SingleDashDesign);

                break;

            }

            return res;
        }

        public static string InputAddress(bool isUpdate)
        {

            string res = string.Empty;
            while (true)
            {


                string address = Console.ReadLine();

                if (isUpdate && address == string.Empty) return res;


                try
                {
                    Validation.ValidateAddress(address);

                }
                catch (InvalidDataException e)
                {

                    ExceptionsDBHandler.Instance.LogException(e);
                    Console.WriteLine(e.Message);
                    continue;
                }
                res = address;
                Console.WriteLine(Message.SingleDashDesign);

                break;

            }

            return res;
        }

        public static string HidePasswordInput()
        {
            var pass = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    Console.Write("\b \b");
                    pass = pass[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    pass += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);

            return pass;
        }

        public static string InputPassword(bool isUpdate)
        {
            string res = string.Empty;

            while (true)
            {

                string pass = HidePasswordInput();

                if (isUpdate && pass == string.Empty) return res;
                try
                {
                    Validation.ValidatePassword(pass);

                }
                catch (InvalidDataException e)
                {
                    ExceptionsDBHandler.Instance.LogException(e);
                    Console.WriteLine();
                    Console.WriteLine(e.Message);
                    continue;
                }

                res = pass;
                Console.WriteLine();
                Console.WriteLine(Message.SingleDashDesign);
                break;

            }

            return res;
        }

        public static string InputBloodGroup(bool isUpdate)
        {
            string res;
            while (true)
            {

                string bloodgrp = Console.ReadLine();

                try
                {
                    Validation.ValidateBloodGroup(bloodgrp);

                }
                catch (InvalidDataException e)
                {

                    ExceptionsDBHandler.Instance.LogException(e);
                    Console.WriteLine(e.Message);
                    continue;
                }
                res = bloodgrp;
                Console.WriteLine(Message.SingleDashDesign);

                break;

            }

            return res;
        }

        public static DateTime InputDate(bool isUpdate)
        {
            DateTime dt;
            while (true)
            {


                string transferDate = Console.ReadLine();

                try
                {
                    Validation.ValidateDate(transferDate);
                }
                catch (InvalidDataException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                dt = DateTime.Parse(transferDate);
                break;


            }

            return dt;
        }

        public static int InputBloodAmount(bool isUpdate)
        {
            int res;
            while (true)
            {
                string amnt = Console.ReadLine();

                try
                {
                    Validation.ValidateBloodAmount(amnt);
                }
                catch (InvalidDataException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                res = Convert.ToInt32(amnt);
                break;

            }

            return res;
        }
    }
}
