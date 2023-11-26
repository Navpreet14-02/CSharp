using BloodGuardian.Common;
using BloodGuardian.Common.Enums;
using BloodGuardian.Controller.Interfaces;
using BloodGuardian.Database;
using BloodGuardian.Database.Interface;
using BloodGuardian.Models;
using BloodGuardian.View;
using BloodGuardian.View.Interfaces;

namespace BloodGuardian.Controller
{

    public class DonorController : IDonor, IAdmin
    {

        private IBloodBankDBHandler _bankDBHandler;
        private IDonorDBHandler _donorDBHandler;


        public DonorController(IBloodBankDBHandler bankDBHandler,IDonorDBHandler donorDBHandler)

        {
            _bankDBHandler = bankDBHandler;
            _donorDBHandler = donorDBHandler;
        }

        public List<Donor> GetDonors()
        {
            return _donorDBHandler.Get();
        }

        public void UpdateProfile(Donor oldDonor,Donor newDonor)
        {
            

            //if (d.Role == Roles.BloodBankManager) Console.WriteLine("Blood Bank Name: " + _bankDBHandler.FindBloodBankbyDonor(d).BankName);


            //Console.WriteLine(Message.DoubleDashDesign);
            //Console.WriteLine(Message.EnterNewDetails);

            //Donor updatedDonor = _donorView.InputUpdatedUserInfo(d);


            _donorDBHandler.UpdateDonor(oldDonor, newDonor);


            //return updatedDonor;

        }

        //public void AdminViewDonors(Donor d)
        //{

        //    var donors = GetDonors();

        //    if (donors == null || donors.Count == 0)
        //    {
        //        Console.WriteLine(Message.NoRegisteredDonors);
        //        return;
        //    }

        //    donors.ForEach(donor =>
        //    {

        //        Console.WriteLine(Message.SingleDashDesign);
        //        Console.WriteLine("id: " + donor.Donorid);
        //        Console.WriteLine("Name: " + donor.Name);
        //        Console.WriteLine("UserName: " + donor.UserName);
        //        Console.WriteLine("Age: " + donor.Age);
        //        Console.WriteLine("Phone: " + donor.Phone);
        //        Console.WriteLine("Email: " + donor.Email);
        //        Console.WriteLine("Address: " + donor.Address);
        //        Console.WriteLine("Blood Group: " + donor.BloodGrp);
        //        Console.WriteLine("Role: " + donor.Role.ToString());
        //        Console.WriteLine(Message.SingleDashDesign);

        //    }
        //    );


        //}


        public Donor FindDonorByBank(BloodBank bank)
        {
            var donor = GetDonors().Find((dn) => dn.UserName.Equals(bank.ManagerUserName, StringComparison.InvariantCultureIgnoreCase));
            return donor;
        }

        public Donor FindDonorByUserName(string username)
        {
            var donorList = GetDonors();
            Donor d = donorList.FirstOrDefault((donor) => donor.UserName.Equals(username));

            return d;
        }

        public void AdminRemoveDonor(Donor donor)
        {


            if (donor.Role == Roles.BloodBankManager)
            {
                RemoveBloodBankManager(donor);
            }
            else
            {
                RemoveDonor(donor);
            }




        }

        public void RemoveDonor(Donor d)
        {
            _donorDBHandler.Delete(d);


        }

        private void RemoveBloodBankManager(Donor d)
        {
            var bank = _bankDBHandler.FindBloodBankbyDonor(d);
            RemoveDonor(d);

            _bankDBHandler.Delete(bank);

        }

        public Dictionary<BloodBank, List<BloodTransferReceipt>> GetBloodDonationHistory(Donor d)
        {
            return _bankDBHandler.GetDonorBloodDonationHistory(d);
        }

        //public void ViewBloodDonationHistory(Donor d)
        //{
        //    var BankdepositLists = _bankDBHandler.GetDonorBloodDonationHistory(d);


        //    var isFound = false;

        //    foreach (KeyValuePair<BloodBank, List<BloodTransferReceipt>> entry in BankdepositLists)
        //    {


        //        entry.Value.ForEach((receipt) =>
        //        {
        //            if (receipt.CustomerEmail.Equals(d.Email) && receipt.CustomerPhone.Equals(d.Phone))
        //            {
        //                isFound = true;

        //                Console.WriteLine();
        //                Console.WriteLine(Message.SingleDashDesign);
        //                Console.WriteLine($"Bank Name: {entry.Key.BankName}");
        //                Console.WriteLine($"Address: {entry.Key.Address}");
        //                Console.WriteLine($"Date: {receipt.BloodTransferDate}");
        //                Console.WriteLine(Message.SingleDashDesign);


        //            }
        //        });



        //    }

        //    if (!isFound)
        //    {
        //        Console.WriteLine(Message.NoBloodDonated);
        //    }


        //}

        public void AddAdmin(Donor newAdmin)
        {

            newAdmin.Role = Roles.Admin;

            _donorDBHandler.Add(newAdmin);


        }
    }
}
