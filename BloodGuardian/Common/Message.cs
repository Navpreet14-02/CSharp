﻿namespace BloodGuardian.Common
{
    internal class Message
    {
        public static string AppLogo = "******************** BLOODGUARDIAN ***********************";
        public static string SingleDashDesign = "----------------------";
        public static string DoubleDashDesign = "=====================================";
        public static string EnterInput = "Enter your Input:";
        public static string EnterValidOption = "Enter Valid Option.";
        public static string InvalidOption = "Invalid Option";
        public static string EnterAdminName = "Enter Admin Name: ";
        public static string EnterAdminUserName = "Enter Admin User Name: ";
        public static string EnterAdminAge = "Enter Admin Age: ";
        public static string EnterAdminPhone = "Enter Admin Phone: ";
        public static string EnterValidInput = "Enter Valid Input.";
        public static string EnterAdminEmail = "Enter Admin Email: ";
        public static string EnterAdminState = "Enter Admin State: ";
        public static string EnterAdminCity = "Enter Admin City: ";
        public static string EnterAdminAddress = "Enter Admin Address: ";
        public static string EnterAdminPassword = "Enter Admin Password: ";
        public static string EnterBloodGroup = "Enter your Blood Group - A+,A-,B+,B-,O+,O-,AB+,AB-: ";
        public static string EnterName = "Enter your Name: ";
        public static string EnterUserName = "Enter your User Name: ";
        public static string EnterAge = "Enter your Age: ";
        public static string EnterPhone = "Enter your Phone Number: ";
        public static string EnterEmail = "Enter your Email: ";
        public static string EnterState = "Enter your State: ";
        public static string EnterCity = "Enter your City: ";
        public static string EnterPassword = "Enter your Password: ";
        public static string EnterAddress = "Enter Address: ";
        public static string EnterRequiredBloodType = "Enter the Required Blood Type: ";
        public static string EnterBloodBankName = "Enter the Name of your BloodBank: ";
        public static string EnterDetails = "Enter following details: ";
        public static string EnterDonorName = "Enter the Name of the Donor: ";
        public static string BloodDonatedType = "Enter the Type of Blood Donated: ";
        public static string BloodWithdrawnType = "Enter the Type of Blood Withdrawn: ";
        public static string EnterDonorEmail = "Enter the Email of the Donor: ";
        public static string EnterDonorPhone = "Enter the phone no. of the Donor: ";
        public static string EnterTransferDate = "Enter the Date for the Blood Transfer - MM/DD/YYYY: ";
        public static string EnterBloodDonatedAmount = "Enter the amount of Blood Donated(in ml): ";
        public static string EnterBloodWithdrawnAmount = "Enter the amount of Blood Withdrawn(in ml): ";
        public static string BloodAvailabilityAmount = "Enter the quantities for the blood types available with you (ml): ";
        public static string EnterPatientName = "Enter the Name of the Patient: ";
        public static string EnterPatientEmail = "Enter the Email of the Patient: ";
        public static string EnterPatientPhone = "Enter the phone no. of the Patient: ";
        public static string EnterDonationCampDetails = "Enter following details for the Blood Donation Camp:";
        public static string EnterCampDate = "Enter the Date for the Camp(DD/MM/YYYY): ";
        public static string EnterCampState = "Enter the state in which the camp will be organized: ";
        public static string EnterCampCity = "Enter the city in which the camp will be organized: ";
        public static string EnterCampAddress = "Enter the complete address for the camp: ";
        public static string EnterCampStartTime = "Enter the start time for the camp(HH:MM) in 24-hour format:";
        public static string EnterCampEndTime = "Enter the end time for the camp(HH:MM) in 24-hour format: ";
        public static string EnterDifferentUserName = "Enter a different user name.";
        public static string EnterRole = "Enter your Role - 1. Donor or 2. BloodBankManager: ";
        public static string PrintAdminOptions = "Enter input as shown below: \n1:Update Profile.\n2:Add New Admin\n3:Manage Donors\n4:Manage BloodBanks\n5:Remove a Request\n6:SignOut.";
        public static string PrintAdminManageDonorOptions = "Enter input as shown below: \n1:See All Donors\n2:Remove a Donor\n3:Go Back";
        public static string PrintAdminManageBloodBankOptions = "Enter input as shown below: \n1:See All Blood Banks\n2:Remove a BloodBank\n3:See All Blood Donation Camps\n4:Remove a Blood Donation Camp\n5:Go Back";
        public static string PrintBloodBankManagerOptions = "Enter input as shown below: \n1:Update Profile.\n2:Add Blood Deposit Record\n3:Add Blood Withdraw Record\n4:Organize Blood Donation Camps\n5:See Blood Donation Camps.\n6:Remove Blood Donation Camps.\n7:SignOut.";
        public static string PrintHomePageOptions = "Enter input as shown below: \n1:Login\n2:Register\n3:See Blood Requests\n4:Add a Blood Request\n5:Search Blood.\n6:Exit.";
        public static string PrintDonorOptions = "Enter input as shown below: \n1:Update Profile\n2:Search Blood Banks Near you\n3:See Blood Donation Camps Near you\n4:See Blood Donation History\n5:SignOut";
        public static string UserRegistered = "You are Registered. ";
        public static string UserLoggedIn = "You are logged in.";
        public static string WrongLoginDetailsMessage = "Enter valid details. If you are a new user, then register first.";
        public static string EnterBloodBankId = "Enter the Id of the Blood Bank you want to remove: ";
        public static string EnterBankId = "Enter the bank id: ";
        public static string WrongBankId = "The bank with this id does not exist.";
        public static string OrganizedCamps = "Here are the blood donation camps organized by you: ";
        public static string EnterCampId = "Enter the id of camp you want to remove: ";
        public static string WrongCampId = "The camp with this id does not exist.";
        public static string RemoveCampSteps = "You can remove a camp by following below Steps: \n1. Select the bank id organizing that Blood Bank.\n2. Select the camp id to remove.";
        public static string ShowOldDetails = "Below are your old details:";
        public static string EnterNewDetails = "Enter your new Details: ";
        public static string EnterDonorId = "Enter the Id of the Donor you want to remove: ";
        public static string WrongDonorId = "The donor with this id does not exist.";
        public static string NoBloodDonated = "You have not donated blood anywhere yet.";
        public static string EnterRequestId = "Enter the Id of the Request you want to remove: ";
        public static string WrongRequestId = "The request with thid id does not exist.";
        public static string NoBloodBankFound = "There are no Blood Banks Near You.";
        public static string NoNearbyBloodBankFound = "There are no Blood Banks Near You with the Required Blood Group. You can issue a Blood Request.";
        public static string NoDonationCampFound = "There are no Blood Donation Camps near you.";
        public static string NoEmptyName = "Name can not be empty.";
        public static string NameLength = "Length of name should be atleast 3.";
        public static string NoEmptyUserName = "User Name can not be empty.";
        public static string AlphanumericUserName = "User Name can only be alphanumeric";
        public static string UserNameLength = "Length of User Name should be atleast 3.";
        public static string MinimumSupportedAge = "Age Should be Greater than or equal to 18";
        public static string MaximumSupportedAge = "Age should be less than 65.";
        public static string EnterValidPhone = "Enter valid Phone Number.";
        public static string PhoneLength = "The length of the phone number should be 10 digits.";
        public static string NoEmptyState = "State can not be empty.";
        public static string NoEmptyCity = "City can not be empty.";
        public static string NoEmptyAddress = "Address can not be empty.";
        public static string NoEmptyRole = "Role can not be empty.";
        public static string EnterValidRole = "Enter valid Role.";
        public static string ChooseValidRole = "Please choose a valid role.";
        public static string NoEmptyPassword = "Password can not be empty.";
        public static string EnterStrongPassword = "Enter strong password with minimum length of 8 with numbers, Lower and Uppercase Characters.";
        public static string NoEmptyEmail = "Enter can not be Email.";
        public static string EnterValidEmail = "Enter Valid Email.";
        public static string NoEmptyBloodGroup = "Blood Group can not be empty.";
        public static string EnterValidBloodGroup = "Enter Valid Blood Group.";
        public static string NoEmptyDate = "Date can not be empty.";
        public static string EnterValidDate = "Enter Valid Date.";
        public static string NoEmptyTime = "Time can not be empty.";
        public static string EnterValidTime = "Enter Valid Time.";
        public static string EnterValidState = "Enter Valid State.";
        public static string EnterValidName = "Enter Valid Name.";
        public static string EnterValidCity = "Enter Valid City.";
        public static string EnterValidAddress = "Enter Valid Address.";
        public static string NoEmptyAmount = "Amount can not be empty.";
        public static string BloodAmountRange = "Please enter a value less than or equal to 500.";
        public static string _donorDataPath = @"C:\Users\nasingh\source\repos\BloodGuardian\Database\Donors.json";
        public static string _bankDataPath = @"C:\Users\nasingh\source\repos\BloodGuardian\Database\BloodBanks.json";
        public static string _requestDataPath = @"C:\Users\nasingh\source\repos\BloodGuardian\Database\BloodRequests.json";
        public static string _exceptionsDataPath = @"C:\Users\nasingh\source\repos\BloodGuardian\Database\Exceptions.txt";
        public static string UnexpectedError = "Unexpected Error Occurred.";
        public static string RestartingApp = "App Restarting...";
        public static string NotAuthorized = "You are not authorized.";
        public static string NoDonationCamps = "There are no Blood Donation Camps organized by your Bank.";
        public static string NoDonationCampOrganized = "There are no Organized Blood Donation Camps.";
        public static string NoDonationCampsBank = "There are no Blood Donation Camps organized by this Bank.";
        public static string NoRegisteredBloodBanks = "There are no registered blood banks.";
        public static string NoRegisteredDonors = "There are no registered Donors.";
        public static string SigningOut = "Signing Out...";

    }
}
