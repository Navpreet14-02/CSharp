
namespace BloodGuardian.Tests.Common.Tests
{
    [TestClass]
    public class ValidationTests
    {
        [TestMethod]
        public void ValidateName_InputCheck_DoesNotThrowException()
        {

            string name = "Navi";


            bool actual = true;
            try
            {
                BloodGuardian.Common.Validation.ValidateName(name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                actual = false;
            }

            Assert.IsTrue(actual);

        }

        [TestMethod]
        public void ValidateName_InputCheck_ThrowsException()
        {

            string name = "123";


            bool actual = false;

            try
            {
                BloodGuardian.Common.Validation.ValidateName(name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                actual = true;
            }

            Assert.IsTrue(actual);

        }

        [TestMethod]
        public void ValidateUserName_InputCheck_DoesNotThrowException()
        {

            string uname = "Navi123";


            bool actual = true;
            try
            {
                BloodGuardian.Common.Validation.ValidateUserName(uname);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                actual = false;
            }

            Assert.IsTrue(actual);

        }

        [TestMethod]
        public void ValidateUserName_InputCheck_ThrowsException()
        {

            string uname = "Na";

            bool actual = false;

            try
            {
                BloodGuardian.Common.Validation.ValidateUserName(uname);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                actual = true;
            }

            Assert.IsTrue(actual);

        }

        [TestMethod]
        public void ValidateAge_InputCheck_DoesNotThrowException()
        {

            string age = "20";

            bool actual = true;

            try
            {
                BloodGuardian.Common.Validation.ValidateAge(age);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                actual = false;
            }

            Assert.IsTrue(actual);

        }

        [TestMethod]
        public void ValidateAge_InputCheck_ThrowsException()
        {

            string age = "Navi";

            bool actual = false;

            try
            {
                BloodGuardian.Common.Validation.ValidateAge(age);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                actual = true;
            }

            Assert.IsTrue(actual);

        }


        [TestMethod]
        public void ValidatePhone_InputCheck_DoesNotThrowException()
        {

            string phone = "2438532958";
            bool actual = true;

            try
            {
                BloodGuardian.Common.Validation.ValidatePhone(phone);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                actual = false;
            }

            Assert.IsTrue(actual);

        }

        [TestMethod]
        public void ValidatePhone_InputCheck_ThrowsException()
        {

            string phone = "Navi";

            bool actual = false;

            try
            {
                BloodGuardian.Common.Validation.ValidatePhone(phone);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                actual = true;
            }

            Assert.IsTrue(actual);

        }

        [TestMethod]
        public void ValidateId_InputCheck_DoesNotThrowException()
        {

            string id = "4";
            bool actual = true;

            try
            {
                BloodGuardian.Common.Validation.ValidateId(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                actual = false;
            }

            Assert.IsTrue(actual);

        }

        public void ValidateId_InputCheck_ThrowsException()
        {

            string id = "Navi";

            bool actual = false;
            try
            {
                BloodGuardian.Common.Validation.ValidateId(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                actual = true;
            }

            Assert.IsTrue(actual);

        }

        [TestMethod]
        public void ValidateState_InputCheck_DoesNotThrowException()
        {

            string state = "Punjab";

            bool actual = true;

            try
            {
                BloodGuardian.Common.Validation.ValidateState(state);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                actual = false;
            }

            Assert.IsTrue(actual);

        }

        [TestMethod]
        public void ValidateState_InputCheck_ThrowException()
        {

            string state = "234";

            bool actual = false;

            try
            {
                BloodGuardian.Common.Validation.ValidateState(state);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                actual = true;
            }

            Assert.IsTrue(actual);

        }


        [TestMethod]
        public void ValidateCity_InputCheck_DoesNotThrowException()
        {

            string city = "Patiala";


            bool actual = true;
            try
            {
                BloodGuardian.Common.Validation.ValidateCity(city);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                actual = false;
            }


            Assert.IsTrue(actual);

        }

        [TestMethod]
        public void ValidateCity_InputCheck_ThrowsException()
        {

            string city = " ";

            bool actual = false;
            try
            {
                BloodGuardian.Common.Validation.ValidateCity(city);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                actual = true;
            }

            Assert.IsTrue(actual);

        }

        [TestMethod]
        public void ValidateAddress_InputCheck_DoesNotThrowException()
        {

            string address = "Patiala,Punjab";

            bool actual = true;
            try
            {
                BloodGuardian.Common.Validation.ValidateAddress(address);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                actual = false;
            }

            Assert.IsTrue(actual);

        }

        [TestMethod]
        public void ValidateAddress_InputCheck_ThrowsException()
        {

            string address = "123 ";

            bool actual = false;
            try
            {
                BloodGuardian.Common.Validation.ValidateAddress(address);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                actual = true;
            }

            Assert.IsTrue(actual);

        }

        [TestMethod]
        public void ValidateRole_InputCheck_DoesNotThrowException()
        {

            string role = "2";

            bool actual = true;

            try
            {
                BloodGuardian.Common.Validation.ValidateRole(role);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                actual = false;
            }

            Assert.IsTrue(actual);

        }


        [TestMethod]
        public void ValidateRole_InputCheck_ThrowsException()
        {

            string role = "role";

            bool actual = false;

            try
            {
                BloodGuardian.Common.Validation.ValidateRole(role);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                actual = true;
            }

            Assert.IsTrue(actual);

        }

        [TestMethod]
        public void ValidateEmail_InputCheck_DoesNotThrowException()
        {

            string email = "navi@gmail.com";

            bool actual = true;
            try
            {
                BloodGuardian.Common.Validation.ValidateEmail(email);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                actual = false;
            }

            Assert.IsTrue(actual);

        }

        [TestMethod]
        public void ValidateEmail_InputCheck_ThrowsException()
        {

            string email = "Navi";

            bool actual = false;
            try
            {
                BloodGuardian.Common.Validation.ValidateEmail(email);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                actual = true;
            }

            Assert.IsTrue(actual);

        }

        [TestMethod]
        public void ValidateBloodGroup_InputCheck_DoesNotThrowException()
        {

            string bloodgrp = "B+";

            bool actual = true;

            try
            {
                BloodGuardian.Common.Validation.ValidateBloodGroup(bloodgrp);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                actual = false;
            }

            Assert.IsTrue(actual);

        }

        [TestMethod]
        public void ValidateBloodGroup_InputCheck_ThrowsException()
        {

            string bloodgrp = "Navi";

            bool actual = false;
            try
            {
                BloodGuardian.Common.Validation.ValidateBloodGroup(bloodgrp);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                actual = true;
            }

            Assert.IsTrue(actual);

        }

        [TestMethod]
        public void ValidateDate_InputCheck_DoesNotThrowException()
        {

            string date = "11/17/2023";

            bool actual = true;
            try
            {
                BloodGuardian.Common.Validation.ValidateDate(date);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                actual = true;
            }

            Assert.IsTrue(actual);

        }

        [TestMethod]
        public void ValidateDate_InputCheck_ThrowsException()
        {

            string date = "Navi";

            bool actual = false;
            try
            {
                BloodGuardian.Common.Validation.ValidateDate(date);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                actual = true;
            }

            Assert.IsTrue(actual);

        }

        [TestMethod]
        public void ValidateTime_InputCheck_DoesNotThrowException()
        {

            string date = "3:00";

            bool actual = true;
            try
            {
                BloodGuardian.Common.Validation.ValidateDate(date);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                actual = false;
            }

            Assert.IsTrue(actual);

        }

        [TestMethod]
        public void ValidateTime_InputCheck_ThrowsException()
        {

            string date = "Navi";

            bool actual = false;

            try
            {
                BloodGuardian.Common.Validation.ValidateDate(date);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                actual = true;
            }

            Assert.IsTrue(actual);

        }

        public void ValidateBloodAmount_InputCheck_DoesNotThrowException()
        {

            string blood_amount = "100";

            bool actual = true;

            try
            {
                BloodGuardian.Common.Validation.ValidateBloodAmount(blood_amount);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                actual = false;
            }

            Assert.IsTrue(actual);

        }

        public void ValidateBloodAmount_InputCheck_ThrowsException()
        {

            string blood_amount = "Navi";

            bool actual = false;
            try
            {
                BloodGuardian.Common.Validation.ValidateBloodAmount(blood_amount);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                actual = true;
            }

            Assert.IsTrue(actual);

        }
    }
}
